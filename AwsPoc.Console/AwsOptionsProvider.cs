using System.Threading.Tasks;
using Amazon.Extensions.NETCore.Setup;
using Microsoft.Extensions.Configuration;

namespace AwsPoc.Console
{
    public class AwsOptionsProvider : IAwsOptionsProvider
    {
        private readonly IConfiguration _configuration;

        public AwsOptionsProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public Task<AWSOptions> GetAwsOptions()
        {
            return Task.FromResult(_configuration.GetAWSOptions());
        }
    }
}