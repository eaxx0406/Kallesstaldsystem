using ApplicationLayer.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Controllers
{
    public class FeedingScheduelController: AbstractController <FeedingScheduel, FeedingScheduelRepository>
    {
        public FeedingScheduelController() : base(_dataHandler.FeedingScheduelRepository)
        {

        }
    }
}
