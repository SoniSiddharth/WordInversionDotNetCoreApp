# WordInversionDotNetCoreApp
Given a sentence, the web application provides a few endpoints for inverting the words, storing them, and a search functionality

```markdown
# Word Inversion API

ASP.NET Core Web API that **inverts words** in sentences and stores all requests in SQL Server.

## 🚀 Quick Start

```
dotnet restore
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet run
```

**Swagger**: `http://localhost:5000/swagger`

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