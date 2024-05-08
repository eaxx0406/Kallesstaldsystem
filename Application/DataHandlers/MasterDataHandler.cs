using Application.DataHandlers.DomæneDatahandler;

namespace Application.DataHandlers
{
    public class MasterDataHandler
    {
        private AddOnDataHandler _addOnDataHandler = new AddOnDataHandler();
        private BoxDatahandler _boxDataHandler = new BoxDatahandler();
        private DeviationsDatahandler _deviationsDatahandler = new DeviationsDatahandler();
        private FeedingScheduelDataHandler _feedingScheduelDataHandler = new FeedingScheduelDataHandler();
        public HorseDatahandler HorseDataHandler = new HorseDatahandler();
        public HorseOwnerDataHandler HorseOwnerDataHandler = new HorseOwnerDataHandler();
        private PaddockDatahandler _paddockDatahandler = new PaddockDatahandler();
        private StableDatahandler _stableDatahandler = new StableDatahandler();

        public void Read()
        {
            _addOnDataHandler.Read();
            _boxDataHandler.Read();
            _deviationsDatahandler.Read();    
            _feedingScheduelDataHandler.Read();
            HorseDataHandler.Read();
            HorseOwnerDataHandler.Read();
            _paddockDatahandler.Read();
            _stableDatahandler.Read();
        }
        public void Write()
        {
            _boxDataHandler.Write();
            _deviationsDatahandler.Write();
            _feedingScheduelDataHandler.Write();
            HorseDataHandler.Write();
            HorseOwnerDataHandler.Write();
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
