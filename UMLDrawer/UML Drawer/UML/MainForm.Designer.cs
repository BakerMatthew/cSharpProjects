namespace UML
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.refreshTimer = new System.Windows.Forms.Timer(this.components);
            this.fileToolStrip = new System.Windows.Forms.ToolStrip();
            this.newButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.undoButton = new System.Windows.Forms.ToolStripButton();
            this.redoButton = new System.Windows.Forms.ToolStripButton();
            this.drawingToolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.pointerButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.scale = new System.Windows.Forms.ToolStripTextBox();
            this.labelBoxButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.associationButton = new System.Windows.Forms.ToolStripButton();
            this.compositionButton = new System.Windows.Forms.ToolStripButton();
            this.aggregationButton = new System.Windows.Forms.ToolStripButton();
            this.specializationButton = new System.Windows.Forms.ToolStripButton();
            this.dependencyButton = new System.Windows.Forms.ToolStripButton();
            this.fileToolStrip.SuspendLayout();
            this.drawingToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // drawingPanel
            // 
            this.drawingPanel.BackColor = System.Drawing.Color.White;
            this.drawingPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.drawingPanel.Location = new System.Drawing.Point(96, 67);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(818, 672);
            this.drawingPanel.TabIndex = 1;
            this.drawingPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseDown);
            this.drawingPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseMove);
            this.drawingPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawingPanel_MouseUp);
            // 
            // refreshTimer
            // 
            this.refreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // fileToolStrip
            // 
            this.fileToolStrip.AutoSize = false;
            this.fileToolStrip.BackColor = System.Drawing.Color.Lavender;
            this.fileToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.fileToolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.fileToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newButton,
            this.toolStripSeparator6,
            this.openButton,
            this.saveButton,
            this.toolStripSeparator5,
            this.deleteButton,
            this.toolStripSeparator3,
            this.undoButton,
            this.redoButton});
            this.fileToolStrip.Location = new System.Drawing.Point(0, 0);
            this.fileToolStrip.Name = "fileToolStrip";
            this.fileToolStrip.Size = new System.Drawing.Size(914, 64);
            this.fileToolStrip.TabIndex = 2;
            this.fileToolStrip.Text = "toolStrip1";
            // 
            // newButton
            // 
            this.newButton.AutoSize = false;
            this.newButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newButton.Image = ((System.Drawing.Image)(resources.GetObject("newButton.Image")));
            this.newButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newButton.Name = "newButton";
            this.newButton.Size = new System.Drawing.Size(61, 61);
            this.newButton.Text = "New";
            this.newButton.Click += new System.EventHandler(this.newButton_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 64);
            // 
            // openButton
            // 
            this.openButton.AutoSize = false;
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(61, 61);
            this.openButton.Text = "Open Drawing";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.AutoSize = false;
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(61, 61);
            this.saveButton.Text = "Save Drawing";
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 64);
            // 
            // deleteButton
            // 
            this.deleteButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(36, 61);
            this.deleteButton.Text = "Delete";
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 64);
            // 
            // undoButton
            // 
            this.undoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoButton.Image = ((System.Drawing.Image)(resources.GetObject("undoButton.Image")));
            this.undoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(36, 61);
            this.undoButton.Text = "Undo";
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoButton.Image = ((System.Drawing.Image)(resources.GetObject("redoButton.Image")));
            this.redoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(36, 61);
            this.redoButton.Text = "Redo";
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // drawingToolStrip
            // 
            this.drawingToolStrip.BackColor = System.Drawing.Color.Lavender;
            this.drawingToolStrip.Dock = System.Windows.Forms.DockStyle.Left;
            this.drawingToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.drawingToolStrip.ImageScalingSize = new System.Drawing.Size(64, 64);
            this.drawingToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.pointerButton,
            this.toolStripSeparator2,
            this.scale,
            this.labelBoxButton,
            this.toolStripSeparator1,
            this.associationButton,
            this.compositionButton,
            this.aggregationButton,
            this.specializationButton,
            this.dependencyButton});
            this.drawingToolStrip.Location = new System.Drawing.Point(0, 64);
            this.drawingToolStrip.Name = "drawingToolStrip";
            this.drawingToolStrip.Padding = new System.Windows.Forms.Padding(0, 8, 1, 0);
            this.drawingToolStrip.Size = new System.Drawing.Size(91, 677);
            this.drawingToolStrip.TabIndex = 3;
            this.drawingToolStrip.Text = "Tools";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(88, 19);
            this.toolStripLabel1.Text = "Object Select";
            // 
            // pointerButton
            // 
            this.pointerButton.AutoSize = false;
            this.pointerButton.CheckOnClick = true;
            this.pointerButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pointerButton.Image = ((System.Drawing.Image)(resources.GetObject("pointerButton.Image")));
            this.pointerButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pointerButton.Name = "pointerButton";
            this.pointerButton.Size = new System.Drawing.Size(50, 37);
            this.pointerButton.Text = "Select";
            this.pointerButton.Click += new System.EventHandler(this.pointerButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(88, 6);
            // 
            // scale
            // 
            this.scale.AutoSize = false;
            this.scale.Name = "scale";
            this.scale.Size = new System.Drawing.Size(0, 23);
            this.scale.Text = "1";
            this.scale.Leave += new System.EventHandler(this.scale_Leave);
            this.scale.TextChanged += new System.EventHandler(this.scale_TextChanged);
            // 
            // labelBoxButton
            // 
            this.labelBoxButton.AutoSize = false;
            this.labelBoxButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.labelBoxButton.Image = ((System.Drawing.Image)(resources.GetObject("labelBoxButton.Image")));
            this.labelBoxButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.labelBoxButton.Name = "labelBoxButton";
            this.labelBoxButton.Size = new System.Drawing.Size(90, 40);
            this.labelBoxButton.Text = "Class";
            this.labelBoxButton.Click += new System.EventHandler(this.labelBoxButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(88, 6);
            // 
            // associationButton
            // 
            this.associationButton.AutoSize = false;
            this.associationButton.CheckOnClick = true;
            this.associationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.associationButton.Image = ((System.Drawing.Image)(resources.GetObject("associationButton.Image")));
            this.associationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.associationButton.Name = "associationButton";
            this.associationButton.Size = new System.Drawing.Size(90, 20);
            this.associationButton.Text = "association";
            this.associationButton.Click += new System.EventHandler(this.assocationButton_Click);
            // 
            // compositionButton
            // 
            this.compositionButton.AutoSize = false;
            this.compositionButton.CheckOnClick = true;
            this.compositionButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.compositionButton.Image = ((System.Drawing.Image)(resources.GetObject("compositionButton.Image")));
            this.compositionButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.compositionButton.Name = "compositionButton";
            this.compositionButton.Size = new System.Drawing.Size(90, 20);
            this.compositionButton.Text = "composition";
            this.compositionButton.Click += new System.EventHandler(this.assocationButton_Click);
            // 
            // aggregationButton
            // 
            this.aggregationButton.AutoSize = false;
            this.aggregationButton.CheckOnClick = true;
            this.aggregationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.aggregationButton.Image = ((System.Drawing.Image)(resources.GetObject("aggregationButton.Image")));
            this.aggregationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aggregationButton.Name = "aggregationButton";
            this.aggregationButton.Size = new System.Drawing.Size(90, 20);
            this.aggregationButton.Text = "aggregation";
            this.aggregationButton.Click += new System.EventHandler(this.assocationButton_Click);
            // 
            // specializationButton
            // 
            this.specializationButton.AutoSize = false;
            this.specializationButton.CheckOnClick = true;
            this.specializationButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.specializationButton.Image = ((System.Drawing.Image)(resources.GetObject("specializationButton.Image")));
            this.specializationButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.specializationButton.Name = "specializationButton";
            this.specializationButton.Size = new System.Drawing.Size(90, 20);
            this.specializationButton.Text = "specialization";
            this.specializationButton.Click += new System.EventHandler(this.assocationButton_Click);
            // 
            // dependencyButton
            // 
            this.dependencyButton.AutoSize = false;
            this.dependencyButton.CheckOnClick = true;
            this.dependencyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.dependencyButton.Image = ((System.Drawing.Image)(resources.GetObject("dependencyButton.Image")));
            this.dependencyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.dependencyButton.Name = "dependencyButton";
            this.dependencyButton.Size = new System.Drawing.Size(90, 20);
            this.dependencyButton.Text = "dependency";
            this.dependencyButton.ToolTipText = "dependency";
            this.dependencyButton.Click += new System.EventHandler(this.assocationButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(914, 741);
            this.Controls.Add(this.drawingToolStrip);
            this.Controls.Add(this.fileToolStrip);
            this.Controls.Add(this.drawingPanel);
            this.KeyPreview = true;
            this.Name = "MainForm";
            this.Text = "UML Designer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.fileToolStrip.ResumeLayout(false);
            this.fileToolStrip.PerformLayout();
            this.drawingToolStrip.ResumeLayout(false);
            this.drawingToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Timer refreshTimer;
        private System.Windows.Forms.ToolStrip fileToolStrip;
        private System.Windows.Forms.ToolStripButton newButton;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStrip drawingToolStrip;
        private System.Windows.Forms.ToolStripButton pointerButton;
        private System.Windows.Forms.ToolStripButton associationButton;
        private System.Windows.Forms.ToolStripButton compositionButton;
        private System.Windows.Forms.ToolStripButton aggregationButton;
        private System.Windows.Forms.ToolStripButton specializationButton;
        private System.Windows.Forms.ToolStripButton dependencyButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton deleteButton;
        private System.Windows.Forms.ToolStripButton undoButton;
        private System.Windows.Forms.ToolStripButton redoButton;
        private System.Windows.Forms.ToolStripButton labelBoxButton;
        private System.Windows.Forms.ToolStripTextBox scale;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}

