using Application.Repositories;
using Kallesstaldsystem.Model;

namespace Application.DataHandlers.DomaineDatahandler
{
    internal class StableDatahandler : AbstractDataHandler<StableRepository>
    {
        public StableRepository _stableRepository = new StableRepository();
        private static string _filePath = @"C:\stable.txt";

     

        internal override StableRepository Read()
        {
            CheckIfFileExists(_filePath);

            List<string> lines = File.ReadLines(_filePath).ToList();
            lines.RemoveAt(0);
            foreach (string line in lines)
            {
                string[] values = line.Split('\t');

                int id = int.Parse(values[0]);
                string name = values[1];

                Stable stable = new Stable(id, name);
                _stableRepository.Add(stable);
            }
            return _stableRepository;
        }

        internal override void Write(StableRepository stableRepository)
        {
            throw new NotImplementedException();
        }
    }
}
