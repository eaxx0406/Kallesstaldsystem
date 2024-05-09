using Application.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controllers
{
    internal class PaddockController : AbstractController<Paddock, PaddockRepository>
    {
        internal PaddockController() : base(_dataHandler.PaddockRepository)
        {

        }
    }
}
