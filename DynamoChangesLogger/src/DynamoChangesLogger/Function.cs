using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.Lambda.Core;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace DynamoChangesLogger
{

    public class Function
    {
        public async Task FunctionHandler(DynamoDBEvent dynamoDbEvent, ILambdaContext context)
        {
            try
            {
                await Task.Run(() => LambdaLogger.Log("Received event. " + JsonConvert.SerializeObject(dynamoDbEvent)));
            }
            catch (Exception ex)
            {
                await Task.Run(() => LambdaLogger.Log("Exception occurred: " + Environment.NewLine + ex));
            }
        }
    }
}
