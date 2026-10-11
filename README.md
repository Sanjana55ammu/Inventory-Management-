# Inventory-Management-
# Inventory Management System using .NET

## 📌 Project Overview

The **Inventory Management System** is a web-based application developed using ASP.NET Core Web API and SQL Server to manage inventory items, track assets, and maintain organized inventory records.

The system is designed to help inventory executives manage physical inventory items such as spare parts, nuts, and bolts, while asset managers handle asset-related information, user access, and inventory administration.

The application provides backend APIs to perform inventory operations and supports efficient asset tracking and management.

## 🎯 Objectives

- Digitize inventory and asset management operations.
- Maintain organized records of inventory items and assets.
- Simplify inventory retrieval and management.
- Support asset assignment and tracking.
- Provide API endpoints for inventory-related operations.
- Store and manage inventory data using SQL Server.

## ✨ Features

- **Inventory Management:** Manage inventory records through API endpoints.
- **Asset Management:** Maintain information about organizational assets.
- **Asset Tracking and Assignment:** Support tracking and assignment of assets to employees.
- **Inventory Search and Filtering:** Find inventory items based on supported search criteria.
- **Database Integration:** Store and retrieve information from SQL Server.
- **RESTful API:** Expose endpoints for communication between the client and backend.
- **Entity Framework Core:** Support database operations using an object-relational mapper.
- **Category Management:** Organize assets into categories such as computers, laptops, printers, networking equipment, furniture, mobile devices, projectors, software, and other assets.

*Note: Retain only features that you have implemented in your current version of the project.*

## 🛠️ Technologies Used

| Technology | Purpose |
|---|---|
| C# | Backend programming language |
| ASP.NET Core Web API | Building RESTful API endpoints |
| .NET | Application development platform |
| Entity Framework Core | Database access and object-relational mapping |
| SQL Server | Relational database management |
| SQL Server Management Studio (SSMS) | Database administration and querying |
| Swagger / OpenAPI | Testing and documenting API endpoints |

## 🏗️ System Architecture

The application follows a typical API-based architecture:

1. **Client:** Sends HTTP requests to the backend API.
2. **ASP.NET Core Web API:** Receives requests and processes inventory operations.
3. **Entity Framework Core:** Handles database queries and data modifications.
4. **SQL Server:** Stores inventory, asset, and related records.
5. **API Response:** Returns the requested data or operation result to the client.

## 📂 Project Structure

A typical ASP.NET Core Web API project may have the following structure. Adjust it to match your actual files.

```text
InventoryManagementAPI/
│
├── Controllers/
│   ├── AssetsController.cs
│   └── InventoryController.cs
│
├── Models/
│   ├── Asset.cs
│   └── InventoryItem.cs
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── DTOs/
│
├── Migrations/
│
├── Properties/
│
├── appsettings.json
├── Program.cs
├── InventoryManagementAPI.csproj
└── README.md
```

## ⚙️ Prerequisites

Before running the application, ensure that you have installed:

- .NET SDK compatible with the project.
- SQL Server.
- SQL Server Management Studio (SSMS), recommended for database management.
- Visual Studio or Visual Studio Code.
- Swagger UI or another API client for testing endpoints.

## 🚀 Installation and Setup

### 1. Clone the Repository

```bash
git clone <your-repository-url>
cd InventoryManagementAPI
```

### 2. Check the .NET SDK

```bash
dotnet --version
```

Ensure that the installed SDK is compatible with the project's target framework.

### 3. Configure the Database

Open `appsettings.json` and configure the SQL Server connection string according to your local environment.

Example:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=InventoryManagementDB;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Replace the server name, database name, and authentication settings as required by your SQL Server installation. Do not commit production credentials or secrets to GitHub.

### 4. Restore Dependencies

```bash
dotnet restore
```

### 5. Build the Project

```bash
dotnet build
```

Resolve any build errors before proceeding.

### 6. Apply Database Migrations

If the project uses Entity Framework Core migrations, run:

```bash
dotnet ef database update
```

If the Entity Framework Core CLI tool is not installed, install it using:

```bash
dotnet tool install --global dotnet-ef
```

Run the database update command only after confirming that migrations and the connection string are configured correctly.

### 7. Run the Application

```bash
dotnet run
```

The terminal displays the local URLs where the application is listening.

### 8. Test the API

Open the Swagger URL shown in the terminal, commonly:

```text
https://localhost:<port>/swagger
```

Use Swagger UI to inspect the available endpoints and send requests to test the API.

## 🔗 API Endpoints

The exact endpoints depend on the controllers implemented in your project. The following are examples of common inventory API operations.

| HTTP Method | Example Endpoint | Purpose |
|---|---|---|
| GET | `/api/Assets` | Retrieve asset records |
| GET | `/api/Assets/{id}` | Retrieve an asset by ID |
| POST | `/api/Assets` | Create a new asset |
| PUT | `/api/Assets/{id}` | Update an existing asset |
| DELETE | `/api/Assets/{id}` | Delete an asset |
| GET | `/api/Inventory` | Retrieve inventory items |

These are illustrative endpoint patterns, not a guarantee that every route is present in the current implementation. Check the controllers or Swagger documentation for the actual routes and supported methods.

## 🧪 Testing

The API can be tested using Swagger UI, Postman, or another HTTP client.

Suggested test cases:

- Retrieve all assets.
- Retrieve an asset using its ID.
- Create an asset with valid data.
- Update existing asset details.
- Test search and filtering, if implemented.
- Test asset assignment and tracking, if implemented.
- Verify that the data is correctly stored in SQL Server.
- Check the API response when an invalid ID or invalid input is provided.

## 👥 User Roles

### Inventory Executive

Responsible for managing physical inventory items, maintaining inventory records, and supporting stock-related operations.

### Asset Manager

Responsible for asset administration, asset assignment and tracking, and managing user roles or permissions where those capabilities are implemented.

### Employees / Staff

May be associated with assigned organizational assets and their tracking records, depending on the application's implemented functionality.

## 🔮 Future Enhancements

- Low-stock alerts and reorder notifications.
- Inventory transaction history.
- Asset maintenance scheduling.
- Role-based authentication and authorization.
- Dashboard with inventory and asset summaries.
- Exportable inventory reports.
- Audit logs for inventory changes.
- Improved search, sorting, and filtering.
- Frontend integration for easier interaction with the API.

## 🔐 Security Considerations

- Keep database credentials and secrets out of source control.
- Validate incoming API requests.
- Configure authentication and authorization where required.
- Restrict access to sensitive asset and employee information.
- Use HTTPS in deployed environments.
- Apply appropriate database permissions.

## 👨‍💻 Author

**Your Name**

GitHub: [Your GitHub Profile](<your-github-profile-url>)

## 📄 License

This project is developed for educational and learning purposes. Add a suitable license file if you intend to distribute it publicly.
