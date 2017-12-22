using AppLayer.subject;
using AppLayer.subject.impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AppLayer.observer
{
    public class Observer : Form
    {
        private object obsLock = new object();

        private Dictionary<int, Athlete> observedAthletes = new Dictionary<int, Athlete>();
        public string title { get; set; }

        protected bool needUpdate;
        private readonly Timer refresh = new Timer();
        public int refreshFrequency { get; set; }

        public virtual void update(Subject subject)
        {
            Athlete ath = subject as Athlete;
            if (ath != null)
            {
                lock (obsLock)
                {
                    if (!observedAthletes.ContainsKey(ath.bibNumber))
                    {
                        observedAthletes.Add(ath.bibNumber, ath);
                    } else
                    {
                        observedAthletes[ath.bibNumber] = ath;
                    }
                }
                needUpdate = true;
            }
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (needUpdate)
            {
                lock (obsLock)
                {
                    updateDisplay(sender, e);
                    needUpdate = false;
                }
            }
        }

        protected void StartRefreshTimer()
        {
            if (refreshFrequency <= 0)
                refreshFrequency = 50;

            refresh.Interval = refreshFrequency;
            refresh.Tick += refreshTimer_Tick;
            refresh.Start();
        }

        protected void UnregisterFromAllSubjects()
        {
            var iterator = observedAthletes.GetEnumerator();
            while (iterator.MoveNext())
                iterator.Current.Value.removeObserver(this);
        }

        protected virtual void updateDisplay(object sender, EventArgs e) { }
        protected List<Athlete> athletesBeingObserved => observedAthletes.Values.ToList();
    }
}
