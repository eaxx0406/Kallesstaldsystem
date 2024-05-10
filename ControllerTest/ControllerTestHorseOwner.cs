using Kallesstaldsystem.Model;
using Application;
using System.ComponentModel.DataAnnotations;
using Application.Controllers;
using Application.DataHandlers;
using System.Reflection;
using static Kallesstaldsystem.Model.Horse;

namespace ControllerTests
{
    [TestClass]
    public class ControllerTestHorseOwner
    {
        private HorseOwner testHorseOwner1 = new HorseOwner(1, "Test1","88 88 88 88");
        private HorseOwner testHorseOwner2 = new HorseOwner(2, "Test2","50 50 50 50");

        [TestInitialize]
        public void TestInitialize()
        {
            DirectoryInfo directory = new DirectoryInfo("c:\\StableManagementSystem\\");
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
            HorseOwnerController._dataHandler = new MasterDataHandler();
        }


        [TestMethod]
        public void TestAddHorseOwner()
        {
            HorseOwnerController controller = new HorseOwnerController();
            controller.Add(new HorseOwner("ControllerTest","88 88 88 88"));
            HorseOwner HorseOwner = controller.Get(1);
            Assert.AreEqual("ControllerTest", HorseOwner.Name);
        }

        [TestMethod]
        public void TestGetAllHorseOwners()
        {
            HorseOwnerController controller = new HorseOwnerController();
            controller.Add(testHorseOwner1);
            controller.Add(testHorseOwner2);
            List<HorseOwner> horseowners = controller.GetAll();
            Assert.AreEqual(2, horseowners.Count);
        }

        [TestMethod]
        public void TestRemoveHorseOwner()
        {
            HorseOwnerController controller = new HorseOwnerController();
            controller.Add(testHorseOwner1);
            controller.Add(testHorseOwner2);
            controller.Remove(1);
            List<HorseOwner> horseOwners = controller.GetAll();
            Assert.AreEqual(1, horseOwners.Count);
        }

        [TestMethod]
        public void TestUpdateHorseOwner()
        {
            HorseOwnerController controller = new HorseOwnerController();
            controller.Add(testHorseOwner1);
            controller.Add(testHorseOwner2);
            testHorseOwner1.Name = "UpdatedTest";
            controller.Update(testHorseOwner1);
            HorseOwner horseOwner = controller.Get(1);
            Assert.AreEqual("UpdatedTest", horseOwner.Name);
        }

    }
}
