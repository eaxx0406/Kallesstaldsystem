using ApplicationLayer.DataHandlers;
using Kallesstaldsystem.Model;
using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Kallesstaldsystem.Model.Deviation;

namespace DataHandlerTests
{
    [TestClass]
    public class DeviationDataHandlerTests
    {
        private Deviation testDeviation1 = new Deviation(1, "Deviation 1", DateTime.Now, DateTime.Now.AddDays(2));
        private Deviation testDeviation2 = new Deviation(2, "Deviation 2", DateTime.Now.AddDays(3), DateTime.Now.AddDays(5));

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
        public void UpdateDeviations()
        {
            // Arrange
            MasterDataHandler datahandler = new MasterDataHandler();
            datahandler.DeviationRepository.Add(testDeviation1);

            // Act
            testDeviation1.Description = "Updated Description";
            datahandler.Write();
            datahandler = new MasterDataHandler();
            Deviation updatedDeviation = datahandler.DeviationRepository.GetById(1);

            // Assert
            Assert.AreEqual(testDeviation1.Description, updatedDeviation.Description);
        }

        [TestMethod]
        public void WriteReadDeviations()
        {
            // Arrange
            MasterDataHandler datahandler = new MasterDataHandler();
            datahandler.DeviationRepository.Add(testDeviation1);
            datahandler.DeviationRepository.Add(testDeviation2);

            // Act
            datahandler.Write();
            datahandler = new MasterDataHandler();
            Deviation deviation1 = datahandler.DeviationRepository.GetById(1);
            Deviation deviation2 = datahandler.DeviationRepository.GetById(2);

            // Assert
            Assert.AreEqual(testDeviation1.ToString(), deviation1.ToString());
            Assert.AreEqual(testDeviation2.ToString(), deviation2.ToString());
        }
    }
}
