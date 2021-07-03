# aws-practice

[![Build Status](https://travis-ci.com/yogbhavsar/aws-practice.svg?branch=main)](https://travis-ci.com/github/yogbhavsar/aws-practice)

A console application.

Contains the practice/poc solutions around aws services. It is developed with [localstack](https://github.com/localstack/localstack).

## Pre-requisites
1. AWS CLI V2 should be installed. (Installation with Python pip is also fine.)
2. AWS profile should be configured so that it can be used with the solution.

## Steps to run the solution
1. Build the solution.
2. Go to `appSettings.json` under `AwsPoc.Console` project.
3. Verify the contents of the file so that they match the AWS profile and region. If you are not using `localstack`, you may remove service URL from the file.
4. Make sure you build the solution again if you have changed anything in `appSettings.json`.
5. Run the solution. The code uses mock data whenever needed. So no need of preparing the data.

## AWS Services covered till now
1. S3

## Troubleshooting
Please refer [this](Troubleshooting.md) document.