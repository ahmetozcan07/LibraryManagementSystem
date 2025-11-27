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

### 2. Entity Framework Core Integration
- EF Core with Azure SQL Database support.
- Tables:
  - `Users`
  - `Books`
- Seeded 5 example books.
- Automatic admin creation at startup in Program.cs with the following code.
This code can be deleted later.

---
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
- Simulated external API call using `async/await` to fetch book details.

---

### 5. API Security + Swagger
- All endpoints secured using role-based authorization.

---

## Additional Functionality
### Borrow / Return Books
- Users and Admins can borrow a book.
- This is only for simulation. Books can be returned even without getting borrowed.

---