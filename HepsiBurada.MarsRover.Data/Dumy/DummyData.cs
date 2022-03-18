using HepsiBurada.MarsRover.Data.Const;
using HepsiBurada.MarsRover.Data.RoverModel;

namespace HepsiBurada.MarsRover.Data.Dumy
{
    public static class DummyData
    {
        public static int xLimit = 5;

        public static int yLimit = 5;

        public static string commandText = "LMLMLMLMM";

        public static RoverCoordinate GetFakeRoverCoordinate()
        {
            return new RoverCoordinate(1, 2, DirectionEnum.N);
        }
    }
}
