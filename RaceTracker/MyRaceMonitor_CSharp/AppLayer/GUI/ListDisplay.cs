using AppLayer.observer;
using AppLayer.subject.impl;
using RaceData;
using System;
using System.Windows.Forms;

namespace AppLayer.GUI
{
    public partial class ListDisplay : Observer
    {
        public ListDisplay()
        {
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
                athListView.Items.Clear();
                foreach (Athlete ath in athletesBeingObserved)
                {
                    ListViewItem item = new ListViewItem(new[]
                    {
                        ath.firstName.ToString(),
                        ath.age.ToString(),
                        ath.status.ToString(),
                        getTime(ath.officialStartTime),
                        getTime(ath.officialEndTime),
                        ath.locationOnCourse.ToString()
                    });
                    athListView.Items.Add(item);
                }
            }
        }

        private string getTime(DateTime? time)
        {
            if (time == null)
                return "-";
            else
                return time.Value.ToShortTimeString();
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

    }
}
