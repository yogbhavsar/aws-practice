using System;
using System.Threading.Tasks;

namespace AwsPoc.Common
{
    public abstract class BaseProgram : IProgram
    {
        protected IServiceProvider ServiceProvider;

        protected BaseProgram(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public abstract Task Run();
    }
}