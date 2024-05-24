using Kallesstaldsystem.Model;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationLayer.Repositories
{
    public class HorseOwnerRepository : IRepository<HorseOwner>
    {
        private List<HorseOwner> _horseOwners { get; set; } = new List<HorseOwner>();

        //public HorseOwnerRepository() 
        //{ 
        //    Add(new HorseOwner("Kirstine", "112"));
        //    Add(new HorseOwner("Svend", "114"));
        //    Add(new HorseOwner("Amanda", "88 88 88 88"));
        //    Add(new HorseOwner("Emma", "90 88 97 88"));
        //    Add(new HorseOwner("Claus", "77 88 77 88"));
        //    Add(new HorseOwner("Lene", "12 88 97 88"));
        //    Add(new HorseOwner("Lasse", "30 88 45 87"));
        //    Add(new HorseOwner("Kurt", "54 38 97 88"));
        //    Add(new HorseOwner("Henriette", "60 28 97 88"));
        //    Add(new HorseOwner("Laura", "40 28 97 68"));
        //    Add(new HorseOwner("Michelle", "40 65 97 69"));
        //    Add(new HorseOwner("Sigurd", "44 28 97 76"));
        //}
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
