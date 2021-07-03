using System;
using AwsPoc.Common;
using Microsoft.Extensions.Hosting;

namespace AwsPoc.Console
{
    class Program
    {
        private static IProgram GetProgramWithUserInput(IServiceProvider serviceProvider)
        {
            IProgram program;
            do
            {
                System.Console.WriteLine("Enter your choice: ");
                System.Console.WriteLine("1. AWS S3      4. Exit");
                var input = System.Console.ReadLine();
                program = ProgramFactory.GetProgram(input, serviceProvider);
                if (program == null)
                {
                    System.Console.WriteLine("Invalid choice. Please enter correct choice.");
                }
            } while (program == null);

            return program;
        }

        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome to AWS Demo with localstack!");
            var host = CreateHostBuilder().Build();
            var serviceProvider = host.Services;
            var userInputKey = ConsoleKey.Y;
            while (userInputKey == ConsoleKey.Y)
            {
                var program = GetProgramWithUserInput(serviceProvider);
                program.Run().GetAwaiter().GetResult();
                System.Console.WriteLine("Do you want to continue? (Y/N) (Any other keypress will be treated as N)");
                userInputKey = System.Console.ReadKey().Key;
            }
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices(Startup.ConfigureServices)
                .ConfigureServices(S3.DiExtensions.ConfigureServices);
        }
    }
}