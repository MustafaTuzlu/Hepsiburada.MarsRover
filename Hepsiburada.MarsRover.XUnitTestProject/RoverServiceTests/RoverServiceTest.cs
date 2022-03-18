using FakeItEasy;
using HepsiBurada.MarsRover.Data.Dumy;
using HepsiBurada.MarsRover.Data.RoverModel;
using HepsiBurada.MarsRover.Logic.Invoker.Provider;
using HepsiBurada.MarsRover.Logic.RoverCommand.Provider;
using HepsiBurada.MarsRover.Logic.RoverService;
using HepsiBurada.MarsRover.Logic.RoverService.Provider;
using Xunit;

namespace Hepsiburada.MarsRover.XUnitTestProject.RoverServiceTests
{
    public class RoverServiceTest
    {
        private readonly IInvoker roverInvoker;
        private readonly IRoverService roverService;

        public RoverServiceTest()
        {
            roverInvoker = A.Fake<IInvoker>();
            roverService = new RoverService();
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void MoveRover_Test(bool isCoordinateNull)
        {
            //Arrange
            var xLimit = DummyData.xLimit;
            var yLimit = DummyData.yLimit;

            var currentLocation = DummyData.GetFakeRoverCoordinate();
            var commandText = DummyData.commandText;
            var coordinates = DummyData.GetFakeRoverCoordinate();


            if (!isCoordinateNull)
                A.CallTo(() => roverInvoker.ExecuteRoverCommand(A<IRoverCommand>._, A<RoverCoordinate>._)).ReturnsLazily(() => coordinates);
            else
                A.CallTo(() => roverInvoker.ExecuteRoverCommand(A<IRoverCommand>._, A<RoverCoordinate>._)).ReturnsLazily(() => null);

            //Act
            var result = roverService.MoveRover(xLimit, yLimit, commandText, currentLocation, roverInvoker);

            //Assert
            if (!isCoordinateNull)
            {
                Assert.NotNull(result);
                Assert.Equal(coordinates.XCoordinate, result.XCoordinate);
                Assert.Equal(coordinates.YCoordinate, result.YCoordinate);
                Assert.Equal(coordinates.Direction, result.Direction);
            }
            else
            {
                Assert.Null(result);
            }
        }
    }
}
