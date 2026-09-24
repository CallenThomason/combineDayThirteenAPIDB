###SQLite & Entity Framework core

## What is a Database

A database is where our application permanetly stores information
This allows our information to stay saved, even when our API stops. 

## SQLite

SQLite is a simple database that stores all of its data inside a file

Unlike SQL Server SQLite does not require us to have a seperate Database Server Running

## Entity Framework Core

Ef Core, allows our C# application to communicate with a database

* Instead of Writing SQL ourselves, we can work with our database using C# * 

C# API -> Ef Core -> SQLite Database

## AppDbContext class

This is the main connection between our application and our database

It tells Ef core which models we want to store in our DB 

Each DbSet inside of our AppDbContext represents a table. 

## What is a Migration

A Migration is Ef Core's way of keeping track of cahnges we want to make to our DB

Whenever we create / change models we create a migration
* dotnet ef migrations add init * init stands for initialize

any migrations after the intial migration can be named anything
* dotnet ef migration add studentUpdate *

## Updating the Database

Creating a migration does not automatically update the database

We still need to run our Database update

* dotnet ef database update * 

Model -> Migration -> Database Update -> Database

## Common LINQ Methods

FirstOrDefault() - Finds the first matching record. if nothing is found, it returns null

Where() - Filters records based on a condition. (We would store the results in a variable)

ToList() - Gets multiple records and returns them as a list. 

## SaveChanges

Ef Core keeps track of changes we make to our data.

When we add, update, or remove something, those changes need to be saved to the DB

* Save Changes() * tells Ef core: Take the changes I made and save them to the Database

## Dependency Injections

DI allows our classes to receive the things they need instead of creating manually

Ex of manually creating classes / object * Student students = new Student(); *