using Application.DataHandlers;
using Kallesstaldsystem.Model;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Kallesstaldsystem.Model.HorseOwner;

namespace DataHandlerTests
{
    [TestClass]
    public class HorseOwnerDataHandlerTests
    {
        private HorseOwner testOwner1 = new HorseOwner(1, "John Doe", "88 88 88 88");
        private HorseOwner testOwner2 = new HorseOwner(2, "Jane Smith", "50 50 50 50");

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
        public void UpdateHorseOwners()
        {
            // Arrange
            MasterDataHandler datahandler = new MasterDataHandler();
            datahandler.HorseOwnerRepository.Add(testOwner1);

            // Act
            testOwner1.Name = "UpdatedName";
            datahandler.Write();
            datahandler = new MasterDataHandler();
            HorseOwner updatedOwner = datahandler.HorseOwnerRepository.GetById(1);

            // Assert
            Assert.AreEqual(testOwner1.Name, updatedOwner.Name);
        }

        [TestMethod]
        public void WriteReadHorseOwners()
        {
            // Arrange
            MasterDataHandler datahandler = new MasterDataHandler();
            datahandler.HorseOwnerRepository.Add(testOwner1);
            datahandler.HorseOwnerRepository.Add(testOwner2);

            // Act
            datahandler.Write();
            datahandler = new MasterDataHandler();
            HorseOwner owner1 = datahandler.HorseOwnerRepository.GetById(1);
            HorseOwner owner2 = datahandler.HorseOwnerRepository.GetById(2);

            // Assert
            Assert.AreEqual(testOwner1.ToString(), owner1.ToString());
            Assert.AreEqual(testOwner2.ToString(), owner2.ToString());
        }
    }
}