using Application.Repositories;
using Kallesstaldsystem.Model;
using System.Text;

namespace Application.DataHandlers.DomaineDatahandler
{
    internal class StableDatahandler : AbstractDataHandler<StableRepository>
    {
        public StableRepository _stableRepository = new StableRepository();
        private static string _filePath = @"C:\\StableManagementSystem\\stable.txt";

     

        internal override StableRepository Read()
        {
            CheckIfFileExists(_filePath);

            List<string> lines = File.ReadLines(_filePath).ToList();
            //lines.RemoveAt(0);
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
            CheckIfFileExists(_filePath);
            List<Stable> lines = (List<Stable>)_stableRepository.GetAll();
            foreach (Stable stable in lines)
            {
                Console.OutputEncoding = Encoding.UTF8;
                string createText = $"{stable.Id}\t{stable.Name}";
                File.AppendAllText(_filePath, createText + Environment.NewLine);
            }
        }
    }
}
