using GreenPowerMonitor.Implementations;
using GreenPowerMonitor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPowerMonitor.Implementations
{
    public class CollitionDetector : ICollitionDetector
    {
        public Cube SetCoordinates(int x, int y, int z, Cube cube)
        {
            cube.SetCoordinates(x, y, z);
            return cube;
        }
           
        public bool DetectCollition(Cube firstCube, Cube secondCube)
        {
            return CubeIntersectForX(firstCube, secondCube) && CubeIntersectForY(firstCube, secondCube) && CubeIntersectForZ(firstCube, secondCube);
        }

        public decimal CalculateVolume(Cube firstCube, Cube secondCube)
        {
            var intersectX = Math.Abs((firstCube.GetpositionX() + (firstCube.width / 2)) - (secondCube.GetpositionX() + (secondCube.width / 2)));

            var intersectY = Math.Abs((firstCube.GetpositionY() + (firstCube.height / 2)) - (secondCube.GetpositionY() + (secondCube.height / 2)));

            var intersectZ = Math.Abs((firstCube.GetpositionZ() + (firstCube.depth / 2)) - (secondCube.GetpositionZ() + (secondCube.depth / 2)));

            return intersectX * intersectY * intersectZ;
        }

        private bool RangeIntersect(decimal min0, decimal max0, decimal min1, decimal max1)
        {
            var result = Math.Max(min0, max0) >= Math.Min(min1, max1) &&
                         Math.Min(min0, max0) <= Math.Max(min1, max1);
            var res = max0 >= min1 && min0 <= max1; 

            return result;
        }

        private bool CubeIntersectForX(Cube firstCube, Cube secondCube)
        {
            var result = this.RangeIntersect(firstCube.GetpositionX() - (firstCube.width / 2), firstCube.GetpositionX() + (firstCube.width / 2),
                secondCube.GetpositionX() - (secondCube.width / 2), secondCube.GetpositionX() + (secondCube.width / 2)); 

            return result;
        }

        private bool CubeIntersectForY(Cube firstCube, Cube secondCube)
        {
            var result = this.RangeIntersect(firstCube.GetpositionY() - (firstCube.height / 2), firstCube.GetpositionY() + (firstCube.height / 2),
                secondCube.GetpositionY() - (secondCube.height / 2), secondCube.GetpositionY() + (secondCube.height / 2));

            return result;
        }

        private bool CubeIntersectForZ(Cube firstCube, Cube secondCube)
        {
            var result = this.RangeIntersect(firstCube.GetpositionZ() - (firstCube.depth / 2), firstCube.GetpositionZ() + (firstCube.depth / 2),
                secondCube.GetpositionZ() - (secondCube.depth / 2), secondCube.GetpositionZ() + (secondCube.depth / 2));

            return result;
        }
    }
}
