using Application.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataHandlers.DomæneDatahandler
{
    internal class PaddockDatahandler
    {
        public PaddockRepository _paddockRepository = new PaddockRepository();
        private static string _filePath = @"C:\Paddock.txt";

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
            foreach (var line in lines)
            {
                string[] values = line.Split('\t');

                int id = int.Parse(values[0]);
                string name = values[1];
                bool leased = Convert.ToBoolean(values[2]);

                Paddock newPaddock = new Paddock(id, name, leased);
                _paddockRepository.Add(newPaddock);
            }
        }

        public void Write()
        {
            CheckIfFileExist(_filePath);
            List<Paddock> lines = (List<Paddock>)_paddockRepository.GetAll();
            foreach (Paddock paddock in lines)
            {
                Console.OutputEncoding = Encoding.UTF8;
                string createText = $"\"{paddock.Id}\"    \"{paddock.Name}\"    \"{paddock.Leased}\"";
                File.AppendAllText(_filePath, Environment.NewLine + createText);
            }
        }
    }
}
