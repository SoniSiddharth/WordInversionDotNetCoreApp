# WordInversionDotNetCoreApp
Given a sentence, the web application provides a few endpoints for inverting the words, storing them, and a search functionality

```markdown
<div align="center">

# 🔄 Word Inversion API

[![.NET](https://github.com/yourusername/WordInversionApi/actions/workflows/dotnet.yml/badge.svg)](https://github.com/yourusername/WordInversionApi/actions/workflows/dotnet.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)
[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/8.0)

**REST API that inverts words in sentences** (e.g., "hello world" → "olleh dlrow") with **full audit trail** stored in SQL Server.

</div>

## ✨ **Features**

- 🔀 **Word Inversion** - Reverse each word in a sentence
- 💾 **Persistent Storage** - Every request/response logged to database
- 🔍 **Search** - Find records by word in request/response
- 📊 **Audit Trail** - Complete history with timestamps
- 🛠️ **Clean Architecture** - Controllers → Services → Data layers
- 📱 **Swagger UI** - Interactive API documentation
- 🐳 **Docker Ready** - Containerized deployment

## 🏗️ **Tech Stack**

| Layer | Technology |
|-------|------------|
| **API** | ASP.NET Core 8.0 Web API |
| **ORM** | Entity Framework Core 8.0 |
| **Database** | SQL Server LocalDB (Dev) / SQL Server |
| **DI** | Built-in Dependency Injection |
| **API Docs** | Swagger / OpenAPI |

## 🚀 **Quick Start**

### **Prerequisites**
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server LocalDB](https://learn.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb) (included with Visual Studio)

### **1. Clone & Restore**
```
git clone https://github.com/yourusername/WordInversionApi.git
cd WordInversionApi
dotnet restore
```

### **2. Database Setup**
```
# Package Manager Console (Visual Studio) OR Terminal
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### **3. Run API**
```
dotnet run
```
**Swagger UI**: `http://localhost:5000/swagger`

## 📡 **API Endpoints**

| Method | Endpoint | Description | Example |
|--------|----------|-------------|---------|
| `POST` | `/api/wordinversion/invert` | **Invert words** in sentence | `{"request": "hello world", "response": "olleh dlrow"}` |
| `GET` | `/api/wordinversion/all` | **List all** requests | `[{id:1, request:"hello world", response:"olleh dlrow"}] |
| `GET` | `/api/wordinversion/find/{word}` | **Search by word** | `/find/hello` → matching records |

### **Sample Usage**
```
# 1. Invert words
curl -X POST "http://localhost:5000/api/wordinversion/invert" \
  -H "Content-Type: application/json" \
  -d '"abc def ghi"'

# 2. Get all records
curl "http://localhost:5000/api/wordinversion/all"

# 3. Search by word
curl "http://localhost:5000/api/wordinversion/find/abc"
```

## 🏛️ **Architecture Overview**

```
┌─────────────────┐    ┌──────────────────┐    ┌─────────────────┐
│   HTTP Request  │───▶│  Controllers     │───▶│   Services      │
│  (Swagger/Postman)│    │                   │    │ (Business Logic)│
└─────────────────┘    └──────────────────┘    └─────────────────┘
                                                        │
                                               ┌─────────────────┐
                                               │   AppDbContext  │
                                               │  (EF Core)      │
                                               └─────────────────┘
                                                        │
                                               ┌─────────────────┐
                                               │ SQL Server      │
                                               │ WordInversions  │
                                               └─────────────────┘
```

## 💉 **Dependency Injection Setup**

**Program.cs** - Clean DI registration:
```
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IWordInversionService, WordInversionService>();
```

**Flow**: `Controller` → `[Inject] IWordInversionService` → `AppDbContext` → **Database**

## 🗄️ **Database Schema**

```
CREATE TABLE WordInversions (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RequestText NVARCHAR(500) NOT NULL,
    ResponseText NVARCHAR(500) NOT NULL,
    CreatedDate DATETIME2 DEFAULT GETUTCDATE()
);
```

**View Data**: Visual Studio → **SQL Server Object Explorer** → `(localdb)\MSSQLLocalDB` → `WordInversionDb`

## 🐳 **Docker (Optional)**

```
FROM mcr.microsoft.com/dotnet/aspnet:8.0
COPY . .
WORKDIR /app
ENTRYPOINT ["dotnet", "WordInversionApi.dll"]
```

```
docker build -t wordinversion-api .
docker run -p 5000:80 wordinversion-api
```

## 🔧 **Development Workflow**

```
1. Code → Add/WordInversion.cs (Model changes)
2. Add-Migration UpdateModel ← Generates migration
3. Update-Database           ← Applies to DB
4. dotnet run                ← Test API
```

## 📱 **Testing with Swagger**

1. **F5** → Swagger UI auto-opens
2. **Try POST /invert** → `"hello world"`
3. **Check GET /all** → See saved record
4. **Search GET /find/hello** → Filtered results

## 🛠️ **Project Structure**

```
WordInversionApi/
├── Controllers/           # HTTP endpoints
│   └── WordInversionController.cs
├── Services/             # Business logic + DI
│   ├── IWordInversionService.cs
│   └── WordInversionService.cs
├── Data/                 # EF Core
│   └── AppDbContext.cs
├── Models/               # Database models
│   └── WordInversion.cs
├── Properties/           # Config
│   └── launchSettings.json
├── Migrations/           # EF Migrations
└── Program.cs            # DI + Pipeline
```

## 📈 **Word Inversion Algorithm**

```
public string InvertWords(string sentence)
{
    var words = sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    var inverted = words.Select(word => new string(word.Reverse().ToArray()));
    return string.Join(" ", inverted);
}
// "abc def" → "cba fed"
```

## 🤝 **Contributing**

1. Fork the repo
2. Create feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add some AmazingFeature'`)
4. Push (`git push origin feature/AmazingFeature`)
5. Open Pull Request

## 📄 **License**

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 **Acknowledgments**

- [ASP.NET Core](https://dotnet.microsoft.com/apps/aspnet)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [Swagger](https://swagger.io/)

---

<div align="center">
<sub>Built with ❤️ for developers by developers</sub>
</div>
```

**Copy this entire text → Create `README.md` → Perfect GitHub repo!** 🎉
