using Kallesstaldsystem.Model;

namespace ApplicationLayer.Repositories
{
    public class HorseRepository : IRepository<Horse>
    {
        private List<Horse> _horses { get; set; } = new List<Horse>();

        public HorseRepository() 
        {
            _horses.Add(new Horse(1, "TestHest", "testCHR", Horse.EquineType.Horse, Horse.Gender.Mare));
        }

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
            int index = _horses.FindIndex(e => e.Id == entity.Id);

            _horses[index] = entity;

        }
        
    } 
}
