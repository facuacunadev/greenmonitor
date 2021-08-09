using GreenPowerMonitor.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPowerMonitor.Interfaces
{
    public interface ICollitionDetector
    {
        Cube SetCoordinates(int x, int y, int z, Cube cube);

        bool DetectCollition(Cube firstCube, Cube secondCube);

        decimal CalculateVolume(Cube firstCube, Cube secondCube);
    }
}
