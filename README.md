# Intro to Gabriel's C# ASPNET GraphQl API

This is an Aspnet GraphQL API with the HotChocolate Framework that allows you to manage food and how the are prepared, you can `add food, get food`. 

    see documentation docs at http:localhost:5000/ui/voyager
    also test at http:localhost:5000/graphql

# Dependencies

**ManageUsersMicroservice** depends on the following nuget packages

    - [GraphQL.Server.Ui.Voyager]( --version 5.2.0)
    - [HotChocolate.AspNetCore]( --version 12.4.1)
    - [HotChocolate.Data.EntityFramework]( --version 12.4.1)
    - [Microsoft.EntityFrameworkCore.Design]( --version 5.0.13)
    - [Microsoft.EntityFrameworkCore.SqlServer]( --version 5.0.13)


# Installation or Running

Restore and Build the project with
    
    dotnet restore
    dotnet build

Then run the project

    dotnet run

