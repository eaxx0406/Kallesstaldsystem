using Application.DataHandlers;
using Kallesstaldsystem.Model;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Kallesstaldsystem.Model.FeedingScheduel;

namespace DataHandlerTests
{
    [TestClass]
    public class FeedingScheduleDataHandlerTests
    {
        private FeedingScheduel testSchedule1 = new FeedingScheduel(1, "100","200","100");
        private FeedingScheduel testSchedule2 = new FeedingScheduel(2, "400", "300", "400");

        [TestInitialize]
        public void TestInitialize()
        {
            DirectoryInfo directory = new DirectoryInfo("c:\\StableManagementSystem\\");
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
        }

        [TestMethod]
        public void UpdateFeedingSchedules()
        {
            // Arrange
            MasterDataHandler datahandler = new MasterDataHandler();
            datahandler.FeedingScheduelRepository.Add(testSchedule1);

            // Act
            testSchedule1.Morning = "Nyt foder";
            datahandler.Write();
            datahandler = new MasterDataHandler();
            FeedingScheduel updatedSchedule = datahandler.FeedingScheduelRepository.GetById(1);

            // Assert
            Assert.AreEqual(testSchedule1.Morning, updatedSchedule.Morning);
        }

        [TestMethod]
        public void WriteReadFeedingSchedules()
        {
            // Arrange
            MasterDataHandler datahandler = new MasterDataHandler();
            datahandler.FeedingScheduelRepository.Add(testSchedule1);
            datahandler.FeedingScheduelRepository.Add(testSchedule2);

            // Act
            datahandler.Write();
            datahandler = new MasterDataHandler();
            FeedingScheduel schedule1 = datahandler.FeedingScheduelRepository.GetById(1);
            FeedingScheduel schedule2 = datahandler.FeedingScheduelRepository.GetById(2);

            // Assert
            Assert.AreEqual(testSchedule1.ToString(), schedule1.ToString());
            Assert.AreEqual(testSchedule2.ToString(), schedule2.ToString());
        }
    }
}
