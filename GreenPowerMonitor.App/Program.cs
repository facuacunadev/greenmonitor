using GreenPowerMonitor.Exceptions;
using GreenPowerMonitor.Implementations;
using System;

namespace GreenPowerMonitor.App
{

    /*
      considering that we have two cubes
      we know that each one has ranges in X
      and in the same way we have ranges for its sides in Y;
      if there is a collision then we also have
      a numerical range for X and Y (also for Z)
     
      if the X or Y ranges do not overlap
      then there is no collision
     
      cubes have a rank in X with a minimum and a maximum
      the same goes for the other Y and Z axes


      position axes are considered from zero (x, y, z)
      to avoid position validations on negative values for movement axes

      so that the cube is not outside the axes you cannot set coordinates
      that leave part of the eyes outside the axes

      because the coordinates are set to the center of the object
      the coordinates cannot be less than half the object, otherwise the cube could
      appear outside the axes
     */



    class Program
    {
        static void Main(string[] args)
        {
            var firstCube = SetCubeData("first cube");
            firstCube = SetCubeCoordinates(firstCube);

            var secondCube = SetCubeData("second cube");
            secondCube = SetCubeCoordinates(firstCube);

            //var firstCube = new Cube(10);
            //var secondCube = new Cube(10);

            var detector = new CollitionDetector();


            //las coordenadas deben al menos siempre mas de la mitad del lado del cubo
            //firstCube = detector.SetCoordinates(25, 20, 20, firstCube);
            //secondCube = detector.SetCoordinates(20, 30, 30, secondCube);

            if (detector.DetectCollition(firstCube, secondCube))
            {
                var overlapVolume = detector.CalculateVolume(firstCube, secondCube);
                Console.WriteLine("The overlap volume is: {0}", overlapVolume);
                throw new CollitionException("Collition detected");
            }
            else
            {
                Console.WriteLine("No collition detected");
                Console.Read();
            }
        }


        static Cube SetCubeData(string cubeName)
        {
            Console.WriteLine("Insert data for the {0}.", cubeName);

            Console.WriteLine("Insert side value:");
            var sideValue = Convert.ToDecimal(Console.ReadLine());

            return new Cube(sideValue);
        }

        static Cube SetCubeCoordinates(Cube cube)
        {
            Console.WriteLine("Insert coordinates for cube:");

            Console.WriteLine("Set position X:");
            var positionX = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Set position Y:");
            var positionY = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Set position Z:");
            var positionZ = Convert.ToInt32(Console.ReadLine());

            cube.SetCoordinates(positionX, positionY, positionZ);
            return cube;
        }
    }
}
