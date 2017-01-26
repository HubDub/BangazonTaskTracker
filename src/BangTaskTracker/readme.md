# Bangazon Task Tracker

This is a .NET Core 1.0 API built in Visual Studio in the language of C#, using the built in VS SQL database.

Using this API, you will be able to create, edit, view all tasks or view tasks based on task ID or status.

It does not require a key to access. 

In order to use it, you will need to assure that you have installed:
1. Visual Studio with C# extension
2. .NET Core 

Then, you will need to:
1. clone or fork this project.
2. Open Visual Studio, build, then open package manager console to add migrations (Add-Migration -initialMigration) and update database (Update-Database)
3. run it

In order to access the API from a front end you'll need to use these routes added to your local server address:

GET all tasks: localHost:####/api/values
GET one task by task ID: localHost:####/api/values/{taskID}
GET all tasks of certain status: localHost:####/api/values/status/{status#}
    The status of a task is ToDo (0), InProgress (1), or Complete (2)
POST new task: localHost:####/api/values
PUT task: localHost:####/api/values/{taskID}
DELETE task: localHost:####/api/values/{taskID}