using AppLayer.observer;
using System.Collections.Generic;

namespace AppLayer.subject
{
    public class Subject
    {
        private object obsLock = new object();

        public List<Observer> observers = new List<Observer>();

        public void registerObserver(Observer obs)
        {
            lock (obsLock)
            {
                if (obs != null && !observers.Contains(obs))
                {
                    observers.Add(obs);
                }
            }
        }

        public void removeObserver(Observer obs)
        {
            lock (obsLock)
            {
                if (observers.Contains(obs))
                {
                    observers.Remove(obs);
                }
            }
        }

        public void notifyObservers()
        {
            lock (obsLock)
            {
                foreach (Observer obs in observers)
                {
                    obs.update(Clone());
                }
            }
        }

        public virtual Subject Clone()
        {
            return MemberwiseClone() as Subject;
        }
    }
}
