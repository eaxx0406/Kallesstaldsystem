using Application.DataHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public abstract class AbstractController <TModel> 
    {
        protected static MasterDataHandler _dataHandler = new MasterDataHandler();


        internal abstract void Add(TModel model);
        internal abstract TModel Get(int id);
        internal abstract List<TModel> GetAll();

        internal abstract void Remove(int id);

        internal abstract void Update(TModel model);

    }
}
