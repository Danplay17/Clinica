# Guía Paso a Paso para Crear tu Sistema de Gestión de Óptica (Versión .NET Microservicios)

## 1. Introducción para Principiantes

¡Bienvenido! En esta guía aprenderás a crear una aplicación web profesional para la gestión de una óptica, desde cero y sin experiencia previa, usando tecnologías modernas como .NET (C#), PostgreSQL, React.js, Python para IA, y buenas prácticas de arquitectura (hexagonal, vertical slicing, microservicios, JWT, Swagger, etc.). Te explicaré cada concepto, comando y decisión, para que puedas entender y construir tu propio sistema, aprendiendo en el camino.

---

## 2. Herramientas necesarias e instalación
### ¿Qué vamos a usar y para qué sirve?

- **.NET 8 + (C#):** Para crear el backend profesional (API REST, lógica de negocio, autenticación, etc.).
- **PostgreSQL:** Para guardar la información (base de datos relacional).
- **React.js + TailwindCSS:** Para crear el frontend moderno (la parte visual que usan los usuarios).
- **Python (Flask, OpenCV, Mediapipe):** Para la inteligencia artificial y el reconocimiento facial (microservicio).
- **Swagger:** Para documentar y probar la API automáticamente.
- **JWT:** Para autenticación y autorización segura.
- **Git:** Para controlar las versiones de tu código y trabajar de forma ordenada.
- **Docker (opcional):** Para contenedores y despliegue profesional.

### ¿Cómo instalar cada herramienta? (Windows)

#### .NET SDK
1. Ve a la página oficial: https://dotnet.microsoft.com/download
2. Descarga la versión más reciente (recomendada 7.0 o superior).
3. Instala siguiendo los pasos del instalador.

#### PostgreSQL
1. Ve a: https://www.postgresql.org/download/windows/
2. Descarga el instalador y sigue los pasos.
3. Recuerda el usuario y contraseña que pongas, los usaremos después.

#### Git
1. Ve a: https://git-scm.com/download/win
2. Descarga e instala.

#### Python
1. Ve a: https://www.python.org/downloads/windows/
2. Descarga la última versión.
3. Durante la instalación, marca la casilla que dice "Add Python to PATH".

#### Node.js y React.js
1. Ve a: https://nodejs.org/
2. Descarga la versión LTS.
3. Instala siguiendo los pasos del instalador.
4. React.js se crea con un comando que veremos más adelante.

#### Docker (opcional)
1. Ve a: https://www.docker.com/products/docker-desktop/
2. Descarga e instala Docker Desktop.

---

## 3. Creación del Proyecto y Estructura Profesional

### Estructura recomendada

```
/clinica-optica
  /backend                # API principal en .NET (C#)
    /ClinicaOptica.Api
    /ClinicaOptica.Application
    /ClinicaOptica.Domain
    /ClinicaOptica.Infrastructure
    /ClinicaOptica.Tests
  /frontend               # React.js + TailwindCSS
  /ia-service             # Microservicio Python (Flask, OpenCV, Mediapipe)
  /docs                   # Documentación adicional/manual de usuario
  /docker                 # Archivos de configuración para Docker Compose
```

### Paso 1: Crear la carpeta principal

Abre la terminal (puedes usar PowerShell) y ejecuta:

```bash
mkdir OpticaMaster
cd clinica-optica
```
Esto crea una carpeta para tu proyecto y entras en ella.

### Paso 2: Inicializar el backend en .NET

```bash
mkdir backend
cd backend

dotnet new sln -n ClinicaOptica

dotnet new webapi -n ClinicaOptica.Api

dotnet new classlib -n ClinicaOptica.Application

dotnet new classlib -n ClinicaOptica.Domain

dotnet new classlib -n ClinicaOptica.Infrastructure

dotnet new xunit -n ClinicaOptica.Tests

dotnet sln add ./ClinicaOptica.Api/ClinicaOptica.Api.csproj

dotnet sln add ./ClinicaOptica.Application/ClinicaOptica.Application.csproj

dotnet sln add ./ClinicaOptica.Domain/ClinicaOptica.Domain.csproj

dotnet sln add ./ClinicaOptica.Infrastructure/ClinicaOptica.Infrastructure.csproj

dotnet sln add ./ClinicaOptica.Tests/ClinicaOptica.Tests.csproj
```

### Paso 3: Inicializar el frontend

Vuelve a la carpeta principal y ejecuta:

```bash
cd ..
npx create-react-app frontend
cd frontend
npm install tailwindcss
npx tailwindcss init
```
Esto crea la carpeta `frontend` con todo lo necesario para empezar a programar la parte visual.

### Paso 4: Inicializar el microservicio de IA (Python)

```bash
mkdir ia-service
cd ia-service
python -m venv venv
venv\Scripts\activate  # En Windows
pip install flask opencv-python mediapipe
```
Esto crea el entorno y las dependencias para el microservicio de IA.

---

## 4. Modelado de la Base de Datos (PostgreSQL)

### ¿Qué es una base de datos?

Es un lugar donde se guarda toda la información de tu sistema (pacientes, exámenes, productos, ventas, etc.).

### ¿Cómo crear la base de datos y las tablas?
`hasta aqui vamos`
1. Abre la aplicación de PostgreSQL (puede ser pgAdmin o la terminal).
2. Crea una base de datos llamada `optica`.
3. Ejecuta los comandos SQL que tienes en tu documentación para crear las tablas.

Ejemplo:
```sql
CREATE DATABASE optica;
-- Luego selecciona la base de datos y ejecuta los comandos para crear las tablas.
```

Aquí tienes un ejemplo de las tablas principales:

```sql
CREATE TABLE pacientes (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(100),
    genero VARCHAR(10),
    edad INT,
    estado_civil VARCHAR(20),
    escolaridad VARCHAR(50),
    ocupacion VARCHAR(50),
    domicilio VARCHAR(150),
    email VARCHAR(100),
    telefono VARCHAR(20),
    tutor VARCHAR(100)
);

CREATE TABLE examenes (
    id SERIAL PRIMARY KEY,
    paciente_id INT REFERENCES pacientes(id),
    fecha DATE,
    prediagnostico TEXT,
    diagnostico TEXT,
    plan_tratamiento TEXT,
    pronostico TEXT,
    proximacita DATE
);

CREATE TABLE antecedentes (
    examen_id INT REFERENCES examenes(id),
    familiares TEXT,
    no_patologicos TEXT,
    patologicos TEXT,
    padecimiento_actual TEXT
);

CREATE TABLE productos (
    id SERIAL PRIMARY KEY,
    nombre VARCHAR(100),
    tipo VARCHAR(50),
    descripcion TEXT,
    precio DECIMAL,
    stock INT
);

CREATE TABLE ventas (
    id SERIAL PRIMARY KEY,
    paciente_id INT REFERENCES pacientes(id),
    producto_id INT REFERENCES productos(id),
    fecha DATE,
    cantidad INT,
    total DECIMAL
);
```

---

## 5. Desarrollo del Backend en .NET (C#)

Aquí vamos a crear la lógica para manejar los datos usando Entity Framework Core y arquitectura profesional.

- Instala Entity Framework Core y el proveedor de PostgreSQL:

```bash
cd backend/ClinicaOptica.Api

dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

dotnet add package Swashbuckle.AspNetCore

dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

- Crea tus modelos (clases C#) en el proyecto Domain:

```csharp
public class Paciente
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    // ...otros campos
}
```

- Crea el DbContext en Infrastructure:

```csharp
public class OpticaDbContext : DbContext
{
    public OpticaDbContext(DbContextOptions<OpticaDbContext> options) : base(options) { }
    public DbSet<Paciente> Pacientes { get; set; }
    // ...otros DbSet
}
```

- Configura la conexión en `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=optica;Username=tu_usuario;Password=tu_contraseña"
}
```

- En `Program.cs` agrega:

```csharp
builder.Services.AddDbContext<OpticaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
```

- Usa la arquitectura hexagonal y vertical slicing: separa por features (Pacientes, Ventas, Diagnóstico, etc.) y por capas (Domain, Application, Infrastructure, Api).

- Implementa autenticación JWT y documenta la API con Swagger (ya viene integrado en .NET Web API).

---

## 6. Desarrollo del Frontend (React.js + TailwindCSS)

- Crea componentes para cada módulo (Pacientes, Ventas, Productos, Login, etc.).
- Conecta el frontend a la API de .NET usando fetch o axios.
- Implementa autenticación y consumo de endpoints protegidos con JWT.

---

## 7. Integración de IA (Microservicio Python)

- Crea un microservicio Flask para reconocimiento facial y sugerencias de armazón.
- Usa OpenCV y Mediapipe para procesar imágenes.
- Expón endpoints HTTP para que la API de .NET pueda enviar imágenes y recibir resultados.

---

## 8. Pruebas y Documentación

- Usa xUnit para pruebas unitarias en .NET.
- Usa Swagger para documentar y probar la API.
- Controla versiones con Git y GitHub.

---

## 9. Seguridad y Buenas Prácticas

- Protege los datos sensibles, usa HTTPS, valida entradas y salidas.
- Implementa roles y permisos con JWT.
- Cumple con las leyes de protección de datos.

---

## 10. Futuras Mejoras

- Entrenamiento de modelos propios de IA.
- Microservicios adicionales para otras funcionalidades.
- Mejoras en la seguridad y escalabilidad.

---

¡Listo! Cuando termines de leer y quieras empezar, dime y avanzamos juntos paso a paso, resolviendo cualquier duda que tengas en el proceso.
