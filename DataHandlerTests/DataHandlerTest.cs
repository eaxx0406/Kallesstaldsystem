using Kallesstaldsystem.Model;
using Application.DataHandlers;

namespace DataHandlerTests
{
    [TestClass]
    public class DataHandlerTest
    {
        MasterDataHandler datahandler = new MasterDataHandler();
        Horse Test1 = new Horse(1, "Test1", "123NF456", Horse.EquineType.Pony, Horse.Gender.Mare);
        Horse Test2 = new Horse(2, "Test2", "123DV456", Horse.EquineType.Horse, Horse.Gender.Stallion);

        public void Init()

        {
            Test1 = new Horse(1, "Test1", "123NF456", Horse.EquineType.Pony, Horse.Gender.Mare);
            Test2 = new Horse(2, "Test2", "123DV456", Horse.EquineType.Horse, Horse.Gender.Stallion);
            // Arrange
            datahandler.HorseDataHandler._horseRepository.Add(Test1);
            datahandler.HorseDataHandler._horseRepository.Add(Test2);

            datahandler.Write();
            datahandler.Read();
            datahandler.HorseDataHandler._horseRepository.GetById(1);
        }


        [TestMethod]
        public void GetTest1Horse()
        {
            Assert.AreEqual("Hest: id: 1, Navn: Test1, CHRid: 123NF456, Type: Pony, Køn: Mare", Test1.ToString());
        }

        [TestMethod]
        public void GetTest2Horse()
        {
            Assert.AreEqual("Hest: id: 2, Navn: Test2, CHRid: 123DV456, Type: Horse, Køn: Stallion", Test2.ToString());
        }
    }
}