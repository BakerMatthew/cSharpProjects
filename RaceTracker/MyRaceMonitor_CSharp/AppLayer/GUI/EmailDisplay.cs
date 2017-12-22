using AppLayer.observer;
using AppLayer.subject.impl;
using RaceData;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppLayer.GUI
{
    public partial class EmailDisplay : Observer
    {
        private string userEmail;
        private string display;
        private Dictionary<int, int> updateCount = new Dictionary<int, int>();

        public EmailDisplay(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                email = "Default_Email@domain.com";
            else
                userEmail = email;
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
                foreach (Athlete ath in athletesBeingObserved)
                {
                    if (!updateCount.ContainsKey(ath.bibNumber))
                        updateCount[ath.bibNumber] = 5;
                    else
                        updateCount[ath.bibNumber] += 1;

                    if (updateCount[ath.bibNumber] >= 5)
                    {
                        display += "Email sent to \"" + userEmail.ToString() + "\" about athlete: '" + ath.bibNumber.ToString() + "' at: " + ath.timestamp.ToString() + "\n";
                        athTextBox.Text = display;
                        updateCount[ath.bibNumber] = 0;
                    }
                    
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
