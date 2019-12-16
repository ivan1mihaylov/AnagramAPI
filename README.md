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

First both ``AnagramAPI`` and ``IdentityServer`` as startup projects. 

The type of database that is used is determined by the ``UseMySql`` property in the ``appsettings.json`` file which is set to ``false`` by default. 

The connection strings for the development or the production enviroment are in the respective appsettings files as currently both of them are set to ``localhost``.

If you choose to run the app with the default settings, its databases will be initialize on the first run for both projects. Otherwise you need to specify the MySql host/database/user/password before first run.
