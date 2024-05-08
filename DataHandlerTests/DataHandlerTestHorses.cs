using Kallesstaldsystem.Model;
using Application.DataHandlers;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;

namespace DataHandlerTestHorseOwner
{
    [TestClass]
    public class DataHandlerTestHorse
    {
        Horse T1, T2;

        MasterDataHandler datahandler = new MasterDataHandler();
        Horse Test1 = new Horse(1, "Test1", "123NF456", Horse.EquineType.Pony, Horse.Gender.Mare);
        Horse Test2 = new Horse(2, "Test2", "123DV456", Horse.EquineType.Horse, Horse.Gender.Stallion);
        

        [TestMethod]
        public void GetTest1Horse()
        {
            //Arrange
            datahandler.HorseDataHandler._horseRepository.Add(Test1);

            //Act
            Horse T1 = datahandler.HorseDataHandler._horseRepository.GetById(1);

            //Assert
            Assert.AreEqual("Hest: id: 1, Navn: Test1, CHRid: 123NF456, Type: Pony, Køn: Mare", T1.ToString());
        }

        [TestMethod]
        public void GetTest2Horse()
        {
            //Arrange
            datahandler.HorseDataHandler._horseRepository.Add(Test2);

            //Act
            Horse T2 = datahandler.HorseDataHandler._horseRepository.GetById(2);

            //Assert
            Assert.AreEqual("Hest: id: 2, Navn: Test2, CHRid: 123DV456, Type: Horse, Køn: Stallion", T2.ToString());
        }
    }
}