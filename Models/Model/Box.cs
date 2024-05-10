using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallesstaldsystem.Model
{
    public class Box
    { 
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Leased { get; set; }

        public Box(int id, string name, bool leased)
        {
            Id = id;
            Name = name;
            Leased = leased;
        }

        public Box(string name,bool leased) 
        { 
            Name = name;
            Leased = leased;
        }
    }
}
