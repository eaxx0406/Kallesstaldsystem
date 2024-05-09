//using Application.Repositories;
//using Kallesstaldsystem.Model;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Application.Controllers
//{
//    internal class AddOnController : AbstractController<AddOn>
//    {
//        internal override void Add(AddOn model)
//        {
//            _dataHandler.AddOnRepository.Add(model);
//            _dataHandler.Write();
//        }

//        internal override AddOn Get(int id)
//        {
//            AddOn addOn = _dataHandler.AddOnRepository.GetById(id);
//            if (addOn == null) { throw new Exception("AddOn not Found"); }
//            return addOn;
//        }

//        internal override List<AddOn> GetAll()
//        {
//           return _dataHandler.AddOnRepository.GetAll().ToList();

//        }

//        internal override void Remove(int id)
//        {
//            AddOn addOn =_dataHandler.AddOnRepository.GetById(id);
//            if (addOn == null) { throw new Exception("AddOn not Found"); }
//            _dataHandler.AddOnRepository.Remove(addOn);
//            _dataHandler.Write(); 
//        }

//        internal override void Update(AddOn model)
//        {
//            _dataHandler.AddOnRepository.Update(model);
//            _dataHandler.Write();
//        }
//    }
//}
