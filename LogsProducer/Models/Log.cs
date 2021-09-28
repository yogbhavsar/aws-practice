using System;
using System.Net;

namespace AwsPoc.LogsProducer.Models
{
    public class Log
    {
        public string Id { get; set; }
        public LogType Type { get; set; }
        public string IpAddress { get; set; }
    }
}
