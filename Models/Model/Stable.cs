using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallesstaldsystem.Model
{
    public class Stable
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Box> Boxes { get; set; } = new List<Box>();


        public Stable(int id, string name)
        {
            Id = id;
            Name = name;
        } 
        public Stable(string name)
        {
            Name = name;
        }
    }
}
