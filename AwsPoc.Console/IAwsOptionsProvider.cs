using System.Threading.Tasks;
using Amazon.Extensions.NETCore.Setup;

namespace AwsPoc.Console
{
    public interface IAwsOptionsProvider
    {
        Task<AWSOptions> GetAwsOptions();
    }
}