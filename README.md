# NetCoreWebAPIs - Microservices written in .NET CORE
## What is this
This is a project to learn and play around with Microservices being implemented in .NETCore.
* .NET Core
* EF Core In Memory
* JWT - JSON Web Tokens
* SQLite
### Project Structure
* Customer
  * **NetCoreWebAPIs.Customer.Core.csproj**
    * Contains "business logic" and EF Core code.
    * Tech
      * .NETCore Library
      * Entity Framework Core
  * **NetCoreWebAPIs.Customer.WebAPI.csproj**
    * Internal Microservice
    * Tech
      * .NETCore WebAPI
* Order
  * **NetCoreWebAPIs.Order.WebAPI.csproj**
    * Internal Microservice
    * Tech
      * .NETCore WebAPI
      * SQLite
* User
  * **NetCoreWebAPIs.User.WebAPI.csproj**
    * Internal Microservice
    * Tech
      * .NETCore WebAPI
* Weather
  * **NetCoreWebAPIs.Weather.WebAPI.csproj**
    * Internal Microservice
    * Tech
      * .NETCore WebAPI
* **NetCoreWebAPIs.App.Console.csproj**
  * Talks directly to gateway.
  * Tech
    * .NETCore Console
* **NetCoreWebAPIs.Core.csproj**
  * Core code containing a WebAPI caller class and some POCO models.
  * Tech
    * .NETCore Library
* **NetCoreWebAPIs.Gateway.csproj**
  * Public Microservice
  * Tech
    * .NETCore WebAPI
    * JWT Authentication - JSON Web Tokens
