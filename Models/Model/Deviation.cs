using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallesstaldsystem.Model
{
    public class Deviation
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }

    }
}
