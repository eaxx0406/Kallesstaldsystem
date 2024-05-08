using Kallesstaldsystem.Model;

namespace Application.Repostories
{
    public class HorseRepository : IRepository<Horse>
    {
        private List<Horse> _horses { get; set; } = new List<Horse>();

        public void Add(Horse horse)
        {
            _horses.Add(horse);
        }

        public void Remove(Horse entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Horse> GetAll()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        
    } 
}
