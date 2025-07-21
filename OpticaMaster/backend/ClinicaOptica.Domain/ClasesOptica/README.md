# ClasesOptica

> **Nota importante:**
> Todas las entidades y flujos aquí documentados están pensados para uso exclusivo del personal de la óptica (optometristas y administradores). Los pacientes no interactúan directamente con el sistema, salvo para recibir información o recomendaciones a través del personal.

Esta carpeta contiene las **entidades principales** del dominio de la óptica.  
Cada clase aquí representa una tabla en la base de datos y define la estructura de los datos que maneja el sistema.

---

## Entidades principales del sistema

A continuación se listan las clases (entidades) que forman parte del modelo de datos y que serán implementadas en esta carpeta. Cada una representa una tabla en la base de datos y está alineada con los flujos funcionales del sistema:

- **Usuario**: Representa a los usuarios del sistema (administradores y optometristas).
- **Rol**: Define los roles disponibles (Admin, Optometrista).
- **Permiso**: Permisos asignados a los roles (si se requiere granularidad).
- **Optometrista**: Información específica de los optometristas.
- **Paciente**: Datos generales y clínicos de los pacientes.
- **Consulta**: Registro de consultas realizadas a los pacientes.
- **Examen**: Detalles de los exámenes visuales y de salud ocular.
- **Diagnostico**: Diagnóstico y recomendaciones para el paciente.
- **Producto**: Productos ópticos disponibles para la venta.
- **Venta**: Registro de ventas de productos a pacientes.
- **Cita**: Programación de citas de seguimiento y entrega.
- **Notificacion**: Notificaciones enviadas a usuarios y pacientes.
- **LogActividad**: Registro de actividades y acciones en el sistema.
- **Reporte**: Generación y almacenamiento de reportes del sistema.

> **Nota:** Esta lista puede ampliarse o ajustarse según evolucionen los requerimientos del sistema.

---

## Flujos funcionales del sistema de gestión de clínica optométrica

A continuación se describen los principales flujos funcionales del sistema y cómo las entidades de esta carpeta participan en ellos. Esto sirve como guía tanto para el modelado de las clases en C# como para la creación de las tablas en SQL:

### 1. Funciones del Administrador

- **Gestión de Optometristas:**  
  Permite agregar, eliminar, modificar y consultar optometristas.  
  Entidad relacionada: `Optometrista`.

- **Configuración del Sistema:**  
  Gestión de roles, permisos y notificaciones.  
  Entidades relacionadas: `Rol`, `Permiso`, `Notificacion`.

- **Supervisión del Sistema:**  
  Monitoreo de actividades y generación de reportes.  
  Entidades relacionadas: `LogActividad`, `Reporte`.

### 2. Funciones del Optometrista

- **Gestión de Pacientes:**  
  Registrar, consultar y ver historial de pacientes.  
  Entidad relacionada: `Paciente`.

- **Realización de Consultas:**  
  Registrar consultas, exámenes y diagnósticos.  
  Entidades relacionadas: `Consulta`, `Examen`, `Diagnostico`.

- **Venta de Productos:**  
  Registrar ventas y notificar productos listos.  
  Entidades relacionadas: `Venta`, `Producto`.

- **Programación de Citas:**  
  Agendar y gestionar citas de seguimiento y entrega.  
  Entidad relacionada: `Cita`.

### 3. Inicio de Sesión y Panel de Usuario

- **Inicio de Sesión:**  
  Verificación de credenciales y acceso según rol.  
  Entidades relacionadas: `Usuario`, `Rol`.

---

> **Nota:**  
> Cada entidad está documentada en este repositorio y su relación con los flujos funcionales está indicada en los comentarios de cada clase.  
> Esta estructura sirve de referencia tanto para la implementación en C# como para la creación de los scripts SQL de la base de datos.

---

## ¿Qué encontrarás aquí?

- **Entidades**: Clases que representan las tablas de la base de datos (por ejemplo: Paciente, Producto, Venta, Examen, etc.).
- **Relaciones**: Las propiedades de navegación y claves foráneas que definen cómo se relacionan las entidades entre sí.
- **Reglas de negocio básicas**: Validaciones simples o propiedades calculadas (si aplica).

---

## Estructura de las entidades

Cada clase sigue la siguiente estructura:

- **Propiedades**: Cada propiedad representa una columna en la tabla correspondiente.
- **Llaves primarias**: Usualmente la propiedad `Id`.
- **Llaves foráneas**: Propiedades que enlazan con otras entidades.
- **Propiedades de navegación**: Permiten acceder a los datos relacionados (listas o referencias a otras entidades).

---

## Ejemplo de entidad

```csharp
/// <summary>
/// Representa a un paciente de la óptica.
/// </summary>
public class Paciente
{
    /// <summary>
    /// Identificador único del paciente.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Nombre completo del paciente.
    /// </summary>
    public string Nombre { get; set; }

    // ...otros campos y documentación...
}
```

---

## Convenciones

- Todas las entidades están en el **namespace** `ClinicaOptica.Domain.ClasesOptica`.
- Los nombres de las clases son singulares y en PascalCase.
- Las relaciones entre entidades se documentan en los comentarios XML de cada clase.

---

## ¿Cómo modificar o agregar una entidad?

1. Crea un nuevo archivo `.cs` en esta carpeta.
2. Define la clase siguiendo la estructura y convenciones anteriores.
3. Documenta cada propiedad con comentarios XML.
4. Si la entidad tiene relaciones, explícalas en el comentario de la clase.

---

## Notas

- Si necesitas agregar objetos de valor, interfaces, enums, etc., crea nuevas carpetas a nivel de `Domain` para mantener la organización.
- Mantén este archivo actualizado si agregas nuevas entidades o cambias la estructura.

--- 

---

## Borrador de entidades: estructura y relaciones (Versión extendida para hoja clínica completa)

A continuación se presenta un modelo extendido de entidades principales y clínicas para cubrir todo el flujo de una óptica, incluyendo la digitalización de la hoja clínica completa.

---

### **Usuario**
- **Descripción:** Usuario del sistema (puede ser administrador u optometrista).
- **Propiedades:**
  - Id (int, PK)
  - Username (string)
  - PasswordHash (string)
  - RolId (int, FK)
- **Relaciones:**
  - Rol (muchos a uno)
  - Optometrista (uno a uno, si aplica)
  - **Notas de diseño:**
    - El administrador es responsable de dar de alta a los optometristas y asignarles un usuario (correo y contraseña). El optometrista no puede modificar su contraseña; solo el administrador puede hacerlo. El optometrista solo puede gestionar (modificar/eliminar) citas y pacientes que él mismo haya creado, para evitar que modifique información de otros optometristas.

---

### **Rol**
- **Descripción:** Define los roles disponibles en el sistema.
- **Propiedades:**
  - Id (int, PK)
  - Nombre (string)
- **Relaciones:**
  - Usuarios (uno a muchos)
  - Permisos (muchos a muchos, si se implementa granularidad)

---

### **Permiso**
- **Descripción:** Permisos asignados a los roles (opcional, para granularidad).
- **Propiedades:**
  - Id (int, PK)
  - Nombre (string)
- **Relaciones:**
  - Roles (muchos a muchos)

---

### **Optometrista**
- **Descripción:** Profesional encargado de realizar consultas y exámenes.
- **Propiedades:**
  - Id (int, PK)
  - Nombre (string)
  - CedulaProfesional (string)
  - Especialidad (string)
  - Correo (string)
  - Telefono (string)
  - UsuarioId (int, FK)
- **Relaciones:**
  - Usuario (uno a uno)
  - Consultas (uno a muchos)

---

### **Tutor**
- **Descripción:** Representa al tutor legal de un paciente menor de edad.
- **Propiedades:**
  - Id (int, PK)
  - Nombre (string)
  - Genero (string)
  - Edad (int)
  - Ocupacion (string)
  - Domicilio (string)
  - Email (string)
  - Telefono (string)
  - RelacionConPaciente (string) // Padre, Madre, Abuelo, Tío, etc.
  - EsResponsableLegal (bool)
- **Relaciones:**
  - Pacientes (uno a muchos)

---

### **Paciente**
- **Descripción:** Representa a un paciente de la óptica.
- **Propiedades:**
  - Id (int, PK)
  - Nombre (string)
  - Genero (string)
  - Edad (int)
  - EstadoCivil (string)
  - Escolaridad (string)
  - Ocupacion (string)
  - Domicilio (string)
  - Email (string)
  - Telefono (string)
  - TutorId (int, FK, opcional)
- **Relaciones:**
  - Tutor (muchos a uno, opcional)
  - Consultas (uno a muchos)
  - Ventas (uno a muchos)
  - Citas (uno a muchos)

---

### **Consulta**
- **Descripción:** Registro de una consulta realizada a un paciente.
- **Propiedades:**
  - Id (int, PK)
  - PacienteId (int, FK)
  - OptometristaId (int, FK)
  - Fecha (date) *(La fecha se asigna automáticamente cuando se cumplen todos los requisitos: paciente y optometrista seleccionados)*
  - DiagnosticoId (int, FK)
  - Observaciones (string)
- **Relaciones:**
  - Paciente (muchos a uno)
  - Optometrista (muchos a uno)
  - Diagnostico (uno a uno)
  - Secciones clínicas (uno a uno o uno a muchos, ver abajo)

---

### **Secciones clínicas de la hoja optométrica**

Cada sección representa una parte de la hoja clínica y puede ser una tabla relacionada uno a uno con Consulta. Esto permite digitalizar toda la hoja clínica y facilita búsquedas y reportes detallados.

#### **Antecedentes**
- ConsultaId (int, FK)
- HeredoFamiliares (string)
- NoPatologicos (string)
- Patologicos (string)
- PadecimientoActual (string)
- Prediagnostico (string)

#### **AgudezaVisual**
- ConsultaId (int, FK)
- SinRxLejosOD (string)
- SinRxLejosOI (string)
- SinRxCercaOD (string)
- SinRxCercaOI (string)
- ConRxLejosOD (string)
- ConRxLejosOI (string)
- ConRxCercaOD (string)
- ConRxCercaOI (string)
- *(Agrega más campos según la hoja clínica real)*

#### **Lensometria**
- ConsultaId (int, FK)
- EsferaOD (decimal)
- CilindroOD (decimal)
- EjeOD (int)
- EsferaOI (decimal)
- CilindroOI (decimal)
- EjeOI (int)
- TipoBifocal (string)
- Material (string)

#### **AlineacionOcular**
- ConsultaId (int, FK)
- Lejos (string)
- Cerca (string)
- TestPantalleo (bool)
- TestMaddox (bool)
- TestThorington (bool)
- TestVonGraefe (bool)

#### **MotilidadOcular**
- ConsultaId (int, FK)
- Versiones (string)
- Ducciones (string)
- Sacadicos (string)
- Persecucion (string)

#### **ExploracionFisica**
- ConsultaId (int, FK)
- Anexos (string)
- SegmentoAnterior (string)
- DiametroPupilarOD (decimal)
- DiametroPupularOI (decimal)
- FotomotorOD (bool)
- FotomotorOI (bool)
- PupilaIsocorica (bool)

#### **Refraccion**
- ConsultaId (int, FK)
- EsferaOD (decimal)
- CilindroOD (decimal)
- EjeOD (int)
- EsferaOI (decimal)
- CilindroOI (decimal)
- EjeOI (int)
- Queratometria (string)
- EstadoRefractivo (string)

#### **Binocularidad**
- ConsultaId (int, FK)
- ForiasLejos (string)
- ForiasCerca (string)
- Vergencias (string)
- IntegracionBinocular (string)
- VisionEstereoscopica (string)

#### **Campimetria**
- ConsultaId (int, FK)
- Distancia (string)
- Indice (string)
- PuntoFijacion (string)
- ResultadoOD (string)
- ResultadoOI (string)

#### **Biomicroscopia**
- ConsultaId (int, FK)
- Parpados (string)
- LineaGris (string)
- CantoExterno (string)
- FondoDeSaco (string)
- Cornea (string)
- *(Agrega más campos según la hoja clínica)*

#### **Oftalmoscopia**
- ConsultaId (int, FK)
- Papila (string)
- Excavacion (string)
- Radio (string)
- Vasos (string)
- Macula (string)
- Retina (string)

#### **RecetaFinal**
- ConsultaId (int, FK)
- EsferaOD (decimal)
- CilindroOD (decimal)
- EjeOD (int)
- EsferaOI (decimal)
- CilindroOI (decimal)
- EjeOI (int)
- Prismas (string)
- DI (string)
- ADD (string)
- Material (string)
- Tratamiento (string)

---

### **Diagnostico**
- **Descripción:** Diagnóstico y recomendaciones para el paciente tras una consulta.
- **Propiedades:**
  - Id (int, PK)
  - ConsultaId (int, FK)
  - Descripcion (string)
  - PlanTratamiento (string)
  - Pronostico (string)
- **Relaciones:**
  - Consulta (uno a uno)

---

### **Producto**
- **Descripción:** Productos ópticos disponibles para la venta.
- **Propiedades:**
  - Id (int, PK)
  - Nombre (string)
  - Tipo (string) // armazon, lente, líquido, accesorio, etc.
  - Descripcion (string)
  - Precio (decimal)
  - Stock (int)
  - Activo (bool)
- **Relaciones:**
  - Ventas (uno a muchos)
  - ArmazonAtributos (uno a uno, solo si Tipo = 'armazon')

---

### **ArmazonAtributos**
- **Descripción:** Atributos específicos de los productos tipo armazón, para recomendaciones personalizadas y gestión avanzada.
- **Propiedades:**
  - ProductoId (int, PK, FK a Producto)
  - Forma (string) // redondo, cuadrado, aviador, etc.
  - Color (string)
  - Material (string)
  - TamañoAncho (int)
  - TamañoAlto (int)
  - TamañoPuente (int)
  - Genero (string) // hombre, mujer, unisex, infantil
  - Marca (string)
  - Modelo (string)
  - FotoUrl (string)
- **Relaciones:**
  - Producto (uno a uno)

> Para detalles avanzados, ejemplos de consultas y scripts SQL, consulta el archivo [MODELO_DATOS_PRODUCTOS.md](MODELO_DATOS_PRODUCTOS.md)

---

### **Venta**
- **Descripción:** Registro de ventas de productos a pacientes.
- **Propiedades:**
  - Id (int, PK)
  - PacienteId (int, FK)
  - ProductoId (int, FK)
  - Fecha (date)
  - Cantidad (int)
  - Total (decimal)
- **Relaciones:**
  - Paciente (muchos a uno)
  - Producto (muchos a uno)

---

### **Cita**
- **Descripción:** Programación de citas de seguimiento y entrega.
- **Propiedades:**
  - Id (int, PK)
  - PacienteId (int, FK)
  - OptometristaId (int, FK)
  - Fecha (date)
  - Hora (time)
  - Tipo (string)
  - Estado (string)
- **Relaciones:**
  - Paciente (muchos a uno)
  - Optometrista (muchos a uno)
- **Notas de diseño:**
  - Las citas solo se pueden agendar cuando se ha completado el proceso anterior (por ejemplo, venta y consulta). Esto asegura que el flujo de trabajo sea lógico y evita errores administrativos.

---

### **Notificacion**
- **Descripción:** Notificaciones enviadas a usuarios y pacientes.
- **Propiedades:**
  - Id (int, PK)
  - UsuarioId (int, FK, opcional)
  - PacienteId (int, FK, opcional)
  - Mensaje (string)
  - FechaEnvio (date)
  - Tipo (string)
- **Relaciones:**
  - Usuario (muchos a uno, opcional)
  - Paciente (muchos a uno, opcional)
- **Notas de diseño:**
  - Cuando un producto está listo, el sistema permite buscar por producto o cliente y notificar al paciente por llamada o correo electrónico que su producto está listo para recoger.

---

### **LogActividad**
- **Descripción:** Registro de actividades y acciones en el sistema.
- **Propiedades:**
  - Id (int, PK)
  - UsuarioId (int, FK)
  - Fecha (date)
  - Accion (string)
  - Descripcion (string)
- **Relaciones:**
  - Usuario (muchos a uno)
- **Notas de diseño:**
  - Solo el optometrista puede ver su propio log, mientras que el administrador puede ver todos los registros. Esto permite un mejor control y auditoría del sistema.


#### **¿Qué es LogActividad?**
Es una bitácora o registro de auditoría donde se almacena toda acción relevante que realiza un usuario en el sistema (inicio de sesión, creación/edición/borrado de registros, ventas, consultas, reportes, cambios de configuración, etc.).

#### **¿Por qué es importante?**
- Seguridad: Saber quién hizo qué y cuándo.
- Auditoría: Cumplimiento normativo.
- Responsabilidad: Identificar errores o mal uso.
- Supervisión: Monitoreo de actividad de los optometristas.

#### **¿Cómo funciona?**
- Cada vez que un usuario realiza una acción relevante, se crea un registro en la tabla LogActividad.
- Ejemplo de estructura SQL:

```sql
CREATE TABLE LogActividad (
    Id SERIAL PRIMARY KEY,
    UsuarioId INT REFERENCES Usuario(Id),
    Fecha TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Accion VARCHAR(100) NOT NULL,
    Descripcion TEXT
);
```

#### **Buenas prácticas**
- Registrar solo acciones relevantes.
- Descripciones claras y útiles.
- No guardar datos sensibles.
- Proteger el acceso a la bitácora.
- Automatizar el registro con filtros/middleware si es posible.

---
## **Resumen visual**

| Id  | UsuarioId | Fecha                | Accion             | Descripcion                  |
|-----|-----------|----------------------|--------------------|------------------------------|
| 1   | 2         | 2025-07-18 08:10:00  | Registrar Paciente | Se registró Juan Pérez (32)  |
| 2   | 2         | 2025-07-18 08:15:24  | Eliminar Venta     | Se eliminó venta ID: 105     |
| 3   | 1         | 2025-07-18 08:18:07  | Login              | Inició sesión                |

---

### **Reporte**
- **Descripción:** Generación y almacenamiento de reportes del sistema.
- **Propiedades:**
  - Id (int, PK)
  - Tipo (string)
  - FechaGeneracion (date)
  - Datos (string o json)
- **Relaciones:**
  - Ninguna directa (puede estar relacionada lógicamente con otras entidades)
- **Notas de diseño:**
  - Los reportes pueden usarse para análisis mensual, rendimiento de optometristas, gráficas, etc. Esto permite visualizar el avance y desempeño de cada profesional y del sistema en general.

---

**Notas generales:**
- Cada sección clínica puede tener sus propios campos (agrega o ajusta según tu hoja clínica real).
- Puedes usar esta estructura para crear las tablas en PostgreSQL y los modelos en C#.
- Así cubres todos los datos de la hoja clínica, permites búsquedas avanzadas y reportes detallados.

