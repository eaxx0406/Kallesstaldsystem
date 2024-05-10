﻿using Application.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controllers
{
    internal class DeviationController : AbstractController<Deviation, DeviationRepository>
    {
        internal DeviationController() : base(_dataHandler.DeviationRepository)
        {

        }
    }
}



