using Application.Repostories;
using Kallesstaldsystem.Model;
using System.Text;
using static Kallesstaldsystem.Model.Horse;

namespace Application
{
    public class DataHandler
    {
        public HorseRepository _horseRepository = new HorseRepository();
        private static string _horseFilePath = @"C:\Horses.txt";

        public void Read()
        {
            this.ReadHorses();

        }
        public void Write()
        {
            this.WriteHorses();
        }

        public void CheckIfFileExist(string FullPath)
        {
            if (! File.Exists(FullPath))
            {
                FileStream fs = File.Create(FullPath);
            }
        }

       
        private void ReadHorses()
        {
            CheckIfFileExist(_horseFilePath);

            List<string> lines = File.ReadLines(_horseFilePath).ToList();
            lines.RemoveAt(0);
            foreach (var line in lines)
            {
                string[] values = line.Split('\t');

                int id = int.Parse(values[0]);
                string name = values[1];
                string chrId = values[2];
                EquineType type = (EquineType)Enum.Parse(typeof(EquineType),values[3]);
                Gender gender = (Gender)Enum.Parse(typeof(Gender), values[4]);
                int paddockId = int.Parse(values[5]);
                int ownerID = int.Parse(values[6]);
                int boxId = int.Parse(values[7]);
                int feedScheduel = int.Parse(values[8]);

                Horse horse = new Horse(id,name,chrId,type,gender);
                _horseRepository.Add(horse);
            }
        }
        public void WriteHorses() 
        {
            CheckIfFileExist(_horseFilePath);
            List<Horse> lines = (List<Horse>)_horseRepository.GetAll();
            foreach (Horse horse in lines)
            {
                Console.OutputEncoding = Encoding.UTF8;
                string createText = $"\"{horse.Id}\"    \"{horse.Name}\"    \"{horse.CHRId}\"    \"{horse.HorseType}\"   \"{horse.HorseGender}\"  \"{horse.PaddockId}\"   \"{horse.OwnerId}\" \"{horse.BoxId}\"   \"{horse.FeedingScheduelId}\"";
                File.AppendAllText(_horseFilePath, Environment.NewLine + createText);
            }
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
