using ApplicationLayer.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Controllers
{
    internal class BoxController : AbstractController<Box, BoxRepository>
    {
        internal BoxController() : base(_dataHandler.BoxRepository)
        {

        }
    }
}

