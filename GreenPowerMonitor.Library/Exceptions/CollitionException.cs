using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPowerMonitor.Exceptions
{
    public class CollitionException : Exception
    {
        public CollitionException(string message) : base(message)
        {

        }
    }
}
