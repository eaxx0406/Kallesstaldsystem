﻿using ApplicationLayer.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Controllers
{
    internal class StableController : AbstractController<Stable, StableRepository>
    {
        internal StableController() : base(_dataHandler.StableRepository)
        {

        } 
    }
}
