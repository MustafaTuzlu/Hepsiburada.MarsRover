using HepsiBurada.MarsRover.Data.RoverModel;
using HepsiBurada.MarsRover.Logic.Invoker.Provider;
using HepsiBurada.MarsRover.Logic.RoverCommand;
using HepsiBurada.MarsRover.Logic.RoverCommand.Provider;
using HepsiBurada.MarsRover.Logic.RoverService.Provider;

namespace HepsiBurada.MarsRover.Logic.RoverService
{
    public class RoverService : IRoverService
    {
        public RoverCoordinate MoveRover(int xLimit, int yLimit, string commandText,
            RoverCoordinate currentCoordinate, IInvoker IRoverInvoker)
        {
            RoverCoordinate newRoverCoordinate =
                new RoverCoordinate(currentCoordinate.XCoordinate, currentCoordinate.YCoordinate, currentCoordinate.Direction);

            IRoverCommand cmd;
            foreach (char cmdChar in commandText)
            {
                switch (cmdChar)
                {
                    case 'M':
                        cmd = new MoveForward(xLimit, yLimit);
                        break;

                    case 'L':
                        cmd = new TurnLeft();
                        break;

                    case 'R':
                        cmd = new TurnRight();
                        break;

                    default:
                        return null;
                }

                var newState = IRoverInvoker.ExecuteRoverCommand(cmd, newRoverCoordinate);

                if (newState == null)
                    return null;

                newRoverCoordinate.Direction = newState.Direction;
                newRoverCoordinate.XCoordinate = newState.XCoordinate;
                newRoverCoordinate.YCoordinate = newState.YCoordinate;
            }
            return newRoverCoordinate;
        }
    }
}
