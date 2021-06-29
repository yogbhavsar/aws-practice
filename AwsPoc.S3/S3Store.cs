using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Amazon.Extensions.NETCore.Setup;
using Amazon.S3;
using Amazon.S3.Model;
using AwsPoc.Common.Models;
using Microsoft.Extensions.DependencyInjection;
using Utf8Json;

namespace AwsPoc.S3
{
    public class S3Store : IStore
    {
        private const string BucketName = "my-bucket";
        private readonly IServiceProvider _serviceProvider;

        public S3Store(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<Employee> GetEmployeeAsync(string employeeId)
        {
            var options = _serviceProvider.GetService<AWSOptions>();
            using var s3Client = options.CreateServiceClient<IAmazonS3>();
            using var s3Response = await s3Client.GetObjectAsync(BucketName, employeeId.ToString());
            if (s3Response.ContentLength == 0 || s3Response.HttpStatusCode != HttpStatusCode.OK)
                return null;
            var employee = await JsonSerializer.DeserializeAsync<Employee>(s3Response.ResponseStream);
            employee.Id = employeeId;
            return employee;
        }

        public async Task<string> SaveEmployeeAsync(Employee employee)
        {
            var options = _serviceProvider.GetService<AWSOptions>();
            var putObjectRequest = GetPutObjectRequest(employee);
            var employeeId = Guid.NewGuid().ToString();
            putObjectRequest.Key = employeeId;
            await using var jsonStream = GetJsonStream(employee);
            putObjectRequest.InputStream = jsonStream;

            using var s3Client = options.CreateServiceClient<IAmazonS3>();
            var s3Response = await s3Client.PutObjectAsync(putObjectRequest);
            if (s3Response == null || s3Response.HttpStatusCode != HttpStatusCode.OK)
            {
                throw new Exception("Operation failed.");
            }

            return employeeId;
        }

        private static MemoryStream GetJsonStream(Employee employee)
        {
            return new MemoryStream(JsonSerializer.Serialize(employee));
        }

        private static PutObjectRequest GetPutObjectRequest(Employee employee)
        {
            return new PutObjectRequest
            {
                BucketName = BucketName,
                ContentType = "application/json"
            };
        }
    }
}