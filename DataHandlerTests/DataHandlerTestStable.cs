using ApplicationLayer.DataHandlers;
using Kallesstaldsystem.Model;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static  Kallesstaldsystem.Model.AddOn;

namespace DataHandlerTests
{
    [TestClass]
    public class StableDataHandlerTests
    {
        private Stable testStable1 = new Stable(2, "Stable1");
        private Stable testStable2 = new Stable(3, "Stable2");

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
        public void UpdateAddOn()
        {
            // Arrange
            MasterDataHandler datahandler = new MasterDataHandler();
            datahandler.StableRepository.Add(testStable1);

            // Act
            testStable1.Name = "UpdatedName";
            datahandler.Write();
            //datahandler = new MasterDataHandler();
            Stable updatedStable = datahandler.StableRepository.GetById(2);

            // Assert
            Assert.AreEqual(testStable1.Name, updatedStable.Name);
        }

        [TestMethod]
        public void WriteReadAddOns()
        {
            // Arrange
            MasterDataHandler datahandler = new MasterDataHandler();
            datahandler.StableRepository.Add(testStable1);
            datahandler.StableRepository.Add(testStable2);

            // Act
            datahandler.Write();
            Stable stable1 = datahandler.StableRepository.GetById(2);
            Stable stable2 = datahandler.StableRepository.GetById(3);

            // Assert
            Assert.AreEqual(testStable1.ToString(), stable1.ToString());
            Assert.AreEqual(testStable2.ToString(), stable2.ToString());
        }
    }
}
