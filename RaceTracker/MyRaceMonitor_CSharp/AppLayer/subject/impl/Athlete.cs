using RaceData;
using RaceData.Messages;
using System;
using System.Drawing;
using System.Threading;

namespace AppLayer.subject.impl
{
    public class Athlete : Subject
    {
        public virtual int bibNumber { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public AthleteRaceStatus status { get; set; }
        public DateTime? timestamp { get; set; }

        public DateTime? officialStartTime { get; set; }
        public DateTime? officialEndTime { get; set; }
        public double locationOnCourse { get; set; }

        /// <summary>
        /// Update the values provided in updateMessage
        /// </summary>
        /// <param name="updateMessage">Contains updated values</param>
        public void updateStats(AthleteUpdate updateMessage)
        {
            status = updateMessage.UpdateType;
            timestamp = updateMessage.Timestamp;
            switch (updateMessage.UpdateType)
            {
                case AthleteRaceStatus.Registered:
                    // Do nothing
                    break;
                case AthleteRaceStatus.DidNotStart:
                    // Do nothing
                    break;
                case AthleteRaceStatus.Started:
                    StartedUpdate startUpdate = (StartedUpdate)updateMessage;
                    officialStartTime = startUpdate.OfficialStartTime;
                    break;
                case AthleteRaceStatus.OnCourse:
                    LocationUpdate locUpdate = (LocationUpdate)updateMessage;
                    locationOnCourse = locUpdate.LocationOnCourse;
                    break;
                case AthleteRaceStatus.DidNotFinish:
                    // Do nothing
                    break;
                case AthleteRaceStatus.Finished:
                    FinishedUpdate finishUpdate = (FinishedUpdate)updateMessage;
                    officialEndTime = finishUpdate.OfficialEndTime;
                    break;
                default:
                    throw new ApplicationException("Invalid AthleteUpdate type");
            }
            notifyObservers();
        }


        // Decorations
        public virtual Color color { get; set; } = Color.Transparent;
        public virtual float textSize { get; set; }

        private Timer timer;
        public virtual void startTimer()
        {
            timer = new Timer(func, null, 20, 20);
        }

        private void func(object sender)
        {

        }

        public virtual void stopTimer()
        {
            timer?.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
            timer = null;
        }

        private static readonly Color[] PossibleColors = new Color[]
        {
            Color.Bisque,
            Color.Blue,
            Color.BlueViolet,
            Color.Brown,
            Color.BurlyWood,
            Color.CadetBlue,
            Color.Chocolate,
            Color.Coral,
            Color.CornflowerBlue,
            Color.Crimson,
            Color.DarkBlue,
            Color.DarkCyan,
            Color.DarkGoldenrod,
            Color.DarkGreen,
            Color.DarkKhaki,
            Color.DarkOrange,
            Color.DarkOrchid,
            Color.DarkSalmon,
            Color.DarkSeaGreen,
            Color.DarkTurquoise,
            Color.DeepSkyBlue,
            Color.DodgerBlue,
            Color.ForestGreen,
            Color.Gold,
            Color.Goldenrod,
            Color.Green,
            Color.GreenYellow,
            Color.IndianRed,
            Color.Khaki,
            Color.LightGreen
        };

        protected static readonly Random Randomizer = new Random();
        public static Color RandomColor => PossibleColors[Randomizer.Next(0, PossibleColors.Length)];
        public Color getRandomColor()
        {
            return PossibleColors[Randomizer.Next(0, PossibleColors.Length)];
        }
    }
}
