# Word Inversion API

ASP.NET Core Web API that **inverts words** in sentences and stores all requests in SQL Server.

## 🚀 Quick Start

## 🔧 Requirements

- .NET SDK 8.x installed  
  Check with: ```dotnet --version```
- SQL Server LocalDB (comes with recent Visual Studio) or any SQL Server instance

## ⚙️ EF Core Tools Setup (dotnet-ef)

If `dotnet ef` is not available or you see errors about `dotnet-ef`:

### 1. Install EF CLI globally with a specific version

dotnet tool uninstall --global dotnet-ef 2> NUL
dotnet tool install --global dotnet-ef --version 8.0.10 --ignore-failed-sources

Verify:

```dotnet ef --version```

## 🚀 First-Time Setup After Clone

From the project folder:

```
dotnet --version # confirm .NET 8.x
dotnet restore # restore NuGet packages
dotnet ef migrations add InitialCreate 
dotnet ef database update # creates/updates the database
dotnet run # start the API
```
[Swagger UI](http://localhost:5000/swagger) 

## 🔄 Subsequent Runs

After the first setup on a machine, you normally only need:

```
dotnet restore # if packages changed
dotnet run
```

## NOTE: You do **not** need to run `Add-Migration` again unless you change the model.

## 📡 API Endpoints

| Method | Endpoint | Description |
|--------|----------|-------------|
| `POST` | `/api/wordinversion/invert` | `"hello world"` → `"olleh dlrow"` |
| `GET`  | `/api/wordinversion/all` | Get all records |
| `GET`  | `/api/wordinversion/find/{word}` | Search by word |

## 🏗️ Architecture

```
Controller → Service → EF Core → SQL Server LocalDB
```

## 💾 Database

**Table**: `WordInversions` (Id, RequestText, ResponseText, CreatedDate)

**View data**: Visual Studio → SQL Server Object Explorer → `(localdb)\MSSQLLocalDB`

## 🛠️ Tech Stack

- ASP.NET Core 8.0
- Entity Framework Core 8.0
- SQL Server LocalDB
- Swagger UI
- Dependency Injection

## 📱 Test It

1. **POST** `/invert` → `"abc def"`
2. **GET** `/all` → See saved record
3. **GET** `/find/abc` → Filtered results
```
