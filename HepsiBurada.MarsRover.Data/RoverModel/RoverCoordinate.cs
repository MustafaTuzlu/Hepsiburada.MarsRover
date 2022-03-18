using HepsiBurada.MarsRover.Data.Const;
using System;

namespace HepsiBurada.MarsRover.Data.RoverModel
{
    public class RoverCoordinate
    {
        public RoverCoordinate(int xCoordinate, int yCoordinate, DirectionEnum direction)
        {
            if (xCoordinate < 0 || yCoordinate < 0)
            {
                System.Console.WriteLine("Coordinates cannot be negative number!");
                throw new Exception("Coordinates cannot be negative number!");
            }

            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Direction = direction;
        }

        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public DirectionEnum Direction { get; set; }
    }
}
