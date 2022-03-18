using HepsiBurada.MarsRover.Data.Const;
using HepsiBurada.MarsRover.Data.RoverModel;
using HepsiBurada.MarsRover.Logic.Invoker;
using HepsiBurada.MarsRover.Logic.Invoker.Provider;
using HepsiBurada.MarsRover.Logic.RoverService;
using HepsiBurada.MarsRover.Logic.RoverService.Provider;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace HepsiBurada.MarsRover.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hepsiburada.MarsRover Project by Mustafa Tuzlu\n");

            string limits = Console.ReadLine();
            int xLimit = Convert.ToInt16(limits.Split(' ')[0]);
            int yLimit = Convert.ToInt16(limits.Split(' ')[1]);

            RoverCoordinate currentCoordinate = GetCoordinateFromText(Console.ReadLine());

            string commandText = Console.ReadLine();


            var serviceProvider = GetServiceProvider();
            var marsRoverService = serviceProvider.GetService<IRoverService>();
            var marsRoverInvoker = serviceProvider.GetService<IInvoker>();

            var newCoordinate = marsRoverService.MoveRover(xLimit, yLimit, commandText, currentCoordinate, marsRoverInvoker);

            if (newCoordinate != null)
                Console.WriteLine("\n" + newCoordinate.XCoordinate +
                    " " + newCoordinate.YCoordinate +
                    " " + newCoordinate.Direction);
            else
                Console.WriteLine("Fail! Check Request Inputs!");

            serviceProvider.Dispose();
        }
        private static ServiceProvider GetServiceProvider()
        {
            var services = new ServiceCollection()
                .AddSingleton<IRoverService, RoverService>()
                .AddSingleton<IInvoker, RoverInvoker>();

            return services.BuildServiceProvider(true);
        }
        private static RoverCoordinate GetCoordinateFromText(string currentCoordinateText)
        {
            var currentCoordinateArray = currentCoordinateText.Split(' ');
            return new RoverCoordinate(
                Convert.ToInt32(currentCoordinateArray[0]),
                Convert.ToInt32(currentCoordinateArray[1]),
                currentCoordinateArray[2].ToEnumValue<DirectionEnum>());
        }
    }
}
