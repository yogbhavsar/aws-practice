using Microsoft.Extensions.DependencyInjection;

namespace AwsPoc.Console
{
    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAwsOptionsProvider, AwsOptionsProvider>();
            serviceCollection.AddSingleton(provider =>
            {
                var awsOptionsProvider = (IAwsOptionsProvider)provider.GetService(typeof(IAwsOptionsProvider));
                var options = awsOptionsProvider.GetAwsOptions().GetAwaiter().GetResult();
                return options;
            });
        }
    }
}