using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kallesstaldsystem.Model
{
    public class AddOn
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
        public AddOn(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public AddOn(string name) 
        {
            Name = name;
        }
    }
}
