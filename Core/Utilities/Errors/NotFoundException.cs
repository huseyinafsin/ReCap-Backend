using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Errors
{
    public class NotFoundException : Exception
    {
        private string v;

        public NotFoundException(string v)
        {
            this.v = v;
        }
    }
}
