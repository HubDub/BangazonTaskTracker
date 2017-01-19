Bangazon TaskTracker

I created this API in Visual Studio using a SQL database. 

PROJECT DIRECTIONS
Table of Contents

Prerequisites
What You Will Be Learning
Requirements
Resources
Prerequisites

.NET Core

.NET Core installed.
Visual Studio Code, or Visual Studio Community Edition installed for existing Windows users.
For Code users, install the C# extension.
Yeoman, and the ASP.NET generator, installed
.Net 4.5+

Visual Studio Community Edition installed
What You Will Be Learning

Annotations, Routing and DI

ASP.NET makes heavy use of annotations, routing and dependency injection to abstract away much of the heavy lifting that is required to build an API. By using these Magical Abstractions, far less coding and configuration is needed from an API developer.

Models

You will define models, which are abstractions to the actual database. The model defines a table, validations on the columns in the table, and also the relationship between tables.

Migrations

You will be using migrations in Entity Framework to handle changes and updates to your database.

Controllers

You will learn about what role a controller has in an API, how it uses models and validates a request against the model, and how to use LINQ to get data from your database.

Requirements

API

Scaffold a basic WebAPI project.
Define a model and API controller for a Task. The model should have at least the following fields:

Field           Data Type                           Required
Id              number                                  ✓
Name            text                                    ✓
Description     text    
Status          enum (ToDo, InProgress, Complete)       ✓
CompletedOn     date    

Controllers may not return a view.

API Consumers should be able to create a new task.
API Consumers should be able to update a task's Name, Description and Status.
Validation should be performed. Requests that fail validation should return the appropriate HTTP Status Code.
The CompletedOn date should be updated to the current date when Status is set to complete.
API Consumers should be able to request a list of tasks by priority.
Generate API documentation with enough detail for a teammate to build a UI without any other knowledge.
UI

Create a simple Angular frontend.
Users should be able to create a new task.
Users should be able to update a task's Name, Description and Status.
Validation should be performed.
Users should be able to view a list of tasks by Priority.
Users should be able to view a list of tasks by Status.
Users should be able to view a list of tasks by CompletedOn.
Resources

Installing C# Extension for Code

You install this extension by pressing F1 to open the VS Code palette. Type ext install to see the list of extensions. Select the C# extension.

Installing Yeoman and the ASPNET Generator

Both of these are npm packages, and global installations at that, so run this command in your terminal.

npm install -g yo generator-aspnet