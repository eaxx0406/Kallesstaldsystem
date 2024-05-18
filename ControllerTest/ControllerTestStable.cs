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
    public class ControllerTestStable

    {
        private Stable testStable1 = new Stable(2, "Test1");
        private Stable testStable2 = new Stable(3, "Test2");

        [TestInitialize]
        public void TestInitialize()
        {
            DirectoryInfo directory = new DirectoryInfo("c:\\StableManagementSystem\\");
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
            StableController._dataHandler = new MasterDataHandler();
        }


        [TestMethod]
        public void TestAddStable()
        {
            StableController controller = new StableController();
            controller.Add(new Stable("ControllerTest"));
            Stable stable = controller.Get(2);
            Assert.AreEqual("ControllerTest", stable.Name);
        }

        [TestMethod]
        public void TestGetAllStables()
        {
            StableController controller = new StableController();
            controller.Add(testStable1);
            controller.Add(testStable2);
            List<Stable> stables = controller.GetAll();
            Assert.AreEqual(3, stables.Count);
        }

        [TestMethod]
        public void TestRemoveStables()
        {
            StableController controller = new StableController();
            controller.Add(testStable1);
            controller.Add(testStable2);
            controller.Remove(1);
            List<Stable> stables = controller.GetAll();
            Assert.AreEqual(2, stables.Count);
        }

        [TestMethod]
        public void TestUpdateBox()
        {
            StableController controller = new StableController();
            controller.Add(testStable1);
            controller.Add(testStable2);
            testStable1.Name = "UpdatedTest";
            controller.Update(testStable1);
            Stable stable = controller.Get(2);
            Assert.AreEqual("UpdatedTest", stable.Name);
        }

    }
}
