using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataHandlers
{
    internal abstract class AbstractDataHandler
    {
        internal abstract void Read();
        internal abstract void Write();
        protected void CheckIfFileExists(string fullPath)
        { 
            if (!File.Exists(fullPath))
            {
                FileStream fs = File.Create(fullPath);
            } 
        }
    }
}
