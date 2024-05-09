using Application.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controllers
{
    internal class HorseController : AbstractController<Horse, HorseRepository>
    {
        internal HorseController() : base(_dataHandler.HorseRepository)
        {

        }
    }  
}
