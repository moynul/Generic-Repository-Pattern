# Generic-Repository-Pattern
Repository Pattern and Generic Repository Pattern in .net core 3.1 and Entity Framework

File structure (the most relevant):

models
 BaseEntity
 CoreDbContext
 GenericRepository
 IGenericRepository
 IUserRepository
 UserRepository
 User

Run
Step 1 :

Chnage database connection string From app appsettings 

Step 2 : 

Open package manager console and run bellow command 
add-migration InitialCreate
update-database

step 3: 

Compile and run
