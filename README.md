# CRUD .NET Core + Validation data + Tests

About this project
The goal of this task is to evaluate your coding skills and what you value when creating a new software. Besides the predefined requirements, feel free to improve or
extend the features if you want to. Consider this exercise as a proof of concept, which should be scalable, maintainable and well tested. As this is a proof of concept,
don't waste much time on complex data persistence implementations, but make sure the project has the correct abstractions, so the data persistence can be easily
replaced with little or no effort.

### To configure

1. Change the connection string in appsettings.json to connect with your database (project LegalCaseMicrosservice)
2. Change the connection string in LecalCaseUnitTestController.cs to connect with your database (project LegalCaseMicrosservice.Tests)

### To Compile

1. At first is necessary to execute app migrations to create the database using the command on package manager console in the **LegalCaseMicrosservice** diretory:
> dotnet ef database update
2. Execute the following command to build and run application
> dotnet build

> dotnet run

### Testing application

Identify if you are in the **LegalCaseMicrosservice.Tests** directory on package manager console and type:
> dotnet test
