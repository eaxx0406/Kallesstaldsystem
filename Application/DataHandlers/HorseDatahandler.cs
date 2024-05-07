﻿using Application.Repostories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kallesstaldsystem.Model.Horse;

namespace Application.DataHandlers
{
    internal class HorseDatahandler
    {
        public HorseRepository _horseRepository = new HorseRepository();
        private static string _filePath = @"C:\Horses.txt";

        public void CheckIfFileExist(string FullPath)
        {
            if (!File.Exists(FullPath))
            {
                FileStream fs = File.Create(FullPath);
            }
        }
        public void ReadHorses()
        {
            CheckIfFileExist(_filePath);

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
        }
        public void WriteHorses()
        {
            CheckIfFileExist(_filePath);
            List<Horse> lines = (List<Horse>)_horseRepository.GetAll();
            foreach (Horse horse in lines)
            {
                Console.OutputEncoding = Encoding.UTF8;
                string createText = $"\"{horse.Id}\"    \"{horse.Name}\"    \"{horse.CHRId}\"    \"{horse.HorseType}\"   \"{horse.HorseGender}\"  \"{horse.PaddockId}\"   \"{horse.OwnerId}\" \"{horse.BoxId}\"   \"{horse.FeedingScheduelId}\"";
                File.AppendAllText(_filePath, Environment.NewLine + createText);
            }
        }
    }
}