using HepsiBurada.MarsRover.Data.Const;
using HepsiBurada.MarsRover.Data.RoverModel;
using HepsiBurada.MarsRover.Logic.RoverCommand.Provider;

namespace HepsiBurada.MarsRover.Logic.RoverCommand
{
    public class TurnRight : IRoverCommand
    {
        public RoverCoordinate ProcessCommand(RoverCoordinate roverCoordinate)
        {
            switch (roverCoordinate.Direction)
            {
                case DirectionEnum.N:
                    roverCoordinate.Direction = DirectionEnum.E;
                    break;

                case DirectionEnum.E:
                    roverCoordinate.Direction = DirectionEnum.S;
                    break;

                case DirectionEnum.S:
                    roverCoordinate.Direction = DirectionEnum.W;
                    break;

                case DirectionEnum.W:
                    roverCoordinate.Direction = DirectionEnum.N;
                    break;
            }
            return roverCoordinate;
        }
    }
}
