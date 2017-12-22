using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using AppLayer.Command;
using AppLayer.DrawingComponents;

namespace UML
{
    public partial class MainForm : Form
    {
        private readonly Drawing drawing;
        private bool forceRedraw;
        private readonly Invoker invoker = new Invoker();
        private string currentAssocationResource;
        private float currentScale = 1;
        private bool showRubberBand;
        private bool eraseLastRubberBand;
        private Point startingPoint;
        private Point lastRubberBandEnd;
        private Point rubberBandStart;
        private Point rubberBandEnd;


        private enum PossibleModes
        {
            None,
            AssocationDrawing,
            BoxDrawing,
            Selection
        };

        private PossibleModes mode = PossibleModes.None;

        private Bitmap imageBuffer;
        private Graphics imageBufferGraphics;
        private Graphics panelGraphics;

        public MainForm()
        {
            InitializeComponent();

            AssociationFactory.Instance.ResourceNamePattern = @"UML.Graphics.{0}.png";
            AssociationFactory.Instance.ReferenceType = typeof(Program);

            drawing = new Drawing();
            CommandFactory.Instance.TargetDrawing = drawing;
            CommandFactory.Instance.Invoker = invoker;

            invoker.Start();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ComputeDrawingPanelSize();
            refreshTimer.Start();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            DisplayDrawing();
        }

        private void DisplayDrawing()
        {
            if (imageBuffer == null)
            {
                imageBuffer = new Bitmap(drawingPanel.Width, drawingPanel.Height);
                imageBufferGraphics = Graphics.FromImage(imageBuffer);
                panelGraphics = drawingPanel.CreateGraphics();
            }

            if (drawing.Draw(imageBufferGraphics, forceRedraw))
                panelGraphics.DrawImageUnscaled(imageBuffer, 0, 0);

            forceRedraw = false;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            CommandFactory.Instance.CreateAndExecute("new");
        }

        private void ClearOtherSelectedTools(ToolStripButton ignoreItem)
        {
            foreach (var item in drawingToolStrip.Items)
            {
                var toolButton = item as ToolStripButton;
                if (toolButton != null && item != ignoreItem && toolButton.Checked)
                    toolButton.Checked = false;
            }
        }

        private void pointerButton_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button != null && button.Checked)
            {
                mode = PossibleModes.Selection;
                currentAssocationResource = string.Empty;
            }
            else
            {
                CommandFactory.Instance.CreateAndExecute("deselect");
                mode = PossibleModes.None;
            }
        }

        private void assocationButton_Click(object sender, EventArgs e)
        {
            var button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button != null && button.Checked)
                currentAssocationResource = button.Text;
            else
                currentAssocationResource = string.Empty;

            CommandFactory.Instance.CreateAndExecute("deselect");
            mode = (currentAssocationResource != string.Empty) ? PossibleModes.AssocationDrawing : PossibleModes.None;
        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            switch (mode)
            {
                case PossibleModes.BoxDrawing:
                    {
                        var form = new LabelBoxForm
                        {
                            Location =
                                new Point(drawingPanel.ClientRectangle.Left + e.Location.X,
                                    drawingPanel.ClientRectangle.Top + e.Location.Y)
                        };

                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            var minX = Math.Min(startingPoint.X, e.Location.X);
                            var maxX = Math.Max(startingPoint.X, e.Location.X);
                            var minY = Math.Min(startingPoint.Y, e.Location.Y);
                            var maxY = Math.Max(startingPoint.Y, e.Location.Y);

                            var size = new Size() { Width = maxX - minX, Height = maxY - minY };
                            CommandFactory.Instance.CreateAndExecute("addumlclass", form.LabelText, startingPoint, size);
                        }
                        break;
                    }
                case PossibleModes.AssocationDrawing:
                    if (!string.IsNullOrWhiteSpace(currentAssocationResource))
                        CommandFactory.Instance.CreateAndExecute("addassocation", currentAssocationResource, e.Location, currentScale);
                    break;
                case PossibleModes.Selection:
                    CommandFactory.Instance.CreateAndExecute("select", e.Location);
                    break;
            }

            showRubberBand = false;
            eraseLastRubberBand = false;
        }

        private void scale_Leave(object sender, EventArgs e)
        {
            currentScale = ConvertToFloat(scale.Text, 0.01F, 99.0F, 1);
            scale.Text = currentScale.ToString(CultureInfo.InvariantCulture);
        }

        private float ConvertToFloat(string text, float min, float max, float defaultValue)
        {
            var result = defaultValue;
            if (!string.IsNullOrWhiteSpace(text))
            {
                result = !float.TryParse(text, out result) ? defaultValue : Math.Max(min, Math.Min(max, result));
            }
            return result;
        }

        private void scale_TextChanged(object sender, EventArgs e)
        {
            currentScale = ConvertToFloat(scale.Text, 0.01F, 99.0F, 1);
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                DefaultExt = "json",
                Multiselect = false,
                RestoreDirectory = true,
                Filter = @"JSON files (*.json)|*.json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CommandFactory.Instance.CreateAndExecute("load", dialog.FileName);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            var dialog = new SaveFileDialog
            {
                DefaultExt = "json",
                RestoreDirectory = true,
                Filter = @"JSON files (*.json)|*.json"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CommandFactory.Instance.CreateAndExecute("save", dialog.FileName);
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ComputeDrawingPanelSize();
        }

        private void ComputeDrawingPanelSize()
        {
            var width = Width - drawingToolStrip.Width;
            var height = Height - fileToolStrip.Height;

            drawingPanel.Size = new Size(width, height);
            drawingPanel.Location = new Point(drawingToolStrip.Width, fileToolStrip.Height);

            imageBuffer = null;

            forceRedraw = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            CommandFactory.Instance.CreateAndExecute("remove");
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            invoker?.Stop();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            invoker.Undo();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            invoker.Redo();
        }

        private void labelBoxButton_Click(object sender, EventArgs e)
        {
            mode = PossibleModes.BoxDrawing;
        }

        private void drawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (mode != PossibleModes.BoxDrawing) return;

            startingPoint = e.Location;
            rubberBandStart = ComputeAbsolutePoint(e.Location);
            showRubberBand = true;
        }

        private void drawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (!showRubberBand) return;

            rubberBandEnd = ComputeAbsolutePoint(e.Location);

            switch (mode)
            {
                case PossibleModes.BoxDrawing:
                    DrawRubberBandBox();
                    break;
            }

            eraseLastRubberBand = true;
            lastRubberBandEnd = rubberBandEnd;
        }
        
        private void DrawRubberBandBox()
        {
            if (eraseLastRubberBand)
                EraseOldRubberBandFrame();

            var rectangle = new Rectangle(rubberBandStart.X, rubberBandStart.Y,
                                        rubberBandEnd.X - rubberBandStart.X, rubberBandEnd.Y - rubberBandStart.Y);
            ControlPaint.DrawReversibleFrame(rectangle, Color.Gray, FrameStyle.Dashed);
        }

        private void EraseOldRubberBandFrame()
        {
            var oldRectangle = new Rectangle(rubberBandStart.X, rubberBandStart.Y,
                                        lastRubberBandEnd.X - rubberBandStart.X, lastRubberBandEnd.Y - rubberBandStart.Y);
            ControlPaint.DrawReversibleFrame(oldRectangle, Color.Gray, FrameStyle.Dashed);
        }

        private Point ComputeAbsolutePoint(Point location)
        {
            return drawingPanel.PointToScreen(
                        new Point(drawingPanel.ClientRectangle.Left + location.X,
                        ClientRectangle.Top + location.Y));
        }
    }
}
