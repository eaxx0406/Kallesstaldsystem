using Kallesstaldsystem.Model;

namespace ApplicationLayer.Repositories
{
    public class HorseRepository : IRepository<Horse>
    {
        private List<Horse> _horses { get; set; } = new List<Horse>();
       
        //public HorseRepository()
        //{
        //    Add(new Horse("Pablo", " ", Horse.EquineType.Horse, Horse.Gender.Gelding,1,1,1,1));
        //    Add(new Horse("Trym", " ", Horse.EquineType.Horse, Horse.Gender.Gelding,2,2,2,2));
        //    Add(new Horse("Kasmir", " ", Horse.EquineType.Horse, Horse.Gender.Gelding));
        //    Add(new Horse("Candy", " ", Horse.EquineType.Pony, Horse.Gender.Mare));
        //    Add(new Horse("Gaia", " ", Horse.EquineType.Pony, Horse.Gender.Mare));
        //    Add(new Horse("Dixie", " ", Horse.EquineType.Horse, Horse.Gender.Mare));
        //    Add(new Horse("Chiaro", " ", Horse.EquineType.Horse, Horse.Gender.Gelding));
        //    Add(new Horse("Dee Dee", " ", Horse.EquineType.Horse, Horse.Gender.Mare));
        //    Add(new Horse("Placida", " ", Horse.EquineType.Horse, Horse.Gender.Mare));
        //    Add(new Horse("Combardo", " ", Horse.EquineType.Horse, Horse.Gender.Gelding));
        //    Add(new Horse("Guffy", " ", Horse.EquineType.Pony, Horse.Gender.Gelding));
        //    Add(new Horse("Punktum", " ", Horse.EquineType.Pony, Horse.Gender.Gelding));
        //    Add(new Horse("Barcardi", " ", Horse.EquineType.Pony, Horse.Gender.Gelding));
        //    Add(new Horse("Blue Chip", " ", Horse.EquineType.Horse, Horse.Gender.Gelding));
        //    Add(new Horse("Alf", " ", Horse.EquineType.Horse, Horse.Gender.Gelding,3,3,3,3));
        //    Add(new Horse("Filly", " ", Horse.EquineType.Pony, Horse.Gender.Mare));
        //    Add(new Horse("Prada", " ", Horse.EquineType.Horse, Horse.Gender.Mare));
        //    Add(new Horse("Sorbet", " ", Horse.EquineType.Horse, Horse.Gender.Mare));
        //    Add(new Horse("Frølle", " ", Horse.EquineType.Horse, Horse.Gender.Mare));
        //}
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
