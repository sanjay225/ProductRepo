# ProductRepo

Software Requirement:
1. Visual Studio 2019
2. PgAdmin 4 (Postgre sql)
3. Docker

**How to Setup Database:**
1. Open Command Prompt. Move to Docker folder inside Project and Run below command
cd {your path}\ProductApi\ProductApi\Docker

**docker-compose up**


2. Run command in command prompt to get IPV4 Address.

**ipconfig**

3. Replace below hightlighted Host entry with your IP inside appsettings.json

"ProductDatabase": "Server=**172.29.144.1**;Port=5432;User Id=guest;Password=guest;Database=product"


4. Go to Package Manager Console and run below command to create database
PM> **update-database**

Once database is created.
Finally, Run project.
**https://localhost:44303/swagger**
