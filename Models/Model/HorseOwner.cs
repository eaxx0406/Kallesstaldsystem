using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallesstaldsystem.Model
{
    public class HorseOwner
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string Phone { get; set; }

        public List<Horse> HorseList { get; set; } = new List<Horse>();
        public List<Paddock> PaddockList { get; set; } = new List<Paddock>();
        public List<Box> BoxList { get; set; } = new List<Box>();
    }
}
