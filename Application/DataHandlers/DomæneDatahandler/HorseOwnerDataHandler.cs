using Application.Repositories;
using Kallesstaldsystem.Model;
using System.Text;

namespace Application.DataHandlers.DomæneDatahandler
{
    internal class HorseOwnerDataHandler
    {

        public HorseOwnerRepository _horseOwnerRepository = new HorseOwnerRepository();
        private static string _filePath = @"C:\HorseOwner.txt";

        public void CheckIfFileExist(string FullPath)
        {
            if (!File.Exists(FullPath))
            {
                FileStream fs = File.Create(FullPath);
            }
        }
        public void ReadHorseOwners()
        {
            CheckIfFileExist(_filePath);

            List<string> lines = File.ReadLines(_filePath).ToList();
            lines.RemoveAt(0);
            foreach (var line in lines)
            {
                string[] values = line.Split('\t');

                int id = int.Parse(values[0]);
                string name = values[1];
                string phone = values[2];
            }
        }
        public void WriteHorseOwners()
        {
            CheckIfFileExist(_filePath);
            List<HorseOwner> lines = (List<HorseOwner>)_horseOwnerRepository.GetAll();
            foreach (HorseOwner horseOwner in lines)
            {
                Console.OutputEncoding = Encoding.UTF8;
                string createText = $"\"{horseOwner.Id}\"    \"{horseOwner.Name}\"    \"{horseOwner.Phone}\"";
                File.AppendAllText(_filePath, Environment.NewLine + createText);
            }
        }
    }
}
