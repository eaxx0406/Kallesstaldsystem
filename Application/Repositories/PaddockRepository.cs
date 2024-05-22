using ApplicationLayer.Repositories;
using Kallesstaldsystem.Model;

namespace ApplicationLayer.Repositories
{
    public class PaddockRepository : IRepository<Paddock>
    {
        private List<Paddock> _paddocks = new List<Paddock>();

        public PaddockRepository() 
        {
            Add(new Paddock("Sandfold 1", true));
            Add(new Paddock("Sandfold 2", true));
            Add(new Paddock("Sandfold 3", true));
            Add(new Paddock("Sandfold 4", false));
            Add(new Paddock("Sandfold 5", false));
            Add(new Paddock("Græsfold 1", true));
            Add(new Paddock("Græsfold 2", false));
            Add(new Paddock("Græsfold 3", true));
            Add(new Paddock("Græsfold 4", false));
            Add(new Paddock("Græsfold 5", true));
            Add(new Paddock("Græsfold 6", true));
            Add(new Paddock("Græsfold 7", false));
            Add(new Paddock("Græsfold 8", true));
            Add(new Paddock("Græsfold 9", true));
            Add(new Paddock("Græsfold 10", true));
            Add(new Paddock("Græsfold 11", false));
            Add(new Paddock("Græsfold 12", true));
            Add(new Paddock("Græsfold 13", true));
            Add(new Paddock("Græsfold 14", false));
            Add(new Paddock("Græsfold 15", false));
            Add(new Paddock("Fælles Hoppefold", true));
            Add(new Paddock("Fælles Hoppefold sommer", true));
            Add(new Paddock("Fælles Vallakfold", true));
            Add(new Paddock("Fælles vallakfold sommer", true));

        }

        public void Add(Paddock entity)
        {
            int maxId = 0;
            if (_paddocks.Count > 0)
                maxId = _paddocks.Max(b => b.Id);
            entity.Id = maxId + 1;
            _paddocks.Add(entity);
        }

        public void Remove(Paddock entity)
        {
            _paddocks.Remove(entity);
        }

        public IEnumerable<Paddock> GetAll()
        {
            return _paddocks;
        }

        public Paddock GetById(int id)
        {
            {
                foreach (Paddock paddock in _paddocks)
                {
                    if (paddock.Id == id) { return paddock; }
                }
                return null;
            }
        }

        public void Update(Paddock entity)
        {
            int index = _paddocks.FindIndex(e => e.Id == entity.Id);

            _paddocks[index] = entity;
        }
    }
}
