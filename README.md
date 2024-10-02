# Todoist-Clone-Backend

> The current development progress is happening on the [development](https://github.com/Legolas2222/TodoistBackend/tree/development) branch, where I merge all changes until they are stable and final enough to be 'published' onto the master branch. 

## Aim of this project
This is a practice project to get used to the principles of Domain-Driven-Design in .NET, as well as to get a wider understandment of working with large-scale applications. 
For me, it was specifically a priority to grasp the structure of multiple levels of a modern application. 
Furthermore, building a complete, yet simple RESTful API also involved getting into new technologies like Docker and API Testing with Postman/Hoppscotch.

As far as the functionality goes, it first started out to be an all-in-one API for user-management as well as the organization (for now only via the simple CRUD API) for Todo-Items. 
Like the name suggests, the inspiration for this project has been the popular app "Todoist" that, although it is a lot more fleshed out, is as it's core a well-build task-management application, whose core functionality (without the NLP processing of the user-input) is the main goal for this project.

## Challenges 
Firstly, the scale of the application, was new to me, as it would requiere a broader perspective, when examining a problem in a multi-level app. 
Similarly, debugging and developing a larger app also comes with its own difficulties, which for me have been the first challenges, when I have to dig through a *deep* callstack. 

## Considerations

### Core Functionality 
- CRUD Operations for Todos
- Saving the State to a Database


### Technologies used 

#### ASP.NET Core
I personally preferred the more modern syntax and conventions of C# over Java, as both languages seemed applicable for writing such an app

#### Mongo DB
Without having to mess with any sort of SQL-Query for now, I chose an non-sql database which after some research, turned out to be MongoDB, as it is widely used, not too difficult to understand and also has good support in .NET

#### Using an ORM or not 
At the start, the plan was to use EF-Core as an ORM for .NET, as it promised adaptability and a clear structure to follow when implementing it. After multiple attempts, I am now deciding against using EF-Core, as its support for MongoDB is only in prerelease and avoiding it would also enable me to write my own DB abstraction and give the data-flow process through the app a second consideration.