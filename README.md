# NetCoreWebAPIs - Microservices written in .NET CORE
## What is this
This is a project to learn and play around with Microservices being implemented in .NETCore.
### Structure
* Customer
  * **NetCoreWebAPIs.Customer.Core.csproj**
    * Contains "business logic" and EF Core code.
    * Tech
      * .NETCore Library
      * Entity Framework Core
  * **NetCoreWebAPIs.Customer.WebAPI.csproj**
    * Internal Microservice for getting/saving customers.
    * Tech
      * .NETCore WebAPI
* Order
  * **NetCoreWebAPIs.Order.WebAPI.csproj**
    * Internal Microservice for getting/saving customer orders.
    * Tech
      * .NETCore WebAPI
      * SQLite
* User
  * **NetCoreWebAPIs.User.WebAPI.csproj**
    * Internal Microservice for getting user data.
    * Tech
      * .NETCore WebAPI
* Weather
  * **NetCoreWebAPIs.Weather.WebAPI.csproj**
    * Internal Microservice for getting weather forecast data.
    * Tech
      * .NETCore WebAPI
* **NetCoreWebAPIs.App.Console.csproj**
  * Implementation application which talks directly to gateway.
  * Tech
    * .NETCore Console
* **NetCoreWebAPIs.Core.csproj**
  * Core code containing a WebAPI caller class and some POCO models to pass between projects.
  * Tech
    * .NETCore Library
* **NetCoreWebAPIs.Gateway.csproj**
  * Public Microservice
  * Tech
    * .NETCore WebAPI
    * JWT Authentication - JSON Web Tokens