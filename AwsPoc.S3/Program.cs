using System;
using System.Threading.Tasks;
using AwsPoc.Common;

namespace AwsPoc.S3
{
    public class Program : BaseProgram
    {
        public override async Task Run()
        {
            string input;
            do
            {
                Console.WriteLine("Enter your choice:");
                Console.WriteLine("1. Store an employee       2. Get employee with Id      3.Exit to main menu");
                input = Console.ReadLine();

                var storeHelper = new StoreHelper(ServiceProvider);
                
                switch (input)
                {
                    case "1":
                        await storeHelper.StoreEmployee();
                        break;
                    case "2":
                        await storeHelper.GetEmployee();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Invalid input!");
                        break;
                }
            } while (input != "1" && input != "2");
        }
        
        public Program(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }
}