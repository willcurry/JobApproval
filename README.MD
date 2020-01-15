### Getting up and running

Download the github repository as a ZIP.

Extract the files somewhere.

Open the solution in vistual studio. I used 2019.

To run the tests just right click the test projects and press run tests.

To run the website, set the JobApprovalWeb as your startup project and then run it. It will also run the react project.

### Overview

JobApproval is a C# class library which contains the business logic for handling/processing job sheets.

JobApprovalWeb is a asp.net + react project which implements the JobApproval library.

JobApprovalTests is a nUnit project holding all the unit tests for the JobApprovalLibrary.

JobApprovalWebTests is a nUnit project holding all the unit/integration tests for the web site.


### API 

The web api can be accessed with the end point:

`/JobApproval/submit`

The end point requires a json payload which contains the total minutes, total price and requested items. It could look something like this:

`{"TotalMinutes":60,"TotalPrice":400,"RequestedItems":"{\"tyre\":\"2\"}"}`

You will get a text response with the outcome.

![postman](https://i.gyazo.com/4c79f290c1821b0f992a248a16075c98.png)

Alternatively you can just reference the JobApproval class library in your project and instantiate the JobProcessor class.