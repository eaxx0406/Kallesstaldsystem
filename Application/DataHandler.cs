using Application.Repostories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;
using static Kallesstaldsystem.Model.Horse;

namespace Application
{
    internal class DataHandler
    {
        private HorseRepository _horseRepository = new HorseRepository();
        private string PathName = @"C:\Horses.txt";

        public void CheckIfFileExist()
        {
            if (! File.Exists(PathName))
            {
                FileStream fs = File.Create(PathName);
            }
            
        }
        public void Read()
        {
            CheckIfFileExist();

            List<string> lines = File.ReadLines(PathName).ToList();
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
        public void Write() 
        {
            List<Horse> lines = (List<Horse>)_horseRepository.GetAll();
            foreach (Horse horse in lines)
            {
                Console.OutputEncoding = Encoding.UTF8;
                string CreateText = $"\"{horse.Id}\"    \"{horse.Name}\"    \"{horse.CHRId}\"    \"{horse.HorseType}\"   \"{horse.HorseGender}\"  \"{horse.PaddockId}\"   \"{horse.OwnerId}\" \"{horse.BoxId}\"   \"{horse.FeedingScheduelId}\"";

                //File.AppendAllText(StockFilepath, Environment.NewLine + CreateText);
                //BoardGame boardGame = new BoardGame(name, id, genre, min, max, state, price, status);
            }

        }
    }
}
