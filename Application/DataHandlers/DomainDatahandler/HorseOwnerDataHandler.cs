using ApplicationLayer.Repositories;
using Kallesstaldsystem.Model;
using System.Text;

namespace ApplicationLayer.DataHandlers.DomaineDatahandler
{
    public class HorseOwnerDataHandler: AbstractDataHandler<HorseOwnerRepository>
    {

        private HorseOwnerRepository _horseOwnerRepository = new HorseOwnerRepository();
        private static string _filePath = @"C:\\StableManagementSystem\\HorseOwner.txt";

        internal override HorseOwnerRepository Read()
        {
            CheckIfFileExists(_filePath);

            List<string> lines = File.ReadLines(_filePath).ToList();
            //lines.RemoveAt(0);
            foreach (var line in lines)
            {
                string[] values = line.Split('\t');

                int id = int.Parse(values[0]);
                string name = values[1];
                string phone = values[2];

                HorseOwner newOwner = new HorseOwner(id,name,phone);
                _horseOwnerRepository.Add(newOwner);
            }
            return _horseOwnerRepository;
        }
        internal override void Write(HorseOwnerRepository horseOwnerRepository)
        {
            CheckIfFileExists(_filePath);
            List<HorseOwner> lines = (List<HorseOwner>)_horseOwnerRepository.GetAll();
            foreach (HorseOwner horseOwner in lines)
            {
                Console.OutputEncoding = Encoding.UTF8;
                string createText = $"{horseOwner.Id}\t{horseOwner.Name}\t{horseOwner.Phone}";
                File.AppendAllText(_filePath, createText + Environment.NewLine);
            }
        }
    }
}
