using Application.Repositories;
using Kallesstaldsystem.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Controllers
{
    internal class AddOnController : AbstractController<AddOn,AddOnRepository>
    {
        internal AddOnController() : base(_dataHandler.AddOnRepository)
        {

        }
    }
}
