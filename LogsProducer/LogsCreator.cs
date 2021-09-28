using System;
using System.Net;
using AwsPoc.LogsProducer.Models;

namespace AwsPoc.LogsProducer
{
    public class LogsCreator
    {
        public Log CreateLog() => new Log
        {
            Id = Guid.NewGuid().ToString(),
            Type = LogType.Trace,
            IpAddress = IPAddress.Loopback.ToString()
        };
    }
}
