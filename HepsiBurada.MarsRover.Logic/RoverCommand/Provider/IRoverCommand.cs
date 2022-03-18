using HepsiBurada.MarsRover.Data.RoverModel;

namespace HepsiBurada.MarsRover.Logic.RoverCommand.Provider
{
    public interface IRoverCommand
    {
        public RoverCoordinate ProcessCommand(RoverCoordinate coordinates);
    }
}
