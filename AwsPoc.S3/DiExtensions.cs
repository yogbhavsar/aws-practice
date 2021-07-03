using System;
using Microsoft.Extensions.DependencyInjection;

namespace AwsPoc.S3
{
    public static class DiExtensions
    {
        public static void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IStore, S3Store>();
        }
    }
}