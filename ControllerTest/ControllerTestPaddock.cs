using Kallesstaldsystem.Model;
using Application;
using System.ComponentModel.DataAnnotations;
using Application.Controllers;
using Application.DataHandlers;
using System.Reflection;

namespace ControllerTests
{
    [TestClass]
    public class ControllerTestPaddock

    {

        private Paddock testPaddock1 = new Paddock(1, "Test1", true);
        private Paddock testPaddock2 = new Paddock(2, "Test2", false);

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
        public void TestAddPaddock()
        {
            PaddockController controller = new PaddockController();
            controller.Add(new Paddock("ControllerTest",true));
            Paddock paddock = controller.Get(1);
            Assert.AreEqual("ControllerTest", paddock.Name);
        }

        [TestMethod]
        public void TestGetAllPaddocks()
        {
            PaddockController controller = new PaddockController();
            controller.Add(testPaddock1);
            controller.Add(testPaddock2);
            List<Paddock> paddocks = controller.GetAll();
            Assert.AreEqual(2, paddocks.Count);
        }

        [TestMethod]
        public void TestRemovePaddocks()
        {
            PaddockController controller = new PaddockController();
            controller.Add(testPaddock1);
            controller.Add(testPaddock2);
            controller.Remove(1);
            List<Paddock> paddocks = controller.GetAll();
            Assert.AreEqual(1, paddocks.Count);
        }

        [TestMethod]
        public void TestUpdatePaddocks()
        {
            PaddockController controller = new PaddockController();
            controller.Add(testPaddock1);
            controller.Add(testPaddock2);
            testPaddock1.Name = "UpdatedTest";
            controller.Update(testPaddock1);
            Paddock paddock = controller.Get(1);
            Assert.AreEqual("UpdatedTest", paddock.Name);
        }

    }
}
