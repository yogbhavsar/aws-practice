## Logs Producer

### Architecture
The concept is to push the logs to the firehose service and then have them stored in the `Amazon ElasticSearch` (Now `OpenSearch`) service, so that they can be further used for visualizations like Kibana and Grafana. The [diagram](resources/LogsProducer-Architecture.pdf) represents the intended architecture.

### Details
From the architecture, this repo contains the `LogsProducer` component only. The rest of the components are purely AWS resources that need the configuration only, hence they are not added in this repo. Unlike the other components like S3, this is a separate console application instead of a program in the main console app. This is because the app could have been run on an AWS instance also. Current testing is done by running on the local machine only.

### Steps to run
After building the application, when you run it using the command line, add a command line parameter that indicates the number of logs you want to generate. e.g.   
`dotnet AwsPoc.LogsProducer.dll 5`  
If you don't specify the parameter, it takes the default value as 1.

### Progress till now
The `LogsProducer` application sends the logs to the Kinesis firehose service. Due to an issue with the `OpenSearch` domain configurations (maybe), the logs are not getting pushed into the `OpenSearch` index by the Kinesis firehose service. Respecting the limitations of the free tier, I didn't create another `OpenSearch` domain now. It will be created after some time.  
The issue being faced is this:
```
ES.ServiceException:
Error received from Elasticsearch cluster. {"error":{"root_cause":[{"type":"security_exception","reason":"no permissions for [indices:data/write/bulk] and User [name=arn:aws:iam::*******:role/service-role/KinesisFirehoseServiceRole-logs-firehos-ap-south-1-1632822579831, backend_roles=[arn:aws:iam::*******:role/service-role/KinesisFirehoseServiceRole-logs-firehos-ap-south-1-1632822579831], requestedTenant=null]"}],"type":"security_exception","reason":"no permissions for [indices:data/write/bulk] and User [name=arn:aws:iam::*******:role/service-role/KinesisFirehoseServiceRole-logs-firehos-ap-south-1-1632822579831, backend_roles=[arn:aws:iam::*******:role/service-role/KinesisFirehoseServiceRole-logs-firehos-ap-south-1-1632822579831], requestedTenant=null]"},"status":403}
```

### References
1. https://d1.awsstatic.com/Projects/P4113850/aws-projects_build-log-analytics-solution-on-aws.pdf (A little outdated)