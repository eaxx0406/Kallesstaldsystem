using ApplicationLayer.Repositories;
using Kallesstaldsystem.Model;

namespace ApplicationLayer.Repositories
{
    internal class AddOnRepository : IRepository<AddOn>
    {
        private List<AddOn> _addons { get; set; } = new List<AddOn>();

        public AddOnRepository() 
        {
            //mangler lige en oversættelse//TODO
            AddOn indlukHverdage = new AddOn(1, "Indluk i hverdage ");
            AddOn udlukWeekend = new AddOn(2, "Udluk i weekenden");
            AddOn indlukWeekend = new AddOn(3,"Indluk i weekend");
            AddOn klokkerPå = new AddOn(4, "Klokker på");
            AddOn klokkerAf = new AddOn(5, "Klokker af");

            _addons.Add(indlukHverdage);
            _addons.Add(udlukWeekend);
            _addons.Add(indlukWeekend);
            _addons.Add(klokkerPå);
            _addons.Add(klokkerAf);
        }

        public void Add(AddOn entity)
        {
            int maxId = 0;
            if (_addons.Count > 0) maxId = _addons.Max(h => h.Id);
            entity.Id = maxId + 1;
            _addons.Add(entity);
        }

        public void Remove(AddOn entity)
        {
            _addons.Remove(entity);
        }

        public AddOn GetById(int id)
        {
            foreach (AddOn addOn in _addons)
            {
                if (addOn.Id == id) { return addOn; }
            }
            return null;
        }

        public IEnumerable<AddOn> GetAll()
        {
            return _addons;
        }

        public void Update(AddOn entity)
        {
            int index = _addons.FindIndex(e => e.Id == entity.Id);

            _addons[index] = entity;
        }
    }
}
