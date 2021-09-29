# Logs Producer

## Architecture
The concept is to push the logs to the firehose service and then have them stored in the `Amazon ElasticSearch` (Now `OpenSearch`) service, so that they can be further used for visualizations like Kibana and Grafana. The [diagram](resources/LogsProducer-Architecture.pdf) represents the intended architecture.

## Details
From the architecture, this repo contains the `LogsProducer` component only. The rest of the components are purely AWS resources that need the configuration only, hence they are not added in this repo. Unlike the other components like S3, this is a separate console application instead of a program in the main console app. This is because the app could have been run on an AWS instance also. Current testing is done by running on the local machine only.

## Steps to run
After building the application, when you run it using the command line, add a command line parameter that indicates the number of logs you want to generate. e.g.   
`dotnet AwsPoc.LogsProducer.dll 5`  
If you don't specify the parameter, it takes the default value as 1.  
The rest of the things are to be checked on the AWS console only. If you get any exception while running, ensure that you have proper credentials setup to push to the Kinesis firehose delivery stream.

## Progress till now
The `LogsProducer` application sends the logs to the Kinesis firehose service. The visualizations (Kibana) are not shown on the AWS `OpenSearch` dashboard due to some missing configurations.  
### Issues faced till now:
1. Unable to push the logs to the ES domain. Following was the exception seen in the logs.
```
ES.ServiceException:
Error received from Elasticsearch cluster. {"error":{"root_cause":[{"type":"security_exception","reason":"no permissions for [indices:data/write/bulk] and User [name=arn:aws:iam::*******:role/service-role/KinesisFirehoseServiceRole-logs-firehos-ap-south-1-1632822579831, backend_roles=[arn:aws:iam::*******:role/service-role/KinesisFirehoseServiceRole-logs-firehos-ap-south-1-1632822579831], requestedTenant=null]"}],"type":"security_exception","reason":"no permissions for [indices:data/write/bulk] and User [name=arn:aws:iam::*******:role/service-role/KinesisFirehoseServiceRole-logs-firehos-ap-south-1-1632822579831, backend_roles=[arn:aws:iam::*******:role/service-role/KinesisFirehoseServiceRole-logs-firehos-ap-south-1-1632822579831], requestedTenant=null]"},"status":403}
```
**Status**: Resolved.  
**Resolution**: An inline policy to add to the role that gets created for the Amazon Kinesis firehose stream. Add the permission of ALL elastic search actions in the inline policy as given in the document in the references.

2. Unable to see the visualization on the `OpenSearch` dashboard.  
The OpenSearch dashboard design is changed since the document was created and it doesn't allow to add the IAM user now. Hence, the index created newly is not available to the logged-in user in dashboard. The document also has some other things required for the access that are not straight-forward in the new UI.


## References
1. https://d1.awsstatic.com/Projects/P4113850/aws-projects_build-log-analytics-solution-on-aws.pdf (A little outdated. The same is available [here](resources/aws-projects_build-log-analytics-solution-on-aws.pdf))
