using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.KinesisFirehose;
using Amazon.KinesisFirehose.Model;
using Amazon.Runtime.CredentialManagement;
using AwsPoc.LogsProducer.Models;
using Newtonsoft.Json;

namespace AwsPoc.LogsProducer
{
    public class FirehosePublisher : IDisposable
    {
        private AmazonKinesisFirehoseClient _client;
        private AmazonKinesisFirehoseClient FirehoseClient
        {
            get
            {
                if (_client == null)
                {
                    var chain = new CredentialProfileStoreChain();
                    if (!chain.TryGetAWSCredentials("firehose-access-role", out var awsCredentials))
                    {
                        throw new Exception("Profile not found");
                    }
                    _client = new AmazonKinesisFirehoseClient(awsCredentials, RegionEndpoint.APSouth1);
                }
                return _client;
            }
        }
        public void Dispose()
        {
            if (_client != null)
            {
                _client.Dispose();
            }
        }

        public async Task PublishAsync(Log log, CancellationToken cancellationToken = default)
        {
            var bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(log));
            using var stream = new MemoryStream(bytes);

            var putRecordRequest = new PutRecordRequest
            {
                DeliveryStreamName = "logs-firehose-delivery-stream",
                Record = new Record
                {
                    Data = stream
                }
            };
            await FirehoseClient.PutRecordAsync(putRecordRequest, cancellationToken);
        }
    }
}
