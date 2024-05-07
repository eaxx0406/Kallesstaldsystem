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

        public List<int> HorseIds { get; set; } = new List<int>();
        public List<int> PaddockIds { get; set; } = new List<int>();
        public List<int> BoxIds { get; set; } = new List<int>();

        //Basic construktor 
        public HorseOwner(int id, string name, string phone) 
        { 
            Id = id;
            Name = name;
            Phone = phone;
        }

        //Advanced construktor
        public HorseOwner(int id, string name, string phone, List<int> horseIds,List<int>paddockIds, List<int> boxIds) 
        {
            Id=id;
            Name = name;
            Phone = phone;
            HorseIds = horseIds;
            PaddockIds = paddockIds;
            BoxIds = boxIds;
        }
    }
}
