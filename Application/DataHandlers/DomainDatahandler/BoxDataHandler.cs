using Application.Repositories;
using Kallesstaldsystem.Model;
using System.Text;

namespace Application.DataHandlers.DomæneDatahandler
{
    internal class BoxDatahandler
    {
        public BoxRepository _boxRepository = new BoxRepository();
        private static string _filePath = @"C:\box.txt";

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
                string name = values[1];
                bool leased = Convert.ToBoolean(values[2]);

                Box box = new Box(id, name, leased);
                _boxRepository.Add(box);
            }
        }

        public void Write()
        {
            CheckIfFileExist(_filePath);
            List<Box> lines = (List<Box>)_boxRepository.GetAll();
            foreach (Box box in lines)
            {
                Console.OutputEncoding = Encoding.UTF8;
                string createText = $"\"{box.Id}\"    \"{box.Name}\"    \"{box.Leased}\"";
                File.AppendAllText(_filePath, Environment.NewLine + createText);
            }
        }
    }
}
