using Kallesstaldsystem.Model;
using ApplicationLayer;
using System.ComponentModel.DataAnnotations;
using ApplicationLayer.Controllers;
using ApplicationLayer.DataHandlers;
using System.Reflection;
using static Kallesstaldsystem.Model.Horse;

namespace ControllerTests
{
    [TestClass]
    public class ControllerTestsHorse
    {

        private Horse testHorse1 = new Horse(1, "Test1", "123NF456", EquineType.Pony, Gender.Mare);
        private Horse testHorse2 = new Horse(2, "Test2", "123DV456", EquineType.Horse, Gender.Stallion);

        [TestInitialize]
        public void TestInitialize()
        {
            DirectoryInfo directory = new DirectoryInfo("c:\\StableManagementSystem\\");
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
            HorseController._dataHandler = new MasterDataHandler();
        }


        [TestMethod]
        public void TestAddHorse()
        {
            var controller = new HorseController();
            controller.Add(new Horse("ControllerTest", "123IC456", EquineType.Pony, Gender.Gelding));
            var horse = controller.Get(1);
            Assert.AreEqual("ControllerTest", horse.Name);
        }

        [TestMethod]
        public void TestGetAllHorses()
        {
            var controller = new HorseController();
            controller.Add(testHorse1);
            controller.Add(testHorse2);
            List<Horse> horses = controller.GetAll();
            Assert.AreEqual(2, horses.Count);
        }

        [TestMethod]
        public void TestRemoveHorse()
        {
            var controller = new HorseController();
            controller.Add(testHorse1);
            controller.Add(testHorse2);
            controller.Remove(1);
            List<Horse> horses = controller.GetAll();
            Assert.AreEqual(1, horses.Count);
        }

        [TestMethod]
        public void TestUpdateHorse()
        {
            var controller = new HorseController();
            controller.Add(testHorse1);
            controller.Add(testHorse2);
            testHorse1.Name = "UpdatedTest";
            controller.Update(testHorse1);
            var horse = controller.Get(1);
            Assert.AreEqual("UpdatedTest", horse.Name);
        }

    }
}
