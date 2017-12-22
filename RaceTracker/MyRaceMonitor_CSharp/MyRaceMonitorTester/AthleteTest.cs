using System;
using System.Drawing;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.subject.impl;
using RaceData;
using RaceData.Messages;

namespace MyRaceMonitorTester
{
    [TestClass]
    public class AthleteTest
    {
        [TestMethod]
        public void TheAthleteConstructorTest()
        {
            Athlete ath = new Athlete()
            {
                bibNumber = 2,
                firstName = "Billy",
                lastName = "Joel",
                gender = "M",
                age = 73,
                status = AthleteRaceStatus.Started,
                timestamp = null,
                officialStartTime = null,
                officialEndTime = null,
                locationOnCourse = 123.456
            };

            Assert.AreEqual(2, ath.bibNumber);
            Assert.AreEqual("Billy", ath.firstName);
            Assert.AreEqual("Joel", ath.lastName);
            Assert.AreEqual("M", ath.gender);
            Assert.AreEqual(73, ath.age);
            Assert.AreEqual(AthleteRaceStatus.Started, ath.status);
            Assert.AreEqual(null, ath.timestamp);
            Assert.AreEqual(null, ath.officialStartTime);
            Assert.AreEqual(null, ath.officialEndTime);
            Assert.AreEqual(123.456, ath.locationOnCourse);

            AthleteUpdate update = new RegistrationUpdate()
            {
                BibNumber = 2,
                UpdateType = AthleteRaceStatus.Registered,
                Timestamp = new DateTime(2000, 1, 1)
            };

            ath.updateStats(update);


            Assert.AreEqual(2, ath.bibNumber);
            Assert.AreEqual(AthleteRaceStatus.Registered, ath.status);
            Assert.AreEqual(new DateTime(2000, 1, 1), ath.timestamp);
        }
    }
}
