using Kallesstaldsystem.Model;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationLayer.Repositories
{
    public class BoxRepository : IRepository<Box>
    {
        private List<Box> _boxes { get; set; } = new List<Box>();

        public void Add(Box box)
        {
            int maxId = 0;
            if (_boxes.Count > 0)
                maxId = _boxes.Max(b => b.Id);
            box.Id = maxId + 1;
            _boxes.Add(box);
        }

        public void Remove(Box entity)
        {
            _boxes.Remove(entity);
        }

        public IEnumerable<Box> GetAll()
        {
            return _boxes;
        }

        public Box GetById(int id)
        {
            foreach (Box box in _boxes)
            {
                if (box.Id == id) { return box; }
            }
            return null;
        }

        public void Update(Box entity)
        {

            int index = _boxes.FindIndex(e => e.Id == entity.Id);

            _boxes[index] = entity;
        }
    }
}
