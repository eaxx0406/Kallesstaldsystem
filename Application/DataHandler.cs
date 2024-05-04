using Application.Repostories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class DataHandler
    {
        private HorseRepository _horseRepository;

        public DataHandler()
        {
            _horseRepository = new HorseRepository();
        }
        public void Read()
        {

        }
        public void Write() 
        { 

        }
    }
}
