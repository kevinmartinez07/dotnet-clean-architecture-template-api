# .NET Clean Architecture Template API

Una plantilla de API RESTful desarrollada con .NET 9 siguiendo los principios de Clean Architecture (Arquitectura Limpia), diseñada para ser escalable, mantenible y testeable.

## 📋 Tabla de Contenidos

- [Características](#-características)
- [Arquitectura](#-arquitectura)
- [Tecnologías](#-tecnologías)
- [Requisitos Previos](#-requisitos-previos)
- [Instalación](#-instalación)
- [Estructura del Proyecto](#-estructura-del-proyecto)
- [Patrones Implementados](#-patrones-implementados)
- [Uso](#-uso)
- [Contribuir](#-contribuir)

## ✨ Características

- ✅ **Clean Architecture** - Separación clara de responsabilidades en 4 capas
- ✅ **CQRS Pattern** - Implementado con MediatR
- ✅ **Result Pattern** - Manejo de errores funcional y type-safe
- ✅ **Repository Pattern** - Abstracción del acceso a datos
- ✅ **Unit of Work** - Gestión de transacciones
- ✅ **Validation Pipeline** - Validación automática con FluentValidation
- ✅ **JWT Authentication** - Autenticación basada en tokens
- ✅ **OpenAPI/Swagger** - Documentación automática de la API
- ✅ **Dependency Injection** - Inyección de dependencias nativa de .NET
- ✅ **.NET 9** - Última versión de .NET

## 🏛️ Arquitectura

Este proyecto sigue los principios de Clean Architecture, organizando el código en 4 capas principales:

```
┌─────────────────────────────────────────────────────────┐
│                    Presentation Layer                    │
│              (API Controllers, Middleware)               │
└────────────────────┬────────────────────────────────────┘
                     │
┌────────────────────▼────────────────────────────────────┐
│                  Application Layer                       │
│         (Use Cases, DTOs, Interfaces, CQRS)             │
└────────────────────┬────────────────────────────────────┘
                     │
┌────────────────────▼────────────────────────────────────┐
│                Infrastructure Layer                      │
│      (Data Access, External Services, Security)         │
└────────────────────┬────────────────────────────────────┘
                     │
┌────────────────────▼────────────────────────────────────┐
│                    Domain Layer                          │
│            (Entities, Enums, Domain Logic)              │
└─────────────────────────────────────────────────────────┘
```

### Principios de Dependencia

- Las capas externas dependen de las capas internas
- El dominio no tiene dependencias externas
- La lógica de negocio está aislada de frameworks e infraestructura

## 🛠️ Tecnologías

- **[.NET 9](https://dotnet.microsoft.com/)** - Framework principal
- **[MediatR](https://github.com/jbogard/MediatR)** - Implementación de CQRS y patrón Mediator
- **[FluentValidation](https://fluentvalidation.net/)** - Validación de datos
- **[Entity Framework Core](https://docs.microsoft.com/ef/core/)** - ORM para acceso a datos
- **[JWT Bearer](https://jwt.io/)** - Autenticación basada en tokens
- **[OpenAPI](https://www.openapis.org/)** - Especificación y documentación de API

## 📦 Requisitos Previos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- [Visual Studio 2026](https://visualstudio.microsoft.com/) o [VS Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/sql-server) (u otro proveedor de base de datos)

## 🚀 Instalación

### 1. Clonar el repositorio

```bash
git clone https://github.com/tu-usuario/dotnet-clean-architecture-template-api.git
cd dotnet-clean-architecture-template-api
```

### 2. Restaurar dependencias

```bash
dotnet restore
```

### 3. Configurar la base de datos

Actualiza la cadena de conexión en `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=YourDb;Trusted_Connection=true;"
  }
}
```

### 4. Aplicar migraciones

```bash
dotnet ef database update --project template-clean-arq-api.Infrastructure --startup-project template-clean-arq-api.Presentation
```

### 5. Ejecutar la aplicación

```bash
dotnet run --project template-clean-arq-api.Presentation
```

La API estará disponible en `https://localhost:5001` y la documentación Swagger en `https://localhost:5001/openapi`.

## 📁 Estructura del Proyecto

### 🎯 Domain Layer (`template-clean-arq-api.Domain`)

Contiene la lógica de negocio central y las entidades del dominio.

```
Domain/
├── Entities/           # Entidades del dominio
│   └── User.cs
├── Enums/             # Enumeraciones
│   └── ErrorType.cs
└── Errors/            # Definiciones de errores del dominio
    ├── Error.cs
    └── DomainErrors.cs
```

**Responsabilidades:**
- Definir entidades y agregados
- Lógica de negocio pura
- Definición de errores del dominio
- Sin dependencias externas

### 💼 Application Layer (`template-clean-arq-api.Application`)

Contiene los casos de uso y la lógica de aplicación.

```
Application/
├── Abstraction/       # Interfaces y contratos
│   ├── IUnitOfWork.cs
│   ├── IJwtService.cs
│   └── IPasswordService.cs
├── UseCases/          # Casos de uso (CQRS)
│   └── Users/
│       ├── Commands/  # Comandos (escritura)
│       └── Queries/   # Consultas (lectura)
├── Dtos/             # Data Transfer Objects
├── Models/           # Modelos de respuesta
│   ├── ApiResponse.cs
│   └── PaginationResponse.cs
└── Commons/          # Utilidades compartidas
    ├── Result.cs
    └── ValidationResult.cs
```

**Responsabilidades:**
- Definir casos de uso (Commands y Queries)
- DTOs y mapeos
- Validaciones con FluentValidation
- Interfaces de servicios

### 🔧 Infrastructure Layer (`template-clean-arq-api.Infrastructure`)

Implementa los detalles de infraestructura y acceso a datos.

```
Infrastructure/
├── Persistence/
│   ├── Context/              # DbContext de EF Core
│   ├── DataBaseConfigurations/ # Configuración de entidades
│   └── Repositories/         # Implementación de repositorios
├── Services/
│   ├── Security/            # Servicios de seguridad
│   │   ├── JwtService.cs
│   │   └── PasswordService.cs
│   ├── HeaderValidator.cs
│   └── Helper.cs
└── Commons/
    ├── JwtSettings.cs
    └── Constants/
```

**Responsabilidades:**
- Implementación de repositorios
- Configuración de Entity Framework
- Servicios externos
- Seguridad y autenticación

### 🌐 Presentation Layer (`template-clean-arq-api.Presentation`)

Capa de presentación con controladores y middleware.

```
Presentation/
├── Controllers/         # Controladores de API
│   └── UserController.cs
├── Middleware/         # Middleware personalizado
├── Extensions/         # Extensiones
│   └── ResultExtensions.cs
├── HelperPresentation/ # Helpers de presentación
├── appsettings.json
└── Program.cs         # Punto de entrada
```

**Responsabilidades:**
- Controladores de API
- Middleware
- Configuración de servicios
- Manejo de respuestas HTTP

## 🎨 Patrones Implementados

### CQRS (Command Query Responsibility Segregation)

Separa las operaciones de lectura y escritura usando MediatR:

```csharp
// Command (escritura)
public record CreateUserCommand(string Email, string Password) : IRequest<Result<Guid>>;

// Query (lectura)
public record GetUserByIdQuery(Guid Id) : IRequest<Result<UserDto>>;
```

### Result Pattern

Manejo de errores funcional sin excepciones:

```csharp
public async Task<Result<User>> GetUserAsync(Guid id)
{
    var user = await _repository.GetByIdAsync(id);
    
    if (user is null)
        return Result.Failure<User>(DomainErrors.User.NotFound);
    
    return Result.Success(user);
}
```

### Repository Pattern

Abstracción del acceso a datos:

```csharp
public interface IUserRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAsync();
    void Add(User user);
    void Update(User user);
    void Delete(User user);
}
```

### Unit of Work

Gestión de transacciones:

```csharp
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
```

## 📖 Uso

### Crear un nuevo caso de uso

1. **Crear el comando/query en Application/UseCases:**

```csharp
public record CreateUserCommand(string Email, string Password) 
    : IRequest<Result<Guid>>;
```

2. **Crear el handler:**

```csharp
public class CreateUserCommandHandler 
    : IRequestHandler<CreateUserCommand, Result<Guid>>
{
    private readonly IUserRepository _repository;
    private readonly IUnitOfWork _unitOfWork;

    public async Task<Result<Guid>> Handle(
        CreateUserCommand request, 
        CancellationToken cancellationToken)
    {
        // Lógica del caso de uso
    }
}
```

3. **Crear el validador:**

```csharp
public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Password).MinimumLength(8);
    }
}
```

4. **Usar en el controlador:**

```csharp
[HttpPost]
public async Task<IActionResult> Create(CreateUserCommand command)
{
    var result = await _mediator.Send(command);
    return result.IsSuccess 
        ? Ok(result.Value) 
        : BadRequest(result.Error);
}
```

## 🤝 Contribuir

Las contribuciones son bienvenidas. Por favor:

1. Fork el proyecto
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

## 📄 Licencia

Este proyecto es una plantilla de código abierto para uso libre.

## 👤 Autor

Tu nombre - [@kevinmartinez07](https://github.com/kevinmartinez07)

## 🙏 Agradecimientos

- [Clean Architecture by Uncle Bob](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Microsoft .NET Documentation](https://docs.microsoft.com/dotnet/)
- [MediatR](https://github.com/jbogard/MediatR)

---

⭐ Si esta plantilla te ha sido útil, considera darle una estrella en GitHub!