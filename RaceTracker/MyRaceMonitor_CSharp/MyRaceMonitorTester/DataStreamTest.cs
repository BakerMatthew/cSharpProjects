using Microsoft.VisualStudio.TestTools.UnitTesting;
using RaceData;
using System.IO;
using System.Threading;
using RaceData.Messages;
using System.Collections.Generic;

namespace MyRaceMonitorTester
{
    [TestClass]
    public class DataStreamTest
    {
        [TestMethod]
        public void TheDataStreamTest()
        {
            var fileWriter = new StreamWriter("SimulatedDataSourceTest.csv");
            fileWriter.WriteLine("Registered,1,8/15/2017 7:00:00 AM,FN_F_1,LN_1,F,16");
            fileWriter.WriteLine("Registered,2,8/15/2017 7:00:00 AM,FN_M_2,LN_2,M,56");
            fileWriter.WriteLine("---");
            fileWriter.WriteLine("Started,1,8/15/2017 7:02:00 AM,8/15/2017 7:02:00 AM");
            fileWriter.WriteLine("---");
            fileWriter.WriteLine("OnCourse,1,8/15/2017 7:02:30 AM,276.098203867211");
            fileWriter.WriteLine("Started,2,8/15/2017 7:02:30 AM,8/15/2017 7:02:30 AM");
            fileWriter.WriteLine("---");
            fileWriter.WriteLine("Finished,1,8/15/2017 7:03:00 AM,8/15/2017 7:03:00 AM");
            fileWriter.Close();

            var testUpdateHandler = new TestUpdateHandler();

            var ds = new SimulatedDataSource
            {
                InputFilename = "SimulatedDataSourceTest.csv",
                Handler = testUpdateHandler
            };

            ds.Start();

            // Wait for something about 1/2 second
            Thread.Sleep(500);

            // Two messages should have come in
            Assert.AreEqual(2, testUpdateHandler.NumberRecieved);
            Assert.AreEqual(AthleteRaceStatus.Registered, testUpdateHandler[0].UpdateType);
            Assert.AreEqual(AthleteRaceStatus.Registered, testUpdateHandler[1].UpdateType);

            // Wait for something less than a second
            Thread.Sleep(1000);

            // Another message should have some in
            Assert.AreEqual(3, testUpdateHandler.NumberRecieved);
            Assert.AreEqual(AthleteRaceStatus.Started, testUpdateHandler[2].UpdateType);

            // Wait for something less than a second
            Thread.Sleep(2000);

            // Another message should have some in
            Assert.AreEqual(6, testUpdateHandler.NumberRecieved);
            Assert.AreEqual(AthleteRaceStatus.OnCourse, testUpdateHandler[3].UpdateType);
            Assert.AreEqual(AthleteRaceStatus.Started, testUpdateHandler[4].UpdateType);
            Assert.AreEqual(AthleteRaceStatus.Finished, testUpdateHandler[5].UpdateType);

            ds.Stop();
            Thread.Sleep(1000);
            Assert.AreEqual(6, testUpdateHandler.NumberRecieved);

        }

        class TestUpdateHandler : IAthleteUpdateHandler
        {
            private readonly List<AthleteUpdate> _receivedMessages = new List<AthleteUpdate>();

            public void ProcessUpdate(AthleteUpdate updateMessage)
            {
                _receivedMessages.Add(updateMessage);
            }

            public int NumberRecieved => _receivedMessages.Count;

            public AthleteUpdate this[int index] => _receivedMessages[index];
        }

    }
}

