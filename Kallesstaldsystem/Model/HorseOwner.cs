using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallesstaldsystem.Model
{
    internal class HorseOwner
    {
        public string Name;
        public string Phone;
        private int _id;

        List<Horse> _horseList;
        List<Paddock> _paddockList;
        List<Box> _boxList;
    }
}
