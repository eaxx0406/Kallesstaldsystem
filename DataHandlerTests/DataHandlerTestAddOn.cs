using Application.DataHandlers;
using Kallesstaldsystem.Model;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static  Kallesstaldsystem.Model.AddOn;

namespace DataHandlerTests
{
    [TestClass]
    public class AddOnDataHandlerTests
    {
        private AddOn testAddOn1 = new AddOn(6, "AddOn1");
        private AddOn testAddOn2 = new AddOn(7, "AddOn2");

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
            datahandler.AddOnRepository.Add(testAddOn1);

            // Act
            testAddOn1.Name = "UpdatedName";
            datahandler.Write();
            AddOn updatedAddOn = datahandler.AddOnRepository.GetById(6);

            // Assert
            Assert.AreEqual(testAddOn1.Name, updatedAddOn.Name);
        }

        [TestMethod]
        public void WriteReadAddOns()
        {
            // Arrange
            MasterDataHandler datahandler = new MasterDataHandler();
            datahandler.AddOnRepository.Add(testAddOn1);
            datahandler.AddOnRepository.Add(testAddOn2);

            // Act
            datahandler.Write();
            AddOn addOn1 = datahandler.AddOnRepository.GetById(6);
            AddOn addOn2 = datahandler.AddOnRepository.GetById(7);

            // Assert
            Assert.AreEqual(testAddOn1.ToString(), addOn1.ToString());
            Assert.AreEqual(testAddOn2.ToString(), addOn2.ToString());
        }
    }
}
