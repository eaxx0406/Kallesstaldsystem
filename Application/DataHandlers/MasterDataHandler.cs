using Application.DataHandlers.DomæneDatahandler;
using Application.Repostories;
using Kallesstaldsystem.Model;
using System.Text;
using static Kallesstaldsystem.Model.Horse;

namespace Application.DataHandlers
{
    public class MasterDataHandler
    {
        private AddOnDataHandler _addOnDataHandler = new AddOnDataHandler();
        private BoxDatahandler _boxDataHandler = new BoxDatahandler();
        private DeviationsDatahandler _deviationsDatahandler = new DeviationsDatahandler();
        private FeedingScheduelDataHandler _feedingScheduelDataHandler = new FeedingScheduelDataHandler();
        private HorseDatahandler _horseDataHandler = new HorseDatahandler();
        private HorseOwnerDataHandler _horseOwnerDataHandler = new HorseOwnerDataHandler();
        private PaddockDatahandler _paddockDatahandler = new PaddockDatahandler();
        private StableDatahandler _stableDatahandler = new StableDatahandler();

        public void Read()
        {
            _addOnDataHandler.Read();
            _boxDataHandler.Read();
            _deviationsDatahandler.Read();    
            _feedingScheduelDataHandler.Read();
            _horseDataHandler.Read();
            _horseOwnerDataHandler.Read();
            _paddockDatahandler.Read();
            _stableDatahandler.Read();
        }
        public void Write()
        {
            _boxDataHandler.Write();
            _deviationsDatahandler.Write();
            _feedingScheduelDataHandler.Write();
            _horseDataHandler.Write();
            _horseOwnerDataHandler.Write();
            _paddockDatahandler.Write();
        }

       

        public void ReadOwners()
        {
            //TODO
        }
        public void WriteOwners()
        {
            //TODO
        }



    }
}
