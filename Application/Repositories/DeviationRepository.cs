using Application.Repositories;
using Kallesstaldsystem.Model;

namespace Application.Repositories
{
    internal class DeviationRepository : IRepository<Deviation>
    {
        private List<Deviation> _deviations = new List<Deviation>();
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
