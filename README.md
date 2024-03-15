# [Dotnet.CosmosDB Example](https://github.com/a-sharifov/Dotnet.CosmosDB)  [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/a-sharifov/Dotnet.CosmosDB/blob/master/LICENSE.txt)

This repository serves to demonstrate the current capabilities of .NET Cosmos DB.

## Usage
To run the project, ensure you have the required version of .NET and Docker installed. Additionally, you'll need an Azure account with Cosmos DB added. The project can be launched like any other C# project.

In the appsettings.yml file, you may need to override the following settings for the Cosmos DB section:

```yml
CosmosDB:
  Endpoint: "your_cosmosdb_endpoint_uri"
  Key: "your_cosmosdb_authorization_key"
  DatabaseName: "your_cosmosdb_database_name"
```
You should replace "Endpoint", "Key", "DatabaseName" with the corresponding values from your Cosmos DB configuration. These settings will allow your application to connect to Cosmos DB in the Azure cloud.
