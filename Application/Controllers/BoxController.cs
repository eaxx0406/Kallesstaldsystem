using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controllers
{
    internal class BoxController: AbstractController<Box>
    {
        internal override void Add(Box model)
        {
            _dataHandler.BoxRepository.Add(model);
            _dataHandler.Write();
        }

        internal override Box Get(int id)
        {
            Box box = _dataHandler.BoxRepository.GetById(id);
            if (box == null) { throw new Exception("AddOn not Found"); }
            return box;
        }

        internal override List<Box> GetAll()
        {
            return _dataHandler.BoxRepository.GetAll().ToList();

        }

        internal override void Remove(int id)
        {
            Box box = _dataHandler.BoxRepository.GetById(id);
            if (box == null) { throw new Exception("Box not Found"); }
            _dataHandler.BoxRepository.Remove(box);
            _dataHandler.Write();
        }

        internal override void Update(Box model)
        {
            _dataHandler.BoxRepository.Update(model);
            _dataHandler.Write();
        }
    }
}

