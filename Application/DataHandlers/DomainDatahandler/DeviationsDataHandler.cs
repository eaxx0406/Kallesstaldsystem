using Application.Repositories;
using Kallesstaldsystem.Model;
using System.Text;

namespace Application.DataHandlers.DomaineDatahandler
{
    internal class DeviationsDatahandler: AbstractDataHandler<DeviationRepository>
    {
        public DeviationRepository _deviationRepository = new DeviationRepository();
        private static string _filePath = @"C:\deviation.txt";

        internal override DeviationRepository Read()
        {
           CheckIfFileExists(_filePath);

            List<string> lines = File.ReadLines(_filePath).ToList();
            lines.RemoveAt(0);
            foreach (string line in lines)
            {
                string[] values = line.Split('\t');

                int id = int.Parse(values[0]);
                string description = values[1];
                DateTime start = DateTime.Parse(values[2]);
                DateTime end = DateTime.Parse(values[3]);

                Deviation deviation = new Deviation(id, description,start,end);
                _deviationRepository.Add(deviation);
            }
            return _deviationRepository;
        }

        internal override void Write(DeviationRepository deviationRepository)
        {
            CheckIfFileExists(_filePath);
            List<Deviation> lines = (List<Deviation>)_deviationRepository.GetAll();
            foreach (Deviation deviation in lines)
            {
                Console.OutputEncoding = Encoding.UTF8;
                string createText = $"\"{deviation.Id}\"    \"{deviation.Description}\"    \"{deviation.Startdate}\"     \"{deviation.Enddate}\"";
                File.AppendAllText(_filePath, Environment.NewLine + createText);
            }
        }
    }
}
