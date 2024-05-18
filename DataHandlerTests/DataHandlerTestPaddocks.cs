using ApplicationLayer.DataHandlers;
using Kallesstaldsystem.Model;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataHandlerTests
{
    [TestClass]
    public class PaddockDataHandlerTests
    {
        private Paddock testPaddock1 = new Paddock(1, "Paddock 1", true);
        private Paddock testPaddock2 = new Paddock(2, "Paddock 2", false);

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
        public void UpdatePaddocks()
        {
            // Arrange
            MasterDataHandler datahandler = new MasterDataHandler();
            datahandler.PaddockRepository.Add(testPaddock1);

            // Act
            testPaddock1.Name = "Updated Name";
            datahandler.Write();
            datahandler = new MasterDataHandler();
            Paddock updatedPaddock = datahandler.PaddockRepository.GetById(1);

            // Assert
            Assert.AreEqual(testPaddock1.Name, updatedPaddock.Name);
        }

        [TestMethod]
        public void WriteReadPaddocks()
        {
            // Arrange
            MasterDataHandler datahandler = new MasterDataHandler();
            datahandler.PaddockRepository.Add(testPaddock1);
            datahandler.PaddockRepository.Add(testPaddock2);

            // Act
            datahandler.Write();
            datahandler = new MasterDataHandler();
            Paddock paddock1 = datahandler.PaddockRepository.GetById(1);
            Paddock paddock2 = datahandler.PaddockRepository.GetById(2);

            // Assert
            Assert.AreEqual(testPaddock1.ToString(), paddock1.ToString());
            Assert.AreEqual(testPaddock2.ToString(), paddock2.ToString());
        }
    }
}
