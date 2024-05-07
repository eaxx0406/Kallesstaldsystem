﻿using Application.Repositories;
using Kallesstaldsystem.Model;
using System.Text;

namespace Application.DataHandlers
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

                //Liste med hesteIder (adskilt med : måske) 
                string[] horseIds = values[3].Split(':');
                List<int> horseIdsInt = new List<int>();

                foreach (string horseId in horseIds) 
                {
                   int horseIdInt = int.Parse(horseId);
                   horseIdsInt.Add(horseIdInt);
                }
                //Liste med foldIder (adskilt med : måske)
                string[] paddockIds = values[4].Split(':');
                List<int> paddockIdsInt = new List<int>();

                foreach (string paddockId in paddockIds)
                {
                    int paddockIdInt = int.Parse(paddockId);
                    paddockIdsInt.Add(paddockIdInt);
                }

                //Liste med boksIder (adskilt med : måske) 
                string[] boxIds = values[5].Split(':');
                List<int> boxIdsInt = new List<int>();

                foreach (string boxId in boxIds)
                {
                    int boxIdInt = int.Parse(boxId);
                    boxIdsInt.Add(boxIdInt);
                }
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
