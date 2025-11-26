# Library Management System (LMS)

A simple **Library Management System** built with **ASP.NET Core Web API**, **Entity Framework Core**, and **JWT Authentication**.

---

### 1. Authentication & Authorization
- JWT-based authentication.
- **Admin** and **User** roles.
- Admins can:
  - Add books
  - Update books
  - Delete books
- Users can:
  - View book list
  - View book details

---

### 📦 2. Entity Framework Core Integration
- EF Core with Azure SQL Database support.
- Tables:
  - `Users`
  - `Books`
- Seeded 5 example books.
- Automatic admin creation at startup (`admin / admin123`) in Program.cs with the following code.
This code can be deleted later.

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Users.Any())
    {
        db.Users.Add(new JWTandRoleBasedApp.Models.User
        {
            Username = "admin",
            PasswordHash = JWTandRoleBasedApp.Helpers.PasswordHasher.Hash("admin123"),
            Role = "Admin"
        });

        db.SaveChanges();
    }
}

---

### 3. LINQ Data Queries
API Endpoints include:
- Get books grouped by author  
- Get top 3 most borrowed books  

---

### 4. Async Programming
- Simulated external API call using `async/await` to fetch fake book details.

---

### 5. API Security + Swagger
- All endpoints secured using role-based authorization.
- Full Swagger documentation available at:

/swagger

---

## Additional Functionality
### Borrow / Return Books
- Users and Admins can borrow a book.
- This is only for simulation. Books can be returned even without getting borrowed.

---

## Database Migrations

To create annd apply a migration:

```sh
dotnet ef migrations add InitialCreate
dotnet ef database update



    Running the Project
1. Update appsettings.json
Add your Azure SQL connection string:

json

"ConnectionStrings": {
  "DefaultConnection": "your-azure-sql-connection-string"
}
2. Run the API

```sh
Copy code
dotnet run

API starts at localhost

Swagger UI:

go to /swagger