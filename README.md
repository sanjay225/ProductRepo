# ProductRepo

Software Requirement:
1. Visual Studio 2019
2. PgAdmin 4 (Postgre sql)
3. Docker

**How to Setup Database:**
1. Open Command Prompt. Move to Docker folder inside Project and Run below command
cd {your path}\ProductApi\ProductApi\Docker

**docker-compose up**


2. Open Project using Solution and Build.

3. Go to Package Manager Console and run below command to create database. It will create database using Entity Framework.
PM> **update-database**

Once database is created.
Finally, Run project.
**https://localhost:44303/swagger**
