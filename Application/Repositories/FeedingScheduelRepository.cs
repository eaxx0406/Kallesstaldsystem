using Application.Repositories;
using Kallesstaldsystem.Model;

namespace Application.Repositories
{
    internal class FeedingScheduelRepository : IRepository<FeedingScheduel>
    {
        private List<FeedingScheduel> _feedingScheduels= new List<FeedingScheduel>();
        public void Add(FeedingScheduel entity)
        {
            int MaxId = 0;
            if (_feedingScheduels.Count > 0 ) 
            { 
                MaxId = _feedingScheduels.Max(h => h.Id);
            }
            entity.Id = MaxId + 1;
            _feedingScheduels.Add(entity);
        }

        public void Remove(FeedingScheduel entity)
        {
            _feedingScheduels.Remove(entity);  
        }

        public IEnumerable<FeedingScheduel> GetAll()
        {
            return _feedingScheduels;
        }

        public FeedingScheduel GetById(int id)
        {
            foreach (FeedingScheduel feedingScheduel in _feedingScheduels)
            {
                if (feedingScheduel.Id == id)
                    return feedingScheduel;
            }
            return null;
        }
        public void Update(FeedingScheduel entity)
        {
            int index = _feedingScheduels.FindIndex(e => e.Id == entity.Id);
            _feedingScheduels[index] = entity;
        }
    }
}
