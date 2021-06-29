using System;
using AwsPoc.Common;

namespace AwsPoc.Console
{
    public static class ProgramFactory
    {
        public static IProgram GetProgram(string input, IServiceProvider serviceProvider)
        {
            return input switch
            {
                "1" => new S3.Program(serviceProvider),
                _ => null
            };
        }
    }
}