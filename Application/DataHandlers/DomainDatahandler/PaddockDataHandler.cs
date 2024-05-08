using Application.Repositories;
using Kallesstaldsystem.Model;
using System.Text;

namespace Application.DataHandlers.DomæneDatahandler
{
    internal class PaddockDatahandler: AbstractDataHandler
    {
        public PaddockRepository _paddockRepository = new PaddockRepository();
        private static string _filePath = @"C:\Paddock.txt";

        internal override void Read()
        {
            CheckIfFileExists(_filePath);

            List<string> lines = File.ReadLines(_filePath).ToList();
            lines.RemoveAt(0);
            foreach (var line in lines)
            {
                string[] values = line.Split('\t');

                int id = int.Parse(values[0]);
                string name = values[1];
                bool leased = Convert.ToBoolean(values[2]);

                Paddock newPaddock = new Paddock(id, name, leased);
                _paddockRepository.Add(newPaddock);
            }
        }

        internal override void Write()
        {
            CheckIfFileExists(_filePath);
            List<Paddock> lines = (List<Paddock>)_paddockRepository.GetAll();
            foreach (Paddock paddock in lines)
            {
                Console.OutputEncoding = Encoding.UTF8;
                string createText = $"\"{paddock.Id}\"    \"{paddock.Name}\"    \"{paddock.Leased}\"";
                File.AppendAllText(_filePath, Environment.NewLine + createText);
            }
        }
    }
}
