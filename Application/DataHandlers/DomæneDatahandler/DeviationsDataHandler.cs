using Application.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataHandlers.DomæneDatahandler
{
    internal class DeviationsDatahandler
    {
        public DeviationRepository _deviationRepository = new DeviationRepository();
        private static string _filePath = @"C:\deviation.txt";

        public void CheckIfFileExist(string FullPath)
        {
            if (!File.Exists(FullPath))
            {
                FileStream fs = File.Create(FullPath);
            }
        }
        public void Read()
        {
            CheckIfFileExist(_filePath);

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
        }

        public void Write()
        {
            CheckIfFileExist(_filePath);
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
