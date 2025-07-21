# ClinicaOptica.Api

## 📖 Propósito
Este proyecto expone la API REST del sistema de gestión de óptica. Es el punto de entrada para todas las solicitudes HTTP y se encarga de la comunicación entre el frontend, la lógica de negocio y los servicios externos.

## 🏗️ Responsabilidades
- Definir y exponer los endpoints públicos (controladores)
- Gestionar la autenticación y autorización (JWT, roles)
- Validar la entrada y salida de datos (DTOs, ModelState)
- Configurar middlewares (Swagger, CORS, logging, etc.)
- No contiene lógica de negocio ni acceso directo a la base de datos

## 📂 Estructura principal
- **Controllers/**: Controladores de la API
- **Program.cs**: Configuración de servicios y pipeline
- **appsettings.json**: Configuración de la aplicación

## 🔗 Relación con otros módulos
- Llama a servicios de Application para ejecutar la lógica de negocio
- Recibe datos del frontend y responde con resultados o errores

---

> Para detalles de endpoints y pruebas, consulta la documentación de Swagger generada automáticamente. 