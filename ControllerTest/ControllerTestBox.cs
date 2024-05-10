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
    public class ControllerTestBox

    {
        private Box testBox1 = new Box(1, "Test1", true);
        private Box testBox2 = new Box(2, "Test2", false);

        [TestInitialize]
        public void TestInitialize()
        {
            DirectoryInfo directory = new DirectoryInfo("c:\\StableManagementSystem\\");
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
            BoxController._dataHandler = new MasterDataHandler();
        }


        [TestMethod]
        public void TestAddBox()
        {
            BoxController controller = new BoxController();
            controller.Add(new Box("ControllerTest",true));
            Box box = controller.Get(1);
            Assert.AreEqual("ControllerTest", box.Name);
        }

        [TestMethod]
        public void TestGetAllBoxes()
        {
            BoxController controller = new BoxController();
            controller.Add(testBox1);
            controller.Add(testBox2);
            List<Box> boxes = controller.GetAll();
            Assert.AreEqual(2, boxes.Count);
        }

        [TestMethod]
        public void TestRemoveBox()
        {
            BoxController controller = new BoxController();
            controller.Add(testBox1);
            controller.Add(testBox2);
            controller.Remove(1);
            List<Box> paddocks = controller.GetAll();
            Assert.AreEqual(1, paddocks.Count);
        }

        [TestMethod]
        public void TestUpdateBox()
        {
            BoxController controller = new BoxController();
            controller.Add(testBox1);
            controller.Add(testBox2);
            testBox1.Name = "UpdatedTest";
            controller.Update(testBox1);
            Box boxes = controller.Get(1);
            Assert.AreEqual("UpdatedTest", boxes.Name);
        }

    }
}
