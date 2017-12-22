using AppLayer.observer;
using AppLayer.subject.impl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AppLayer.GUI
{
    public partial class GraphicalDisplay : Observer
    {
        double courseLength;
        private List<string> colorChanges = new List<string>();
        private List<string> sizeChanges = new List<string>();
        private Dictionary<int, Label> labels = new Dictionary<int, Label>();
        private Random ran = new Random();

        public GraphicalDisplay(double courseLength)
        {
            this.courseLength = courseLength;
            InitializeComponent();
        }

        protected override void updateDisplay(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(updateDisplay), new object[] { sender, e });
            }
            else
            {
                updateListView();
                updateLabels();
            }
        }

        private void updateListView()
        {
            athListView.Items.Clear();
            foreach (Athlete ath in athletesBeingObserved)
            {
                ListViewItem item = new ListViewItem(new[]
                {
                    ath.firstName.ToString()
                });
                athListView.Items.Add(item);
            }
        }

        private void updateLabels()
        {
            foreach (Athlete ath in athletesBeingObserved)
            {
                if (!labels.ContainsKey(ath.bibNumber))
                {
                    if (ath.bibNumber % 2 == 1)
                        labels[ath.bibNumber] = new Label() { Text = ath.bibNumber.ToString(), Location = new Point(120, 210) };
                    else
                        labels[ath.bibNumber] = new Label() { Text = ath.bibNumber.ToString(), Location = new Point(120, 250) };
                    this.Controls.Add(labels[ath.bibNumber]);
                }
                else
                {
                    if (ath.bibNumber % 2 == 1)
                        labels[ath.bibNumber].Location = new Point((int)(((ath.locationOnCourse / courseLength) * 370) + 120), 210);
                    else
                        labels[ath.bibNumber].Location = new Point((int)(((ath.locationOnCourse / courseLength) * 370) + 120), 250);
                }
                if (colorChanges.Contains(ath.firstName.ToString()))
                {
                    labels[ath.bibNumber].ForeColor = ath.getRandomColor();
                }
                if (sizeChanges.Contains(ath.firstName.ToString()))
                {
                    float size = labels[ath.bibNumber].Font.Size;
                    size += (float)ran.Next(-(int)(labels[ath.bibNumber].Font.Size), (int)(labels[ath.bibNumber].Font.Size)) / (float)6.0;
                    if (size < 7)
                        size += 1;
                    else if (size > 15)
                        size -= (float)1.5;
                    labels[ath.bibNumber].Font = new Font(
                        labels[ath.bibNumber].Font.FontFamily,
                        size
                        );
                }
            }
        }

        private void ListDisplay_Load(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(updateDisplay), new object[] { sender, e });
            }
            else
            {
                Text = title;
                StartRefreshTimer();
            }
        }

        private void updateAthletesButton_Click(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(updateDisplay), new object[] { sender, e });
            }
            else
            {
                foreach (ListViewItem item in athListView.SelectedItems)
                {
                    if (changeColor.Checked)
                    {
                        if (!colorChanges.Contains(item.Text.ToString()))
                        {
                            /*
                                athletesBeingObserved[item.Tag.bibNumber] = new ColorDecorator() {
                                    decoratedAthlete = athletesBeingObserved[item.Tag.bibNumber],
                                    altColor = athletesBeingObserved[item.Tag.bibNumber].getRandomColor()
                                    }
                            */
                            colorChanges.Add(item.Text.ToString());
                        }
                    }
                    if (changeSize.Checked)
                    {
                        if (!sizeChanges.Contains(item.Text.ToString()))
                        {
                            /*
                                athletesBeingObserved[item.Tag.bibNumber] = new TextSizeDecorator() {
                                    decoratedAthlete = athletesBeingObserved[item.Tag.bibNumber],
                                    deltaSize = 5
                                    }
                            */
                            sizeChanges.Add(item.Text.ToString());
                        }
                    }
                        
                }
            }

        }
    }
}
