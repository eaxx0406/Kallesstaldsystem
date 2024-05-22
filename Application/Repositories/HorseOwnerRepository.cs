using Kallesstaldsystem.Model;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationLayer.Repositories
{
    public class HorseOwnerRepository : IRepository<HorseOwner>
    {
        private List<HorseOwner> _horseOwners { get; set; } = new List<HorseOwner>();

        public HorseOwnerRepository() 
        { 
            Add(new HorseOwner("Kirstine Qra", "112"));
            Add(new HorseOwner("Svend", "114"));
        }
        public void Add(HorseOwner horseOwner)
        {
            int maxId = 0;
            if (_horseOwners.Count > 0)
                maxId = _horseOwners.Max(h => h.Id);
            horseOwner.Id = maxId + 1;
            _horseOwners.Add(horseOwner);
        }

        public void Remove(HorseOwner entity)
        {
            _horseOwners.Remove(entity);
        }

        public IEnumerable<HorseOwner> GetAll()
        {
            return _horseOwners;
        }

        public HorseOwner GetById(int id)
        {
            foreach (HorseOwner horseOwner in _horseOwners)
            {
                if (horseOwner.Id == id)
                    return horseOwner;
            }
            return null;
        }

        public void Update(HorseOwner entity)
        {
            int index = _horseOwners.FindIndex(e => e.Id == entity.Id);
            _horseOwners[index] = entity;
        }
    }
}
