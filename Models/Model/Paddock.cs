using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallesstaldsystem.Model
{
    public class Paddock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Leased { get; set; }

        public Paddock(int id, string name, bool leased)
        {
            Id = id;
            Name = name;
            Leased = leased;
        }
    }
}
