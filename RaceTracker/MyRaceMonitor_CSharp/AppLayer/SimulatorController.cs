using System.Threading;
using RaceData;
using AppLayer.GUI;
using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace AppLayer
{
    public class SimulatorController
    {
        private string trackFileName;

        private SimulatedDataSource _simulatedData;
        private ControlForm control;

        private List<RaceEvent> raceEvents = new List<RaceEvent> {
            new RaceEvent {
                Id = 1,
                Title = "Benson TT",
                StartDateTime = new DateTime(2017, 8, 15, 7, 0, 0)
            }, new RaceEvent {
                Id = 2,
                Title = "Cache Valley Century",
                StartDateTime = new DateTime(2017, 8, 15, 7, 0, 0)
            }
        };
        private List<RaceCourse> raceCourses = new List<RaceCourse> {
            new RaceCourse {
                Id = 1,
                Name = "Benson Loop",
                TotalDistance = 16090
            }, new RaceCourse {
                Id = 2,
                Name = "Cache Valley Circuit",
                TotalDistance = 160934
            }
        };
        static private List<string> tracks = new List<string> {
            "../../../SimulationData/Short Race Simulation-01.csv",
            "../../../SimulationData/Century Simulation-01.csv"
        };
        private int choice;

        /// <summary>
        /// Ask for user input to determine which track to simulate
        /// </summary>
        public void Setup()
        {
            Console.WriteLine("Courses available for simulation:");
            for (int index = 0; index < raceEvents.Count && index < raceCourses.Count; index += 1)
            {
                Console.WriteLine((index + 1).ToString() + ") Event: " + raceEvents[index].Title + ", Scheduled to start at: " + raceEvents[index].StartDateTime.ToShortDateString());
                Console.WriteLine("  -Course: " + raceCourses[index].Name + ", Total Length: " + raceCourses[index].TotalDistance.ToString());
            }
            do
            {
                Console.Write("Input which index you would like to simulate, e.g. 1: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("");
            } while (choice <= 0 || choice > raceEvents.Count);
            trackFileName = tracks[choice - 1];
            Console.WriteLine("Setting up simulator...");
        }

        /// <summary>
        /// Start the simulation with the provided course from Setup()
        /// </summary>
        public void Run()
        {
            control = new ControlForm(raceCourses[choice-1].TotalDistance);
            _simulatedData = new SimulatedDataSource()
            {
                InputFilename = trackFileName,
                Handler = control
            };

            _simulatedData.Start();
            Application.Run(control);

            // Run simulator for RUN_TIME_IN_MINUTES
            const int RUN_TIME_IN_MINUTES = 3;
            Thread.Sleep(RUN_TIME_IN_MINUTES * 6000);

            _simulatedData.Stop();
        }
    }
}
