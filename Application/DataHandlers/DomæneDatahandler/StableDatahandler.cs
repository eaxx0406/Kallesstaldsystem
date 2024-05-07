using Application.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataHandlers.DomæneDatahandler
{
    internal class StableDatahandler
    {
        public StableRepository _stableRepository = new StableRepository();
        private static string _filePath = @"C:\stable.txt";

        public void CheckIfFileExist(string FullPath)
        {
            if (!File.Exists(FullPath))
            {
                FileStream fs = File.Create(FullPath);
            }
        }
        public void ReadStables()
        {
            CheckIfFileExist(_filePath);

            List<string> lines = File.ReadLines(_filePath).ToList();
            lines.RemoveAt(0);
            foreach (string line in lines)
            {
                string[] values = line.Split('\t');

                int id = int.Parse(values[0]);
                string name = values[1];

                Stable stable = new Stable(id, name);
                _stableRepository.Add(stable);
            }
        }
    }
}
