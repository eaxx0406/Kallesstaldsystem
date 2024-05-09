using Application.Repositories;
using Kallesstaldsystem.Model;

namespace Application.DataHandlers.DomaineDatahandler
{
    internal class AddOnDataHandler: AbstractDataHandler<AddOnRepository>
    {
        public AddOnRepository _addOnRepository = new AddOnRepository();
        private static string _filePath = @"C:\\StableManagementSystem\\addon.txt";

        
        internal override AddOnRepository Read()
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
            return _addOnRepository;
        }

        internal override void Write(AddOnRepository repository)
        {
            throw new NotImplementedException();
        }
    }
}
