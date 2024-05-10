using Application.Repositories;
using Kallesstaldsystem.Model;

namespace Application.Repositories
{
    internal class AddOnRepository : IRepository<AddOn>
    {
        private List<AddOn> _addons { get; set; } = new List<AddOn>();

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
