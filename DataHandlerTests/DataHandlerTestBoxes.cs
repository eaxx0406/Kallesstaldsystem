using ApplicationLayer.DataHandlers;
using Kallesstaldsystem.Model;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static  Kallesstaldsystem.Model.Box;

namespace DataHandlerTests
{
    [TestClass]
    public class BoxDataHandlerTests
    {
        private Box testBox1 = new Box(1, "Box 1", true);
        private Box testBox2 = new Box(2, "Box 2", false);

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
        public void UpdateBoxes()
        {
            // Arrange
            MasterDataHandler datahandler = new MasterDataHandler();
            datahandler.BoxRepository.Add(testBox1);

            // Act
            testBox1.Name = "UpdatedName";
            datahandler.Write();
            datahandler = new MasterDataHandler();
            Box updatedBox = datahandler.BoxRepository.GetById(1);

            // Assert
            Assert.AreEqual(testBox1.Name, updatedBox.Name);
        }

        [TestMethod]
        public void WriteReadBoxes()
        {
            // Arrange
            MasterDataHandler datahandler = new MasterDataHandler();
            datahandler.BoxRepository.Add(testBox1);
            datahandler.BoxRepository.Add(testBox2);

            // Act
            datahandler.Write();
            datahandler = new MasterDataHandler();
            Box box1 = datahandler.BoxRepository.GetById(1);
            Box box2 = datahandler.BoxRepository.GetById(2);

            // Assert
            Assert.AreEqual(testBox1.ToString(), box1.ToString());
            Assert.AreEqual(testBox2.ToString(), box2.ToString());
        }
    }
}
