using GreenPowerMonitor.Interfaces;
using GreenPowerMonitor.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenPowerMonitor.Implementations
{
    public class Cube : ICube
    {
        private int positionX;
        private int positionY;
        private int positionZ;

        public Cube(decimal side)
        {
            this.height = side;
            this.width = side;
            this.depth = side;
        }

        public void SetCoordinates(int x, int y, int z)
        {
            if (x < (this.width / 2) || y < (this.height / 2) || z < (this.depth / 2))
            {
                //Due the coordinates are in the center of the cube, 
                throw new ValidationException("The coordinates must be at least the half of the cube sides.");               
            }

            if (x < 0 || y < 0 || z < 0)
            {
                throw new ValidationException("Coordinates must be equal to or greater than zero.");             
            }

            this.positionX = x;
            this.positionY = y;
            this.positionZ = z;
        }

        public decimal height { get; set; }

        public decimal width { get; set; }

        public decimal depth { get; set; }


        public decimal GetVolume()
        {
            var volume = this.height * this.width * this.depth;

            return volume;
        }

        public int GetpositionX() { return this.positionX; }

        public int GetpositionY() { return this.positionY; }

        public int GetpositionZ() { return this.positionZ; }
    }
}
