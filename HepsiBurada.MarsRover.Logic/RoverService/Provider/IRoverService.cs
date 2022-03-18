using HepsiBurada.MarsRover.Data.RoverModel;
using HepsiBurada.MarsRover.Logic.Invoker.Provider;

namespace HepsiBurada.MarsRover.Logic.RoverService.Provider
{
    public interface IRoverService
    {
        RoverCoordinate MoveRover(int xLimit, int yLimit, string commandText,
            RoverCoordinate currentCoordinate, IInvoker IRoverInvoker);
    }
}
