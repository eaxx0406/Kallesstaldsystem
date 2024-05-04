
namespace Application.Repostories
{
    public class HorseRepository : IRepository<Horse>
    {
        private List<Horse> _horses { get; set; }
        public void Add(Horse entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Horse entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Horse> GetAll()
        {
            throw new NotImplementedException();
        }

        public Horse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Horse entity)
        {
            throw new NotImplementedException();
        }
    }
}
