# [Dotnet.CosmosDB Example](https://github.com/a-sharifov/Dotnet.CosmosDB)  [![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/a-sharifov/Dotnet.CosmosDB/blob/master/LICENSE.txt)

This repository serves to demonstrate the current capabilities of .NET Cosmos DB.

## Usage

To run the project, make sure you have the required version of .NET and Docker installed on your machine. Additionally, you'll need an Azure account with Cosmos DB added to it. Follow these steps to launch the project:

1. **Clone the Repository:**
   - Clone or download the project repository to your local machine.


2. **Sign in to Azure Portal:**
   - Go to [Azure Portal](https://portal.azure.com/).
   - Sign in with your Azure account.

3. **Obtain Cosmos DB Settings:**
   - Navigate to the Keys section in your Cosmos DB resource on the Azure portal:
     ![Cosmos DB Keys](https://github.com/a-sharifov/Dotnet.CosmosDB/blob/master/img/Azure_CosmosDB_Keys.png?raw=true)
   - This is information about your database

4. **Configure Cosmos DB Settings:**
   - Open the `appsettings.yml` file in your project.
   - If necessary, override the following settings for the Cosmos DB section:
     ```yml
     CosmosDB:
       Endpoint: "your_cosmosdb_endpoint_uri"
       Key: "your_cosmosdb_authorization_key"
       DatabaseName: "your_cosmosdb_database_name"
     ```
   - Replace "Endpoint", "Key", and "DatabaseName" with the corresponding values from your Cosmos DB configuration.
   - Write the name of the database yourself

5. **Run the Project:**
   - Launch the project using your preferred IDE or command line tool.

---

## 🌟 Enjoyed my project?

- Please consider starring the repository.
- You can donate on [Patreon](https://www.patreon.com/a_sharifov).

## 📫 Contact

If you have any questions or suggestions, feel free to reach out to me.

This project is licensed under the [MIT License](LICENSE).

