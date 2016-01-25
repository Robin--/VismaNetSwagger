# Visma.net API SwaggerConverter

If you're using Visual Studio 2015, you can use this swagger.json to generate all classes needed for using the Visma.net API in Visual Studio. This is a modified version of the swagger.json provided by Visma.

To add the Visma.net API to your Visual Studio project, right click the project, select Add and "REST API Client". Check "Select an existing Swagger metadata file", click "Browse" and paste the raw url to swagger.json (https://github.com/ON-IT/VismaNetSwagger/raw/master/swagger.json) and press OK. Windows will dowload the swagger.json to you temp folder and load it in Visua Studio for you.

This will generate (almost) all the classes you need for working with Visma.net. Everything will be created in the folder "Visma.net API", and when you are ready to upgrade you just delete this folder and repeat this process. Make sure that you never make any changes to any files in "Visma.net API".

In addition to the generated code, you'll need the VismaNetDelegatingHandler class. See the sample code below.

```csharp
  const string vismaNetToken = "a9363488-4c2c-4ee5-9b73-79184865a550";
  const int vismaNetCompany = 1021021;

  var credentials = new TokenCredentials("Bearer", VismaNetToken);
  var uri = new Uri("https://integration.visma.net/API");
  var delegationHandler = new VismaNetDelegatingHandler(vismaNetCompany);
  var vismaNet = new VismanetAPI(uri, credentials, delegationHandler);

  var customers = await vismaNet.Customer.GetAllAsync();

  foreach (var customer in customers)
    Console.WriteLine($"{customer.Name}");

```
