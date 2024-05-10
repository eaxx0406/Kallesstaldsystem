using Application.DataHandlers.DomaineDatahandler;
using Application.Repositories;

namespace Application.DataHandlers
{
    public class MasterDataHandler
    {
        internal readonly object repository;
        private AddOnDataHandler _addOnDataHandler = new AddOnDataHandler();
        private BoxDatahandler _boxDataHandler = new BoxDatahandler();
        private DeviationsDatahandler _deviationsDatahandler = new DeviationsDatahandler();
        private FeedingScheduelDataHandler _feedingScheduelDataHandler = new FeedingScheduelDataHandler();
        private HorseDatahandler _horseDataHandler = new HorseDatahandler();
        private HorseOwnerDataHandler _horseOwnerDataHandler = new HorseOwnerDataHandler();
        private PaddockDatahandler _paddockDatahandler = new PaddockDatahandler();
        private StableDatahandler _stableDatahandler = new StableDatahandler();

        internal AddOnRepository AddOnRepository { get; private set; } = new AddOnRepository();
        internal BoxRepository BoxRepository { get; private set; } = new BoxRepository();
        internal DeviationRepository DeviationRepository { get; private set; } = new DeviationRepository();
        internal FeedingScheduelRepository FeedingScheduelRepository { get; private set; } = new FeedingScheduelRepository();
        internal HorseRepository HorseRepository { get; private set; } = new HorseRepository();
        internal HorseOwnerRepository HorseOwnerRepository { get; private set; } = new HorseOwnerRepository();
        internal PaddockRepository PaddockRepository { get; private set; } = new PaddockRepository();
        internal StableRepository StableRepository { get; private set; } = new StableRepository();
        internal DeviationRepository DeviationsRepository { get; set; }

        public MasterDataHandler()
        {
            Read();
        }

        private void Read()
        {
            //AddOnRepository = _addOnDataHandler.Read();
            BoxRepository = _boxDataHandler.Read();
            DeviationRepository = _deviationsDatahandler.Read();
            FeedingScheduelRepository = _feedingScheduelDataHandler.Read();
            HorseRepository = _horseDataHandler.Read();
            HorseOwnerRepository = _horseOwnerDataHandler.Read();
            PaddockRepository = _paddockDatahandler.Read();
            //StableRepository = _stableDatahandler.Read();
        }
        public void Write()
        {

            _boxDataHandler.Write(BoxRepository);
            _deviationsDatahandler.Write(DeviationRepository);
            _feedingScheduelDataHandler.Write(FeedingScheduelRepository);
            _horseDataHandler.Write(HorseRepository);
            _horseOwnerDataHandler.Write(HorseOwnerRepository);
            _paddockDatahandler.Write(PaddockRepository);
        }




    }
}
