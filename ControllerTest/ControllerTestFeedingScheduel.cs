using Kallesstaldsystem.Model;
using ApplicationLayer.Controllers;
using ApplicationLayer.DataHandlers;

namespace ControllerTests
{
    [TestClass]
    public class ControllerTestFeedingScheduel

    {
        private FeedingScheduel testSchedule1 = new FeedingScheduel(1, "100", "200", "100");
        private FeedingScheduel testSchedule2 = new FeedingScheduel(2, "400", "300", "400");

        [TestInitialize]
        public void TestInitialize()
        {
            DirectoryInfo directory = new DirectoryInfo("c:\\StableManagementSystem\\");
            FileInfo[] files = directory.GetFiles();
            foreach (FileInfo file in files)
            {
                file.Delete();
            }
            FeedingScheduelController._dataHandler = new MasterDataHandler();
        }


        [TestMethod]
        public void TestAddFeedingScheduel()
        {
            FeedingScheduelController controller = new FeedingScheduelController();
            controller.Add(new FeedingScheduel(1,"ControllerTest", "nyt foder","Nyt foder"));
            FeedingScheduel feedingScheduel = controller.Get(1);
            Assert.AreEqual("ControllerTest", feedingScheduel.Morning);
        }

        [TestMethod]
        public void TestGetAllFeedingScheduels()
        {
            FeedingScheduelController controller = new FeedingScheduelController();
            controller.Add(testSchedule1);
            controller.Add(testSchedule2);
            List<FeedingScheduel> feedingscheduels = controller.GetAll();
            Assert.AreEqual(2, feedingscheduels.Count);
        }

        [TestMethod]
        public void TestRemoveFeedingScheduel()
        {
            FeedingScheduelController controller = new FeedingScheduelController();
            controller.Add(testSchedule1);
            controller.Add(testSchedule2);
            controller.Remove(1);
            List<FeedingScheduel> feedingScheduels = controller.GetAll();
            Assert.AreEqual(1, feedingScheduels.Count);
        }

        [TestMethod]
        public void TestUpdateFeedingScheduel()
        {
            FeedingScheduelController controller = new FeedingScheduelController();
            controller.Add(testSchedule1);
            controller.Add(testSchedule2);
            testSchedule1.Morning = "UpdatedTest";
            controller.Update(testSchedule1);
            FeedingScheduel feedingScheduel = controller.Get(1);
            Assert.AreEqual("UpdatedTest", feedingScheduel.Morning);
        }

    }
}
