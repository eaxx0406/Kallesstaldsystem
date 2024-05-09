using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controllers
{
    internal class HorseController: AbstractController
    {

        public void AddHorse(Horse horse)
        {
            _dataHandler.HorseRepository.Add(horse);
            _dataHandler.Write();
        }

        public Horse GetHorse(int id)
        {
            Horse horse = _dataHandler.HorseRepository.GetById(id);
            if (horse == null) { throw new Exception("Horse not found"); }
            return horse;
        }
        public List<Horse> GetAllHorses() 
        { 
            return _dataHandler.HorseRepository.GetAll().ToList();
        }
        public void RemoveHorse(int id)
        {
            Horse horse = _dataHandler.HorseRepository.GetById(id);
            if (horse == null) { throw new Exception("Horse not found"); }
            _dataHandler.HorseRepository.Remove(horse);
            _dataHandler.Write();     
        }

        public void UpdateHorse(Horse horse)
        {
            _dataHandler.HorseRepository.Update(horse);
            _dataHandler.Write();   
        }
    }
}
