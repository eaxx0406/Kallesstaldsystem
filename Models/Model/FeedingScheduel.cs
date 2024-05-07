using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallesstaldsystem.Model
{
    public class FeedingScheduel
    {
        public int Id { get; set; }
        public string Morning { get; set; }
        public string Noon { get; set; }
        public string Evening { get; set; }

        public FeedingScheduel(int id, string morning, string noon,string evening) 
        { 
            Id = id;
            Morning = morning;
            Noon = noon;
            Evening = evening;
        }
    }
}
