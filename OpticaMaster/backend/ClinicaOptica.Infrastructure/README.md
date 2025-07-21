# ClinicaOptica.Infrastructure

## 📖 Propósito
Este proyecto implementa la infraestructura del sistema: acceso a base de datos, integración con servicios externos y persistencia de datos.

## 🏗️ Responsabilidades
- Implementar repositorios y acceso a datos (Entity Framework, Dapper, etc.)
- Configurar el DbContext y las migraciones
- Integrar servicios externos (correo, almacenamiento, etc.)
- No contiene lógica de negocio ni controladores de API

## 📂 Estructura principal
- **Repositories/**: Implementaciones de acceso a datos
- **OpticaDbContext.cs**: Contexto de base de datos
- **Migrations/**: Migraciones de base de datos

## 🔗 Relación con otros módulos
- Es llamado por Application para acceder o modificar datos
- Puede exponer servicios para integración externa

---

> Mantén la infraestructura desacoplada de la lógica de negocio y la API. 