using Application.Repositories;
using Kallesstaldsystem.Model;

namespace Application.Repositories
{
    internal class PaddockRepository : IRepository<Paddock>
    {
        private List<Paddock> _paddocks = new List<Paddock>();
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
