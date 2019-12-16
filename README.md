# Anagram API

An WebAPI for register words and check them if they are anagrams. 

## Getting Started

The API is separated on 5 projects:
  - AnagramAPI - which is the API itself
  - IdentityServer - quick implementation of identity server to use the benefits of JWT tokens authentification and authorization
  - Entity - Used for database access
  - Domain - Used for DTO and services
  - Tests

It is written on .Net Core 3.1 with Sqlite or MySql databases.
The used nuget packages are Newtonsoft.Json, EntityFrameworkCore, AutoMapper, NUnit, Swagger, IdentityServer, AspNetCoreRateLimit, Pomelo MySql, etc.


### Usage

First set both ``AnagramAPI`` and ``IdentityServer`` as startup projects. 

The type of database that is used is determined by the ``UseMySql`` property in the ``appsettings.json`` file which is set to ``false`` by default. 

The API uses 3 databases: ``InformationDb``, which stores the information sent by and to users, ``HealthChecksDb``, which keeps log for the past healthchecks and ``AuthDb``, which stores configuration and operational data for the identity server.

The connection strings for the development or the production enviroment are in the respective appsettings files as currently both of them are set to ``localhost``.

If you choose to run the app with the default settings, its databases will be initialize on the first run for both projects. Otherwise you need to specify the MySql host/database/user/password before first run.

On the landing page there are links to the HealthChecksUI and SwaggerUI for easier access.

The solely purpose of the ``InfoController`` is returning the static HTML file, used for landing page.

The ``AnagramController`` has 3 endpoints, as the first and the second require authorization:

  The endpoint ``/v1/anagram``, save the provided base64 string to the database and returns the ID of the new entity.
  The endpoint ``/v1/anagram/{ID1:int}/{ID2:int}``, check two of the already saved words and returns url to the result.
  The endpoint ``/v1/anagram/{ID:int}``, shows the information about previously made check in JSON format.
  
To get an active token use the POST ``/v1/Auth/getToken`` as you should pass as body 
``{
  "username": "string",
  "password": "string"
}``

As test user you can use username ``alice`` and password ``alice``.
