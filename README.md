E-Commerce application with Asp.NET MVC and Entity FrameWork Core.
The application uses the Unit of Work pattern to coordinate data access operations and ensure they are executed as a single transaction.
 Integrated with the Generic Repository pattern, it provides a clean and consistent way to handle database entities such as Products,Categories, and Users.
 The `UnitOfWork` acts as a centralized service between the controllers and the database context, 
 grouping multiple operations into one cohesive transaction through a single `SaveChanges()` call.
 This approach enhances code maintainability, reduces repetition, improves testability,
 and promotes a clear separation of concerns within the architecture.
 
Built using:
.NET MVC BUILDING BLOCKS - Models, ViewModels, Views, Partial views, Controllers, ViewComponents .
CRUD OPERATIONS WITH ENTITY FRAMEWORK CORE - SQL Server configuration, EFCore migrations, relationship types, relational and non-relational data .
BUILD RESTFUL SERVICES - Dependency injection, major dependency injection lifetimes, services, and generic base repositories, Unitofwork .
.NET IDENTITY FRAMEWORK - Authentication, authorization, cookie-based authentication, role-based UI rendering .
PAYPAL INTEGRATION - Configuring the PayPal checkout library, create and process payments .




 

