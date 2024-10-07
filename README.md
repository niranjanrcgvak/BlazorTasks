## Overview
This project is a To-Do list Application built with Blazor Web Assembly. It consists of two main components: **Task2.Web** (the frontend) and **Task2.Api** (the backend API). 

## Prerequisites
Make sure you have the following installed on your machine:
- [.NET SDK](https://dotnet.microsoft.com/download) (net 8.0)
- [Visual Studio](https://visualstudio.microsoft.com/) or another compatible IDE (With blazor web assembly support)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (Microsoft SQL Server 2019 - for database management)

## Getting Started
### 1. Clone the Repository
Clone the repository to your local machine:
```bash
git clone https://github.com/niranjanrcgvak/BlazorTasks.git
cd your-repo-name
git checkout Task2
```
### 2. Update Connection String
Open the appsettings.json file in the Task2.Api project and update the connection string with your database details:
```json
"ConnectionStrings": {
    "DefaultConnection": "Your_Connection_String_Here"
}
```
### 3. Update the Database
Open the Package Manager Console in Visual Studio:

Go to Tools -> NuGet Package Manager -> Package Manager Console.
Ensure the Default Project dropdown is set to Task2.Api.
Run the following command to update the database:
```bash
Update-Database
```
### 4. Set Startup Project
Before running the application, ensure that the startup project is set to multiple projects:

1. Right-click on the solution in Solution Explorer.
2. Select Properties.
3. In the Common Properties section, go to Startup Project.
4. Set it to Multiple startup projects and ensure both Task2.Web and Task2.Api are enabled.

### 5. Run the Application
Run the Task2.Web and Task2.Api project for the first time. Task2.Api project will seed the default Roles and Users into the database.

Admin User Credentials

Email - admin@gmail.com

Password - Admin@123

### 6. Authentication
You can use the login and register pages in the Task2.Web project for authenticating users.
