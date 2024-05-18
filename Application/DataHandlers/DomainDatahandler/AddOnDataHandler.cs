using ApplicationLayer.Repositories;
using Kallesstaldsystem.Model;
using System.Text;

namespace ApplicationLayer.DataHandlers.DomaineDatahandler
{
    internal class AddOnDataHandler: AbstractDataHandler<AddOnRepository>
    {
        public AddOnRepository _addOnRepository = new AddOnRepository();
        private static string _filePath = @"C:\\StableManagementSystem\\addon.txt";

        
        internal override AddOnRepository Read()
        {
            CheckIfFileExists(_filePath);

            List<string> lines = File.ReadLines(_filePath).ToList();
            //lines.RemoveAt(0);
            foreach (string line in lines)
            {
                string[] values = line.Split('\t');

                int id = int.Parse(values[0]);
                string name = values[1];
               
                AddOn addOn = new AddOn(id, name);
                _addOnRepository.Add(addOn);
            }
            return _addOnRepository;
        }

        internal override void Write(AddOnRepository repository)
        {
            CheckIfFileExists(_filePath);
            List<AddOn> lines = (List<AddOn>)_addOnRepository.GetAll();
            foreach (AddOn addOn in lines)
            {
                Console.OutputEncoding = Encoding.UTF8;
                string createText = $"{addOn.Id}\t{addOn.Name}";
                File.AppendAllText(_filePath, createText + Environment.NewLine);
            }
        }
    }
}
