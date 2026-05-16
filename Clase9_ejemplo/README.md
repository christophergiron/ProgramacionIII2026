# API REST con .NET Core 10 - Clase 9

Proyecto de ejemplo para aprender a crear APIs REST con .NET Core 10.

## Estructura del Proyecto

```
├── Api/                          # Capa de presentación (Minimal API)
│   ├── Endpoints/                # Endpoints de la API
│   │   ├── AuthEndpoints.cs      # Endpoints de autenticación
│   │   └── ProductEndpoints.cs   # Endpoints de productos
│   └── Program.cs                # Configuración de la aplicación
├── Application/                  # Capa de aplicación
│   ├── DTOs/                     # Data Transfer Objects
│   └── Interfaces/               # Contratos (interfaces)
├── Domain/                       # Capa de dominio
│   └── Entities/                # Entidades del negocio
├── Infrastructure/               # Capa de infraestructura
│   ├── Data/                     # DbContext de EF Core
│   ├── Repositories/            # Implementación de repositorios
│   └── Services/                # Servicios (Auth)
├── Clase9_Ejemplo.Tests/        # Proyecto de pruebas
│   ├── Services/                 # Pruebas unitarias de servicios
│   ├── Repositories/             # Pruebas unitarias de repositorios
│   └── Integration/             # Pruebas de integración
├── docker-compose.yml           # Configuración de Docker con PostgreSQL
├── Dockerfile                   # Imagen Docker de la API
└── Clase9_Ejemplo.csproj        # Archivo del proyecto
```

## Requisitos

- .NET SDK 10.0
- Docker y Docker Compose
- PostgreSQL 16 (o usar Docker)

## Configuración

### 1. Configurar PostgreSQL con Docker

```bash
# Iniciar solo PostgreSQL
docker-compose up -d postgres

# Iniciar toda la aplicación
docker-compose up --build
```

### 2. Sin Docker (usando base de datos local)

1. Crear una base de datos PostgreSQL llamada `clase9db`
2. Actualizar la cadena de conexión en `appsettings.json`

## Endpoints de la API

### Autenticación

| Método | Ruta | Descripción | Auth |
|--------|------|-------------|------|
| POST | `/api/auth/register` | Registrar usuario | No |
| POST | `/api/auth/login` | Iniciar sesión | No |

### Productos

| Método | Ruta | Descripción | Auth |
|--------|------|-------------|------|
| GET | `/api/products` | Listar productos | No |
| GET | `/api/products/{id}` | Obtener producto | No |
| POST | `/api/products` | Crear producto | Sí |
| PUT | `/api/products/{id}` | Actualizar producto | Sí |
| DELETE | `/api/products/{id}` | Eliminar producto | Admin |

## Ejecutar la Aplicación

```bash
# Restaurar dependencias
dotnet restore

# Ejecutar la aplicación
dotnet run

# La API estará disponible en http://localhost:8080
# Swagger UI en http://localhost:8080/swagger
```

## Ejecutar Pruebas

```bash
# Todas las pruebas
dotnet test

# Solo pruebas unitarias
dotnet test --filter "FullyQualifiedName~Tests"

# Solo pruebas de integración
dotnet test --filter "FullyQualifiedName~Integration"
```

## Ejemplo de Uso

### 1. Registrar un usuario

```bash
curl -X POST http://localhost:8080/api/auth/register \
  -H "Content-Type: application/json" \
  -d '{
    "username": "testuser",
    "email": "test@example.com",
    "password": "Password123!"
  }'
```

### 2. Iniciar sesión

```bash
curl -X POST http://localhost:8080/api/auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "email": "test@example.com",
    "password": "Password123!"
  }'
```

### 3. Crear un producto (con JWT)

```bash
curl -X POST http://localhost:8080/api/products \
  -H "Content-Type: application/json" \
  -H "Authorization: Bearer YOUR_JWT_TOKEN" \
  -d '{
    "name": "Laptop Dell XPS",
    "description": "Laptop de alta gama",
    "price": 1299.99,
    "stock": 5
  }'
```

### 4. Listar productos

```bash
curl http://localhost:8080/api/products
```

## Características Implementadas

✅ Minimal API con arquitectura Clean Code  
✅ Métodos HTTP (GET, POST, PUT, DELETE)  
✅ Docker con PostgreSQL  
✅ Inyección de dependencias  
✅ Patrón Repositorio  
✅ Autenticación JWT  
✅ Pruebas unitarias con xUnit y Moq  
✅ Pruebas de integración  

## Tecnologías

- **.NET 10.0** - Framework principal
- **Entity Framework Core** - ORM
- **PostgreSQL** - Base de datos
- **JWT** - Autenticación
- **xUnit** - Framework de pruebas
- **Moq** - Mocking
- **FluentAssertions** - Aserciones
- **Docker** - Contenedores
