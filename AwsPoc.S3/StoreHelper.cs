using System;
using System.Text;
using System.Threading.Tasks;
using AwsPoc.Common.Models;
using Microsoft.Extensions.DependencyInjection;
using Utf8Json;

namespace AwsPoc.S3
{
    public class StoreHelper
    {
        private static int _counter;
        private readonly IServiceProvider _serviceProvider;

        public StoreHelper(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        internal async Task GetEmployee()
        {
            Console.WriteLine("Enter the employee Id");
            var employeeId = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(employeeId))
            {
                Console.WriteLine("Invalid input. Exiting...");
                return;
            }

            var store = _serviceProvider.GetService<IStore>();
            var employee = await store.GetEmployeeAsync(employeeId);
            if (employee == null)
            {
                Console.WriteLine("Employee not found");
            }

            Console.WriteLine(Encoding.UTF8.GetString(JsonSerializer.Serialize(employee)));
        }

        internal async Task StoreEmployee()
        {
            Console.WriteLine("Storing the employee with the following details: ");
            _counter++;
            var employee = GetEmployeeObject();
            Console.WriteLine(
                $"{nameof(Employee.FirstName)}: {employee.FirstName},   {nameof(Employee.LastName)}: {employee.LastName},    {nameof(Employee.Experience)}: {employee.Experience}");
            var store = _serviceProvider.GetService<IStore>();
            var employeeId = await store.SaveEmployeeAsync(employee);
            Console.WriteLine("EmployeeId: " + (employeeId ?? string.Empty));
        }

        private static Employee GetEmployeeObject()
        {
            return new Employee
            {
                FirstName = "FirstName" + _counter,
                LastName = "LastName" + _counter,
                Experience = 1.1m * _counter,
                JoiningDate = DateTime.Now.AddYears(-_counter)
            };
        }
    }
}