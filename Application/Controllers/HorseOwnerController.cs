using ApplicationLayer.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Controllers
{
    public class HorseOwnerController : AbstractController<HorseOwner, HorseOwnerRepository>
    {
        public HorseOwnerController() : base(_dataHandler.HorseOwnerRepository)
        {

        }
    }
}
