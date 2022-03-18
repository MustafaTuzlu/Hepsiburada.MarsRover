using HepsiBurada.MarsRover.Data.Const;
using HepsiBurada.MarsRover.Data.Dumy;
using HepsiBurada.MarsRover.Logic.RoverCommand;
using HepsiBurada.MarsRover.Logic.RoverCommand.Provider;
using Xunit;

namespace Hepsiburada.MarsRover.XUnitTestProject.RoverCommandTests
{
    public class TurnLeftTest
    {
        private readonly IRoverCommand _roverCommand;
        public TurnLeftTest()
        {
            _roverCommand = new TurnLeft();
        }

        [Theory]
        [InlineData(DirectionEnum.N)]
        [InlineData(DirectionEnum.E)]
        [InlineData(DirectionEnum.S)]
        [InlineData(DirectionEnum.W)]
        public void ProcessCommand_Test(DirectionEnum direction)
        {
            var coordinate = DummyData.GetFakeRoverCoordinate();

            switch (direction)
            {
                case DirectionEnum.N:
                    coordinate.Direction = DirectionEnum.N;
                    break;

                case DirectionEnum.E:
                    coordinate.Direction = DirectionEnum.E;
                    break;

                case DirectionEnum.S:
                    coordinate.Direction = DirectionEnum.S;
                    break;

                case DirectionEnum.W:
                    coordinate.Direction = DirectionEnum.W;
                    break;
            }

            var result = _roverCommand.ProcessCommand(coordinate);

            Assert.NotNull(result);
            Assert.Equal(coordinate, result);
        }
    }
}
