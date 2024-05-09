using Application.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controllers
{
    internal class DeviationsController : AbstractController<Deviation, DeviationRepository>
    {
        internal DeviationsController() : base(_dataHandler.DeviationsRepository)
        {

        }
    }
}
