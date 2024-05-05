using Kallesstaldsystem.Model;
using Application;
using System.Reflection.Emit;

namespace RepoTest
{
    [TestClass]
    public class DataHandlerTest
    {
        DataHandler datahandler = new DataHandler();
        Horse Test1 = new Horse(1, "Test1", "123NF456", Horse.EquineType.Pony, Horse.Gender.Mare);
        Horse Test2 = new Horse(2, "Test2", "123DV456", Horse.EquineType.Horse, Horse.Gender.Stallion);

        [TestInitialize]

        public void Init()

        {
            Test1 = new Horse(1, "Test1", "123NF456", Horse.EquineType.Pony, Horse.Gender.Mare);
            Test2 = new Horse(2, "Test2", "123DV456", Horse.EquineType.Horse, Horse.Gender.Stallion);
            // Arrange
            datahandler._horseRepository.Add(Test1);
            datahandler._horseRepository.Add(Test2);

            datahandler.Write();
            datahandler.Read();
        }

        [TestMethod]

        public void Test1he()

        {
            // Assert
            Assert.AreEqual("Hest: id: 1, Navn: Test1, CHRid: 123NF456, Type: Pony, Køn:Mare", Test1.ToString());

        }
    }
}