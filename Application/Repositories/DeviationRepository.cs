using ApplicationLayer.Repositories;
using Kallesstaldsystem.Model;

namespace ApplicationLayer.Repositories
{
    public class DeviationRepository : IRepository<Deviation>
    {
        private List<Deviation> _deviations { get; set; } = new List<Deviation>();

        //public DeviationRepository() 
        //{
        //    Add(new Deviation("Blue Chip skal blive Inde, han får smed", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(2)));
        //    Add(new Deviation("Dee dee skal ikke have gamacher af", DateTime.Now.AddDays(2), DateTime.Now.AddDays(2).AddHours(4)));
        //    Add(new Deviation("Prada skal have fluemaske på", DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddHours(3)));
           
        //}
        public void Add(Deviation entity)
        {
            int maxId = 0;
            if (_deviations.Count > 0)
                maxId = _deviations.Max(b => b.Id);
            entity.Id = maxId + 1;
            _deviations.Add(entity);
        }

        public IEnumerable<Deviation> GetAll()
        {
            return _deviations;
        }

        public Deviation GetById(int id)
        {
            foreach (Deviation deviation in _deviations)
            {
                if (deviation.Id == id) { return deviation; }
            }
            return null;
        }

        public void Remove(Deviation entity)
        {
            _deviations.Remove(entity);
        }

        public void Update(Deviation entity)
        {
            int index = _deviations.FindIndex(e => e.Id == entity.Id);

            _deviations[index] = entity;
        }
    }
}
