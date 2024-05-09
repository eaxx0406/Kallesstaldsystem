using Application.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controllers
{
    internal class HorseController: AbstractController<Horse>
    {
        internal override void Add(Horse horse)
        {
           _dataHandler.HorseRepository.Add(horse);
            _dataHandler.Write();
        }
        
        internal override Horse Get(int id)
        {
            Horse horse = _dataHandler.HorseRepository.GetById(id);
            if (horse == null) { throw new Exception("Horse not found"); }
            return horse;
        }
        internal override List<Horse> GetAll() 
        { 
            return _dataHandler.HorseRepository.GetAll().ToList();
        }
        internal override void Remove(int id)
        {
            Horse horse = _dataHandler.HorseRepository.GetById(id);
            if (horse == null) { throw new Exception("Horse not found"); }
            _dataHandler.HorseRepository.Remove(horse);
            _dataHandler.Write();     
        }

        internal override void Update(Horse horse)
        {
            _dataHandler.HorseRepository.Update(horse);
            _dataHandler.Write();   
        }
    }
}
