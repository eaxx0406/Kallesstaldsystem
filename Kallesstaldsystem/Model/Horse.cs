using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallesstaldsystem.Model
{
    internal class Horse
    {
        public string Name;
        public string CHRId;
        private int _id;
        //køn
        //type

        public Paddock paddock;
        private HorseOwner owner;
        public Box box;
        public FeedingScheduel feedingScheduel;
        List<AddOn> addOns = new List<AddOn>();
        List<Deviation> deviationList = new List<Deviation>();  
    }
}
