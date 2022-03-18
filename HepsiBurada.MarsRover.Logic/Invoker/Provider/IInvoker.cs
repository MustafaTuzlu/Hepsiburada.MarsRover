using HepsiBurada.MarsRover.Data.RoverModel;
using HepsiBurada.MarsRover.Logic.RoverCommand.Provider;

namespace HepsiBurada.MarsRover.Logic.Invoker.Provider
{
    public interface IInvoker
    {
        RoverCoordinate ExecuteRoverCommand(IRoverCommand command, RoverCoordinate coordinates);
    }
}
