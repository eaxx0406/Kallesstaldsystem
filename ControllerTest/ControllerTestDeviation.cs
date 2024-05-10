using Kallesstaldsystem.Model;
using Application;
using System.ComponentModel.DataAnnotations;
using Application.Controllers;
using Application.DataHandlers;
using System.Reflection;
using static Kallesstaldsystem.Model.Deviation;

namespace ControllerTests
{
    [TestClass]
    public class ControllerTestDeviation

    {
        private Deviation testDeviation1 = new Deviation(1, "Deviation 1", DateTime.Now, DateTime.Now.AddDays(2));
        private Deviation testDeviation2 = new Deviation(2, "Deviation 2", DateTime.Now.AddDays(3), DateTime.Now.AddDays(5));

        [TestInitialize]
        public void TestInitialize()
        {
            DirectoryInfo directory = new DirectoryInfo("c:\\StableManagementSystem\\");
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
            DeviationController._dataHandler = new MasterDataHandler();
        }


        [TestMethod]
        public void TestAddDeviation()
        {
            DeviationController controller = new DeviationController();
            controller.Add(new Deviation("ControllerTest", DateTime.Now, DateTime.Now.AddDays(2)));
            Deviation deviation = controller.Get(1);
            Assert.AreEqual("ControllerTest", deviation.Description);
        }

        [TestMethod]
        public void TestGetAllDeviations()
        {
            DeviationController controller = new DeviationController();
            controller.Add(testDeviation1);
            controller.Add(testDeviation2);
            List<Deviation> deviations = controller.GetAll();
            Assert.AreEqual(2, deviations.Count);
        }

        [TestMethod]
        public void TestRemoveDeviation()
        {
            DeviationController controller = new DeviationController();
            controller.Add(testDeviation1);
            controller.Add(testDeviation2);
            controller.Remove(1);
            List<Deviation> deviations = controller.GetAll();
            Assert.AreEqual(1, deviations.Count);
        }

        [TestMethod]
        public void TestUpdateDeviation()
        {
            DeviationController controller = new DeviationController();
            controller.Add(testDeviation1);
            controller.Add(testDeviation2);
            testDeviation1.Description = "UpdatedTest";
            controller.Update(testDeviation1);
            Deviation deviation = controller.Get(1);
            Assert.AreEqual("UpdatedTest", deviation.Description);
        }

    }
}
