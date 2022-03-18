using HepsiBurada.MarsRover.Data.RoverModel;
using HepsiBurada.MarsRover.Logic.Invoker.Provider;
using HepsiBurada.MarsRover.Logic.RoverCommand.Provider;

namespace HepsiBurada.MarsRover.Logic.Invoker
{
    public class RoverInvoker : IInvoker
    {
        public RoverCoordinate ExecuteRoverCommand(IRoverCommand command, RoverCoordinate coordinates)
        {
            var newRoverCoordinate = command.ProcessCommand(coordinates);
            return newRoverCoordinate;
        }
    }
}
