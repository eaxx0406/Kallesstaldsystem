using ApplicationLayer.DataHandlers;
using ApplicationLayer.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Controllers
{
    public abstract class AbstractController <TModel, TRepository> where TModel : class where TRepository : IRepository<TModel>
    {
        internal static MasterDataHandler _dataHandler = new MasterDataHandler();
        private TRepository _repository;

        protected AbstractController(TRepository repository)
        {
            _repository = repository;
        }
        internal virtual void Add(TModel model)
        {
            _repository.Add(model);
            _dataHandler.Write();
        }
        internal virtual TModel Get(int id)
        {
            TModel model = _repository.GetById(id);
            if (model == null) { throw new Exception("Item not found"); }
            return model;
        }
        internal virtual List<TModel> GetAll()
        {
            return _repository.GetAll().ToList();
        }

        internal virtual void Remove(int id)
        {
            TModel model = _repository.GetById(id);
            if (model == null) { throw new Exception("Item not found"); }
            _repository.Remove(model);
            _dataHandler.Write();
        }

        internal virtual void Update(TModel model)
        {
            _repository.Update(model);
            _dataHandler.Write();
        }

    }
}
