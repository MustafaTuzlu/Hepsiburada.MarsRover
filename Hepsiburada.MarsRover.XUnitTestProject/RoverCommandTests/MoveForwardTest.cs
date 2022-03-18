using HepsiBurada.MarsRover.Data.Const;
using HepsiBurada.MarsRover.Data.Dumy;
using HepsiBurada.MarsRover.Logic.RoverCommand;
using HepsiBurada.MarsRover.Logic.RoverCommand.Provider;
using Xunit;

namespace Hepsiburada.MarsRover.XUnitTestProject.RoverCommandTests
{
    public class MoveForwardTest
    {
        private readonly IRoverCommand _roverCommand;
        private readonly int xLimit;
        private readonly int yLimit;
        public MoveForwardTest()
        {
            xLimit = DummyData.xLimit;
            yLimit = DummyData.yLimit;
            _roverCommand = new MoveForward(xLimit, yLimit);
        }

        [Theory]
        [InlineData(DirectionEnum.N)]
        [InlineData(DirectionEnum.E)]
        [InlineData(DirectionEnum.W)]
        [InlineData(DirectionEnum.S)]
        public void Execute_Test(DirectionEnum direction)
        {
            //Arrange
            var coordinate = DummyData.GetFakeRoverCoordinate();
            switch (direction)
            {
                case DirectionEnum.N:
                    coordinate.Direction = DirectionEnum.N;
                    break;

                case DirectionEnum.E:
                    coordinate.Direction = DirectionEnum.E;
                    break;

                case DirectionEnum.W:
                    coordinate.Direction = DirectionEnum.W;
                    break;

                case DirectionEnum.S:
                    coordinate.Direction = DirectionEnum.S;
                    break;
            }

            var result = _roverCommand.ProcessCommand(coordinate);

            Assert.NotNull(result);
            Assert.Equal(coordinate, result);
        }

        [Theory]
        [InlineData(true, false, false, false)]
        [InlineData(false, true, false, false)]
        [InlineData(false, false, true, false)]
        [InlineData(false, false, false, true)]
        [InlineData(true, true, false, false)]
        [InlineData(true, false, false, true)]
        [InlineData(false, true, true, false)]
        [InlineData(false, false, true, true)]
        public void ExecuteTest_Failure(bool isYExceed, bool isXExceed, bool isYLess, bool isXLess)
        {
            var coordinate = DummyData.GetFakeRoverCoordinate();
            if (isYExceed)
            {
                coordinate.YCoordinate = 6;
                coordinate.Direction = DirectionEnum.N;
            }
            if (isXExceed)
            {
                coordinate.XCoordinate = 6;
                coordinate.Direction = DirectionEnum.E;
            }
            if (isYLess)
            {
                coordinate.YCoordinate = 0;
                coordinate.Direction = DirectionEnum.S;
            }
            if (isXLess)
            {
                coordinate.XCoordinate = 0;
                coordinate.Direction = DirectionEnum.W;
            }

            var result = _roverCommand.ProcessCommand(coordinate);
            Assert.Null(result);
        }
    }
}
