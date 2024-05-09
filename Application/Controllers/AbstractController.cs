using Application.DataHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controllers
{
    public abstract class AbstractController
    {
       protected static MasterDataHandler _dataHandler = new MasterDataHandler();
    }
}
