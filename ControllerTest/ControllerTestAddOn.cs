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
    public class ControllerTestAddOn

    {
        private AddOn testAddOn1 = new AddOn(6, "Test1");
        private AddOn testAddOn2 = new AddOn(7, "Test2");

        [TestInitialize]
        public void TestInitialize()
        {
            DirectoryInfo directory = new DirectoryInfo("c:\\StableManagementSystem\\");
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
            AddOnController._dataHandler = new MasterDataHandler();
        }


        [TestMethod]
        public void TestAddAddOn()
        {
            AddOnController controller = new AddOnController();
            controller.Add(new AddOn("ControllerTest"));
            AddOn addOn = controller.Get(6);
            Assert.AreEqual("ControllerTest", addOn.Name);
        }

        [TestMethod]
        public void TestGetAllAddOnes()
        {
            AddOnController controller = new AddOnController();
            controller.Add(testAddOn1);
            controller.Add(testAddOn2);
            List<AddOn> addOnes = controller.GetAll();
            Assert.AreEqual(7, addOnes.Count);
        }

        [TestMethod]
        public void TestRemoveAddOn()
        {
            AddOnController controller = new AddOnController();
            controller.Add(testAddOn1);
            controller.Add(testAddOn2);
            controller.Remove(6);
            List<AddOn> addOnes = controller.GetAll();
            Assert.AreEqual(6, addOnes.Count);
        }

        [TestMethod]
        public void TestUpdateAddOn()
        {
            AddOnController controller = new AddOnController();
            controller.Add(testAddOn1);
            controller.Add(testAddOn2);
            testAddOn1.Name = "UpdatedTest";
            controller.Update(testAddOn1);
            AddOn AddOnes = controller.Get(6);
            Assert.AreEqual("UpdatedTest", AddOnes.Name);
        }

    }
}
