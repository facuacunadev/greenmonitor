using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPowerMonitor.Interfaces
{
    public interface ICube
    {
       decimal height { get; set; }

       decimal width { get; set; }

       decimal depth { get; set; }

       void SetCoordinates(int x, int y, int z);

       decimal GetVolume();
    }
}
