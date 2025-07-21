# ClinicaOptica.Application

## 📖 Propósito
Este proyecto contiene la lógica de negocio y los casos de uso del sistema de óptica. Es el corazón de la aplicación y define cómo se resuelven los procesos principales.

## 🏗️ Responsabilidades
- Implementar la lógica de negocio (servicios, casos de uso)
- Definir interfaces para acceso a datos (repositorios)
- Validar reglas de negocio
- Orquestar la interacción entre entidades del dominio
- No contiene detalles de infraestructura ni acceso directo a la base de datos

## 📂 Estructura principal
- **Services/**: Servicios de aplicación y casos de uso
- **Interfaces/**: Contratos para repositorios y servicios externos
- **DTOs/**: Objetos de transferencia de datos

## 🔗 Relación con otros módulos
- Es llamado por la API para ejecutar operaciones
- Llama a Infrastructure para acceder a datos o servicios externos

---

> Mantén la lógica de negocio aquí, separada de la infraestructura y la API. 