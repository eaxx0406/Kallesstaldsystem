﻿using ApplicationLayer.Repositories;
using Kallesstaldsystem.Model;
using System.Text;

namespace ApplicationLayer.DataHandlers.DomaineDatahandler
{
    internal class FeedingScheduelDataHandler: AbstractDataHandler<FeedingScheduelRepository>
    {
        public FeedingScheduelRepository _feedingScheduelsRepository = new FeedingScheduelRepository();
        private static string _filePath = @"C:\\StableManagementSystem\\feedingscheduel.txt";

       
        internal override FeedingScheduelRepository Read()
        {
            CheckIfFileExists(_filePath);

            List<string> lines = File.ReadLines(_filePath).ToList();
            //lines.RemoveAt(0);
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
            return _feedingScheduelsRepository;
        }
        internal override void Write(FeedingScheduelRepository feedingScheduelRepository)
        {
            CheckIfFileExists(_filePath);
            List<FeedingScheduel> lines = (List<FeedingScheduel>)_feedingScheduelsRepository.GetAll();
            foreach (FeedingScheduel feedingScheduel in lines)
            {
                //Console.OutputEncoding = Encoding.UTF8;
                string createText = $"{feedingScheduel.Id}\t{feedingScheduel.Morning}\t{feedingScheduel.Noon}\t{feedingScheduel.Evening}";
                File.AppendAllText(_filePath, createText + Environment.NewLine);
            }
        }
    }
}
