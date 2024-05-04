using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallesstaldsystem.Model
{
    public class Horse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CHRId { get; set; }
        //køn
        //type

        public Paddock Paddock { get; set; }
        public HorseOwner Owner { get; set; }
        public Box Box { get; set; }
        public FeedingScheduel FeedingScheduel { get; set; }

        public List<AddOn> AddOns { get; set; } = new List<AddOn>();
        public List<Deviation> DeviationList { get; set; } = new List<Deviation>();
    }
}
