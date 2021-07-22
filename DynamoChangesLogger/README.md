# DynamoChangesLogger

This project contains sample source code and supporting files for a Dynamo DB Stream triggered serverless application that you can deploy with the SAM CLI. It includes the following files and folders.

- src - Code for the application's Lambda function.
- events - Invocation events that you can use to invoke the function.
- template.yaml - A template that defines the application's AWS resources.

This application's deployment package type is Zip and runtime is .NET core 3.1. The application uses several AWS resources, including Lambda functions, Dynamo DB events, Cloudwatch logs, CloudFormation stacks. Some of these resources are defined in the `template.yaml` file in this project. You can update the template to add AWS resources through the same deployment process that updates your application code.

## Prerequisites

The following tools need to be installed to build and run this project.
1. .NET Core 3.1 SDK
2. AWS SAM CLI
3. Docker

### For the first time users
If you are deploying the application for the first time using the SAM CLI, you need to make sure that appropriate profiles or roles are ready to deploy the package. You might want to use different roles for application packaging and application deployment.

## Deploy the application

To build and deploy your application for the first time, run the following in your shell:

```bash
sam build
sam deploy --guided
```

Optionally, if you are looking for an actual deployment of the SAM app, you can use `sam validate` before `sam build` and `sam deploy`.

The `sam validate` command has many parameters like template file, profile and region. It validates the template using the AWS IAM policies defined in your account.
The `sam build` command builds the Zip package. It doesn't need additional permissions.
The `sam deploy` command takes care of creating the change set in the CloudFormation stack and deploying that. Since here we want deployment rights, it's good to have a different role for this command that has all the required rights.

## Resources

See the [AWS SAM developer guide](https://docs.aws.amazon.com/serverless-application-model/latest/developerguide/what-is-sam.html) for an introduction to SAM specification, the SAM CLI, and serverless application concepts.

You can use AWS Serverless Application Repository to deploy ready to use Apps that go beyond hello world samples and learn how authors developed their applications: [AWS Serverless Application Repository main page](https://aws.amazon.com/serverless/serverlessrepo/)
