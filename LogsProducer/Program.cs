using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AwsPoc.LogsProducer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Creating logs.");

            try
            {
                var counter = 1;
                if (args != null && args.Length > 0)
                {
                    counter = Convert.ToInt32(args[0]);
                }

                PublishLogs(counter);
                System.Console.WriteLine($"Published {counter} logs.");
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception occurred. Stopping.");
                System.Console.WriteLine(ex);
            }
        }

        private static void PublishLogs(int counter)
        {
            var creator = new LogsCreator();
            using var publisher = new FirehosePublisher();
            var tasks = new List<Task>();
            for (var i = 0; i < counter; i++)
            {
                var log = creator.CreateLog();
                tasks.Add(publisher.PublishAsync(log));
            }
            Task.WhenAll(tasks).GetAwaiter().GetResult();
        }
    }
}
