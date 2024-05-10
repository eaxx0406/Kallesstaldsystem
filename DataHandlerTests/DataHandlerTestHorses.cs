using Kallesstaldsystem.Model;
using Application.DataHandlers;
using static Kallesstaldsystem.Model.Horse;

namespace DataHandlerTests
{
    [TestClass]
    public class HorseDataHandlerTests
    {

        private Horse testHorse1 = new Horse(1, "Test1", "123NF456", EquineType.Pony, Gender.Mare);
        private Horse testAddOn2 = new Horse(2, "Test2", "123DV456", EquineType.Horse, Gender.Stallion);


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
        public void UpdateHorses()
        {

            //Arrange
            MasterDataHandler datahandler = new MasterDataHandler();
            datahandler.HorseRepository.Add(testHorse1);

            //Act
            testHorse1.Name = "UpdatedName";

            datahandler.Write();

            datahandler = new MasterDataHandler();

            Horse horse1 = datahandler.HorseRepository.GetById(1);

            //Assert
            
            Assert.AreEqual(testHorse1.Name, horse1.Name);

        }



        [TestMethod]
        public void WriteReadHorses()
        {

            //Arrange
            MasterDataHandler datahandler = new MasterDataHandler();

            datahandler.HorseRepository.Add(testHorse1);
            datahandler.HorseRepository.Add(testAddOn2);

            //Act
            datahandler.Write();
            datahandler = new MasterDataHandler();

            Horse horse1 = datahandler.HorseRepository.GetById(1);
            Horse horse2 = datahandler.HorseRepository.GetById(2);

            //Assert
            Assert.AreEqual(testHorse1.ToString(), horse1.ToString());
            Assert.AreEqual(testAddOn2.ToString(), horse2.ToString());

        }

    }
}