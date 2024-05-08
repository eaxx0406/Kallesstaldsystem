using Application.Repositories;
using Kallesstaldsystem.Model;

namespace Application.DataHandlers.DomæneDatahandler
{
    internal class AddOnDataHandler: AbstractDataHandler
    {
        public AddOnRepository _addOnRepository = new AddOnRepository();
        private static string _filePath = @"C:\addon.txt";

        
        internal override void Read()
        {
            CheckIfFileExists(_filePath);

            List<string> lines = File.ReadLines(_filePath).ToList();
            lines.RemoveAt(0);
            foreach (string line in lines)
            {
                string[] values = line.Split('\t');

                int id = int.Parse(values[0]);
                string name = values[1];
               
                AddOn addOn = new AddOn(id, name);
                _addOnRepository.Add(addOn);
            }
        }

        internal override void Write()
        {
            throw new NotImplementedException();
        }
    }
}
