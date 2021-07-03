using System;

namespace AwsPoc.Common.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Experience { get; set; }
        public DateTime JoiningDate { get; set; }
    }
}