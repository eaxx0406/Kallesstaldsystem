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

        public Deviation(int id,string description,DateTime start,DateTime end) 
        {
            Id = id; 
            Description = description;
            Startdate = start;
            Enddate = end;

        }
    }
}
