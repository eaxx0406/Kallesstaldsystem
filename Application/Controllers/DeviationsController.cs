//using Kallesstaldsystem.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Controllers
//{
//    internal class DeviationsController: AbstractController<Deviation>
//    {
//        internal override void Add(Deviation model)
//        {
//            _dataHandler.DeviationRepository.Add(model);
//            _dataHandler.Write();
//        }

//        internal override Deviation Get(int id)
//        {
//            Deviation deviation = _dataHandler.DeviationRepository.GetById(id);
//            if (deviation == null) { throw new Exception("AddOn not Found"); }
//            return deviation;
//        }

//        internal override List<Deviation> GetAll()
//        {
//            return _dataHandler.DeviationRepository.GetAll().ToList();

//        }

//        internal override void Remove(int id)
//        {
//            Deviation deviation = _dataHandler.DeviationRepository.GetById(id);
//            if (deviation == null) { throw new Exception("Box not Found"); }
//            _dataHandler.DeviationRepository.Remove(deviation);
//            _dataHandler.Write();
//        }

//        internal override void Update(Deviation model)
//        {
//            _dataHandler.DeviationRepository.Update(model);
//            _dataHandler.Write();
//        }
//    }
//}
