# Pokedex - EDD Assignment

This project tries to implemement basic CRUD operations using the MongoDB Driver for ASP.NET Core. 

Makes use of an N-Tiered architecture: 

> Client -> Controllers (HTTP Layer) -> Services (Core Orchestrator) -> Context (Data Access Layer) -> Database (MongoDB)

## Instructions
1. Clone the repository
```bash
git clone https://github.com/dagweg/pokedex-edd-assignment.git
```
2. Restore and Build the project
```bash
dotnet restore
dotnet build
```
3. Run the project
```bash
dotnet watch run
```

Test the APIs either using the Swagger generated one or the requests found in 'Requests' folder.

Since the database is already hosted on MongoDB Atlas, all you need to do is use the api, no need for local configuration. That's all!
