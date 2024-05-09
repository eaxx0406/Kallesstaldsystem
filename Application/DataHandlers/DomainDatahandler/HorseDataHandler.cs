using Application.Repositories;
using Kallesstaldsystem.Model;
using System.Text;
using static Kallesstaldsystem.Model.Horse;

namespace Application.DataHandlers.DomaineDatahandler
{
    public class HorseDatahandler: AbstractDataHandler<HorseRepository>
    {
        private HorseRepository _horseRepository = new HorseRepository();
        private static string _filePath = @"C:\Horses.txt";

        internal override HorseRepository Read()
        {
            CheckIfFileExists(_filePath);

            List<string> lines = File.ReadLines(_filePath).ToList();
            lines.RemoveAt(0);
            foreach (var line in lines)
            {
                string[] values = line.Split('\t');

                int id = int.Parse(values[0]);
                string name = values[1];
                string chrId = values[2];
                EquineType type = (EquineType)Enum.Parse(typeof(EquineType), values[3]);
                Gender gender = (Gender)Enum.Parse(typeof(Gender), values[4]);
                int paddockId = int.Parse(values[5]);
                int ownerID = int.Parse(values[6]);
                int boxId = int.Parse(values[7]);
                int feedScheduel = int.Parse(values[8]);

                Horse horse = new Horse(id, name, chrId, type, gender);
                _horseRepository.Add(horse);
            }
            return _horseRepository;
        }
        internal override void Write(HorseRepository repository)
        {
            CheckIfFileExists(_filePath);
            List<Horse> lines = repository.GetAll().ToList();
            foreach (Horse horse in lines)
            {
                Console.OutputEncoding = Encoding.UTF8;
                string createText = $"{horse.Id}\t{horse.Name}\t{horse.CHRId}\t{horse.HorseType}\t{horse.HorseGender}\t{horse.PaddockId}\t{horse.OwnerId}\t{horse.BoxId}\t{horse.FeedingScheduelId}";
                File.AppendAllText(_filePath, createText + Environment.NewLine);
            }
        }
    }
}
