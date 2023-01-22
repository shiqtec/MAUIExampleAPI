# MAUIExampleAPI

- [Overview](#overview)
- [Running SQL Server in Docker](#running-sql-server-in-docker)
- [Database Migration](#database-migration)

## Overview

This example API is used to in conjunction with MAUExampleUI. It does not have any model validation or error handling as examples as it was meant to be a simple API that we can use when building the UI with .NET MAUI.

The API has the following:
- SQL Express Database (see below on how to run this in docker)
- Entity Framework
- AutoMapper

The API retrieves, updates and deletes todos in the database.

## Running SQL Server in Docker

First, install Docker here https://www.docker.com/.

Once downloaded and with Docker running, the below command can be run in the terminal to pull the SQL Server image and run this in a docker container:
```sh
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<YOUR_SA_PASSWORD>" -e 'MSSQL_PID=Express' -p 1433:1433 --name electron_budget --hostname electron_budget -d mcr.microsoft.com/mssql/server:2022-latest
```

> ***-e "ACCEPT_EULA=Y"*** The ***-e*** flag is an environment flag and allows us to configure the container environment. With this specific option we are accepting the End User Licensing Agreement (EULA) for SQL Server.
>
> ***-e "MSSQL_SA_PASSWORD=<YOUR_SA_PASSWORD>"*** This is to set up the Server Administrator (sa) account for SQL Server, so do use a strong password.
>
> ***-e 'MSSQL_PID=Express'*** Here we are specifying that we would like to use the Express (free) edition of SQL Server.
>
> ***-p 1433:1433*** This command maps the containers port to an external port on our local machine.
>
> ***--name electron_budget*** We give a name for the container instead of using a randomly generated on. This is optional, but is useful if you have other similar containers running which will make it easier to distinguish them.
>
> ***--hostname electron_budget*** This is to set the host name and is another optional setting.
>
> ***-d*** This command tells Docker to run the container in the background.
>
> ***mcr.microsoft.com/mssql/server:2022-latest*** This is the image name and version we would like to use.

Now you can open SSMS and connect to your database server by using the following details:
- Server type: Database Engine
- Server name: localhost
- Authentication: SQL Server Authentication
- Login: sa
- Password: YOUR_SA_PASSWORD

## Database Migration

Prerequisites:
- Docker
- Database created
- User created with dbowner access to the newly created database (this is the user that the API will use to connect to the database)
- Database connection string in *appsettings.Development.json* has been updated 
- Project cloned and NuGet packages are installed

Run the following command to install .NET CLI:
```sh
dotnet tool install --global dotnet-ef
```

Run the following to apply the database migrations, which will create the todo table:
```sh
dotnet ef database update
```
