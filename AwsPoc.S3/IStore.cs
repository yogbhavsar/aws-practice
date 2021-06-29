using System.Threading.Tasks;
using AwsPoc.Common.Models;

namespace AwsPoc.S3
{
    public interface IStore
    {
        Task<Employee> GetEmployeeAsync(string employeeId);
        Task<string> SaveEmployeeAsync(Employee employee);
    }
}