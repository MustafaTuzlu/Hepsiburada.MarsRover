using FakeItEasy;
using HepsiBurada.MarsRover.Data.Dumy;
using HepsiBurada.MarsRover.Data.RoverModel;
using HepsiBurada.MarsRover.Logic.Invoker;
using HepsiBurada.MarsRover.Logic.Invoker.Provider;
using HepsiBurada.MarsRover.Logic.RoverCommand.Provider;
using Xunit;

namespace Hepsiburada.MarsRover.XUnitTestProject.RoverInvokerTests
{
    public class RoverInvokerTests
    {
        private readonly IRoverCommand roverCommand;
        private readonly IInvoker roverInvoker;

        public RoverInvokerTests()
        {
            roverCommand = A.Fake<IRoverCommand>();
            roverInvoker = new RoverInvoker();
        }

        [Fact]
        public void ExecuteRoverCommand_Test()
        {
            var testCoordinate = DummyData.GetFakeRoverCoordinate();
            A.CallTo(() => roverCommand.ProcessCommand(A<RoverCoordinate>._)).ReturnsLazily(() => testCoordinate);

            var result = roverInvoker.ExecuteRoverCommand(roverCommand, testCoordinate);

            Assert.NotNull(result);
            Assert.Equal(result, testCoordinate);
        }
    }
}
