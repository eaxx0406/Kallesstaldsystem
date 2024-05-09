using Kallesstaldsystem.Model;

namespace Application.Repositories
{
    public class HorseRepository : IRepository<Horse>
    {
        private List<Horse> _horses { get; set; } = new List<Horse>();

        public void Add(Horse horse)
        {
            int maxId = 0;
            if (_horses.Count > 0) maxId = _horses.Max(h => h.Id);
            horse.Id = maxId + 1;
            _horses.Add(horse);
        }

        public void Remove(Horse entity)
        {
            _horses.Remove(entity);
        }

        public IEnumerable<Horse> GetAll()
        {
            return _horses;
        }


        public Horse GetById(int id)
        {
            foreach (Horse horse in _horses)
            {
                if (horse.Id == id) { return horse; }
            }
            return null;
        }

        public void Update(Horse entity)
        {
            Horse horse = GetById(entity.Id);

            horse.Name = entity.Name;
            horse.CHRId = entity.CHRId;
            horse.HorseType = entity.HorseType;
            horse.HorseGender = entity.HorseGender;
            horse.PaddockId = entity.PaddockId;
            horse.OwnerId = entity.OwnerId;
            horse.BoxId = entity.BoxId;
            horse.FeedingScheduelId = entity.FeedingScheduelId;
        }
        
    } 
}
