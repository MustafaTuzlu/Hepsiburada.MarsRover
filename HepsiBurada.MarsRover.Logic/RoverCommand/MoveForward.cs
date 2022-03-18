using HepsiBurada.MarsRover.Data.Const;
using HepsiBurada.MarsRover.Data.RoverModel;
using HepsiBurada.MarsRover.Logic.RoverCommand.Provider;
using System;

namespace HepsiBurada.MarsRover.Logic.RoverCommand
{
    public class MoveForward : IRoverCommand
    {
        private readonly int _xLimit, _yLimit;
        public MoveForward(int xLimit, int yLimit)
        {
            if (xLimit < 0 || yLimit < 0)
            {
                System.Console.WriteLine("Coordinate limits cannot be negative number!");
                throw new Exception("Coordinate limits cannot be negative number!");
            }

            _xLimit = xLimit;
            _yLimit = yLimit;
        }

        public RoverCoordinate ProcessCommand(RoverCoordinate roverCoordinate)
        {
            switch (roverCoordinate.Direction)
            {
                case DirectionEnum.N:
                    if (roverCoordinate.YCoordinate >= _yLimit)
                        roverCoordinate = WarnAndReturnNull();
                    else
                        roverCoordinate.YCoordinate++;
                    break;

                case DirectionEnum.E:
                    if (roverCoordinate.XCoordinate >= _xLimit)
                        roverCoordinate = WarnAndReturnNull();
                    else
                        roverCoordinate.XCoordinate++;
                    break;

                case DirectionEnum.S:
                    if (roverCoordinate.YCoordinate != 0)
                        roverCoordinate.YCoordinate--;
                    else
                        roverCoordinate = WarnAndReturnNull();
                    break;

                case DirectionEnum.W:
                    if (roverCoordinate.XCoordinate != 0)
                        roverCoordinate.XCoordinate--;
                    else
                        roverCoordinate = WarnAndReturnNull();
                    break;
            }
            return roverCoordinate;
        }

        private RoverCoordinate WarnAndReturnNull()
        {
            Console.WriteLine("Rover can not move!");
            return null;
        }
    }
}
