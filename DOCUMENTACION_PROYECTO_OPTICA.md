# 👁️ Sistema de Gestión de Óptica – Guía Completa con Microservicios (.NET + React + IA)

¡Bienvenido! Este repositorio contiene una aplicación web profesional para la gestión de una óptica, diseñada como una **guía educativa paso a paso** para aprender desarrollo fullstack moderno. Aprenderás a crear un sistema real usando .NET (C#), PostgreSQL, React.js, Python para IA, y buenas prácticas de arquitectura (hexagonal, vertical slicing, microservicios, JWT, Swagger, etc.).

> 📚 **Ideal para principiantes**: Te explicamos cada concepto, comando y decisión técnica de forma clara, para que comprendas y construyas tu propio sistema mientras aprendes paso a paso.

---

## 🧑‍💻 Autor

**Francisco Leonardo Martínez Nicolás**  
Estudiante | Apasionado por el desarrollo de software  
📍 México

---

## 🚀 Tecnologías y Herramientas

| Tecnología                | ¿Para qué sirve?                                       |
|---------------------------|--------------------------------------------------------|
| **.NET 8+ (C#)**          | Backend profesional (API REST, lógica de negocio, autenticación) |
| **PostgreSQL**            | Base de datos relacional para guardar información     |
| **React.js + TailwindCSS**| Frontend moderno (la parte visual que usan los usuarios) |
| **Python (Flask)**        | Microservicio de IA para reconocimiento facial        |
| **OpenCV + Mediapipe**    | Procesamiento de imágenes e inteligencia artificial   |
| **Swagger**               | Documentación y pruebas automáticas de la API         |
| **JWT**                   | Autenticación y autorización segura                   |
| **Git + GitHub**          | Control de versiones y trabajo ordenado               |
| **Docker** (opcional)     | Contenedores para despliegue profesional              |

---

## 📂 Estructura del Proyecto (Arquitectura Profesional)

```
/clinica-optica
  /backend                # API principal en .NET (C#)
    /ClinicaOptica.Api           # Controladores y endpoints
    /ClinicaOptica.Application   # Lógica de aplicación
    /ClinicaOptica.Domain        # Modelos y entidades
    /ClinicaOptica.Infrastructure # Acceso a datos
    /ClinicaOptica.Tests         # Pruebas unitarias
  /frontend               # React.js + TailwindCSS
  /ia-service             # Microservicio Python (Flask, OpenCV, Mediapipe)
  /docs                   # Documentación adicional
  /docker                 # Archivos de configuración para Docker
```

---

## ⚙️ Instalación de Herramientas (Paso a Paso para Windows)

### 📥 ¿Qué necesitas instalar y por qué?

#### 1. .NET SDK
- **¿Para qué?** Crear el backend profesional
- **Instalación:** [Descargar .NET](https://dotnet.microsoft.com/download) (versión 8.0 o superior recomendada)

#### 2. PostgreSQL
- **¿Para qué?** Base de datos donde guardamos toda la información
- **Instalación:** [Descargar PostgreSQL](https://www.postgresql.org/download/windows/)
- ⚠️ **Importante:** Recuerda el usuario y contraseña que pongas

#### 3. Git
- **¿Para qué?** Controlar versiones de tu código
- **Instalación:** [Descargar Git](https://git-scm.com/download/win)

#### 4. Python
- **¿Para qué?** Microservicio de inteligencia artificial
- **Instalación:** [Descargar Python](https://www.python.org/downloads/windows/)
- ✅ **Importante:** Marca "Add Python to PATH" durante la instalación

#### 5. Node.js
- **¿Para qué?** Frontend con React.js
- **Instalación:** [Descargar Node.js](https://nodejs.org/) (versión LTS)

#### 6. Docker (Opcional)
- **¿Para qué?** Despliegue profesional con contenedores
- **Instalación:** [Descargar Docker Desktop](https://www.docker.com/products/docker-desktop/)

---

## 🏗️ Creación del Proyecto (Paso a Paso)

### Paso 1: Crear la carpeta principal

```bash
# Crear carpeta del proyecto
mkdir clinica-optica
cd clinica-optica
```

### Paso 2: Configurar el Backend (.NET)

```bash
# Crear estructura del backend
mkdir backend && cd backend

# Crear solución .NET
dotnet new sln -n ClinicaOptica

# Crear proyectos
dotnet new webapi -n ClinicaOptica.Api
dotnet new classlib -n ClinicaOptica.Application
dotnet new classlib -n ClinicaOptica.Domain
dotnet new classlib -n ClinicaOptica.Infrastructure
dotnet new xunit -n ClinicaOptica.Tests

# Agregar proyectos a la solución
dotnet sln add ./ClinicaOptica.Api/ClinicaOptica.Api.csproj
dotnet sln add ./ClinicaOptica.Application/ClinicaOptica.Application.csproj
dotnet sln add ./ClinicaOptica.Domain/ClinicaOptica.Domain.csproj
dotnet sln add ./ClinicaOptica.Infrastructure/ClinicaOptica.Infrastructure.csproj
dotnet sln add ./ClinicaOptica.Tests/ClinicaOptica.Tests.csproj
```

### Paso 3: Configurar el Frontend (React.js)

```bash
# Volver a la carpeta principal
cd ..

# Crear aplicación React
npx create-react-app frontend
cd frontend

# Instalar TailwindCSS
npm install tailwindcss
npx tailwindcss init
```

### Paso 4: Configurar Microservicio de IA (Python)

```bash
# Volver a la carpeta principal
cd ..

# Crear microservicio de IA
mkdir ia-service && cd ia-service

# Crear entorno virtual
python -m venv venv

# Activar entorno virtual (Windows)
venv\Scripts\activate

# Instalar dependencias
pip install flask opencv-python mediapipe
```

---

## 🗄️ Modelo de Base de Datos (PostgreSQL)

### ¿Qué es una base de datos?
Es donde guardamos toda la información del sistema (pacientes, exámenes, productos, ventas, etc.).

### Crear la base de datos

```sql
-- 1. Crear la base de datos
CREATE DATABASE optica;

-- 2. Usar la base de datos y crear las tablas
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

## 🧠 Desarrollo del Backend (.NET)

### Instalar paquetes necesarios

```bash
cd backend/ClinicaOptica.Api

# Entity Framework Core para PostgreSQL
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

# Swagger para documentación
dotnet add package Swashbuckle.AspNetCore

# JWT para autenticación
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

### Configurar conexión a base de datos

**appsettings.json:**
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Database=optica;Username=tu_usuario;Password=tu_contraseña"
  }
}
```

**Program.cs:**
```csharp
builder.Services.AddDbContext<OpticaDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

## 🖼️ Desarrollo del Frontend (React.js)

- Crear componentes para cada módulo (Pacientes, Ventas, Productos, Login)
- Conectar frontend a la API usando fetch o axios
- Implementar autenticación con JWT
- Diseño responsivo con TailwindCSS

---

## 🤖 Microservicio de IA (Python)

- Reconocimiento facial con OpenCV y Mediapipe
- Sugerencias de armazón basadas en forma del rostro
- API Flask para comunicarse con el backend .NET
- Procesamiento de imágenes en tiempo real

---

## 🧪 Comandos Útiles para Desarrollo

### Backend (.NET)
```bash
# Ejecutar API
dotnet run --project ClinicaOptica.Api

# Ejecutar pruebas
dotnet test

# Crear migración
dotnet ef migrations add InitialCreate

# Aplicar migración
dotnet ef database update
```

### Frontend (React)
```bash
# Iniciar desarrollo
npm start

# Construir para producción
npm run build

# Ejecutar pruebas
npm test
```

### Microservicio IA (Python)
```bash
# Activar entorno virtual
venv\Scripts\activate

# Ejecutar Flask
python app.py
```

---

## 🔐 Seguridad y Buenas Prácticas

- ✅ Autenticación JWT con roles y permisos
- ✅ Validación de entrada y salida de datos
- ✅ Protección de datos sensibles
- ✅ HTTPS en producción
- ✅ Cumplimiento con leyes de protección de datos

---

## 🚀 Instalación Rápida (Para desarrolladores)

```bash
# Clonar repositorio
git clone https://github.com/tu-usuario/clinica-optica.git
cd clinica-optica

# Backend
cd backend
dotnet restore
dotnet ef database update
dotnet run --project ClinicaOptica.Api

# Frontend (nueva terminal)
cd frontend
npm install
npm start

# IA Service (nueva terminal)
cd ia-service
pip install -r requirements.txt
python app.py
```

---

## 🛣️ Próximos Pasos y Mejoras

- [ ] Entrenamiento de modelos propios de IA
- [ ] Microservicios adicionales (facturación, inventario)
- [ ] Dashboard de estadísticas y reportes
- [ ] Integración con sistemas de facturación
- [ ] Despliegue en la nube (Azure/AWS)
- [ ] Aplicación móvil (React Native)

---

## 🤝 Contribuciones

¡Las contribuciones son bienvenidas! Si quieres mejorar este proyecto:

1. Fork el repositorio
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

---

## 📞 Contacto y Soporte

Si tienes dudas o necesitas ayuda:

📧 **Email:** francisco.leonardo.martinez.nicolas[@]outlook.com  
🌍 **Ubicación:** México  
💼 **LinkedIn:** [Tu perfil de LinkedIn]  

---

## 📄 Licencia

Este proyecto está bajo la Licencia MIT - mira el archivo [LICENSE](LICENSE) para más detalles.

---

**¡Gracias por visitar este proyecto! 🙌 Vamos paso a paso y construyamos algo increíble juntos. Si tienes dudas, no hesites en contactarme.** 

---

*Última actualización: Julio 2025*