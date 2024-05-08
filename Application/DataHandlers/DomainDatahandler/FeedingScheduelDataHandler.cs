using Application.Repositories;
using Kallesstaldsystem.Model;
using System.Text;

namespace Application.DataHandlers.DomæneDatahandler
{
    internal class FeedingScheduelDataHandler: AbstractDataHandler
    {
        public FeedingScheduelRepository _feedingScheduelsRepository = new FeedingScheduelRepository();
        private static string _filePath = @"C:\feedingscheduel.txt";

       
        internal override void Read()
        {
            CheckIfFileExists(_filePath);

            List<string> lines = File.ReadLines(_filePath).ToList();
            lines.RemoveAt(0);
            foreach (string line in lines)
            {
                string[] values = line.Split('\t');

                int id = int.Parse(values[0]);
                string morning = values[1];
                string noon = values[2];
                string evening = values[3];

                FeedingScheduel feedingScheduel = new FeedingScheduel(id,morning,noon,evening);
                _feedingScheduelsRepository.Add(feedingScheduel);
            }
        }
        internal override void Write()
        {
            CheckIfFileExists(_filePath);
            List<FeedingScheduel> lines = (List<FeedingScheduel>)_feedingScheduelsRepository.GetAll();
            foreach (FeedingScheduel feedingScheduel in lines)
            {
                Console.OutputEncoding = Encoding.UTF8;
                string createText = $"\"{feedingScheduel.Id}\"    \"{feedingScheduel.Morning}\"    \"{feedingScheduel.Noon}\"   \"{feedingScheduel.Evening}\"";
                File.AppendAllText(_filePath, Environment.NewLine + createText);
            }
        }
    }
}
