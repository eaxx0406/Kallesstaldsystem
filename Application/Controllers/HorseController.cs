using ApplicationLayer.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Controllers
{
    public class HorseController : AbstractController<Horse, HorseRepository>
    {
        public HorseController() : base(_dataHandler.HorseRepository)
        {

        }
    }  
}
