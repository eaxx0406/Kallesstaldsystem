using Application.Repositories;
using Kallesstaldsystem.Model;

namespace Application.Repositories
{
    internal class StableRepository : IRepository<Stable>
    {
        private List<Stable> _stables = new List<Stable>();

        public StableRepository() 
        { 
            Stable stable = new Stable(1,"Kallehavegård");

            _stables.Add(stable);
        }
        public void Add(Stable entity)
        {
            int maxId = 0;
            if (_stables.Count > 0) maxId = _stables.Max(h => h.Id);
            entity.Id = maxId + 1;
            _stables.Add(entity);
        }

        public void Remove(Stable entity)
        {
            _stables.Remove(entity);
        }

        public IEnumerable<Stable> GetAll()
        {
            return _stables;
        }

        public Stable GetById(int id)
        {
            foreach (Stable stable in _stables)
            {
                if (stable.Id == id) { return stable; }
            }
            return null;
        }

        public void Update(Stable entity)
        {
            int index = _stables.FindIndex(e => e.Id == entity.Id);

            _stables[index] = entity;
        }
    }
}
