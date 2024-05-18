using ApplicationLayer.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Controllers
{
    internal class HorseOwnerController : AbstractController<HorseOwner, HorseOwnerRepository>
    {
        internal HorseOwnerController() : base(_dataHandler.HorseOwnerRepository)
        {

        }
    }
}
