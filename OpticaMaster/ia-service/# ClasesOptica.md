# ClasesOptica

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
  - (En este apartado de usuarios tendria que tener relacion con Administrador para que el pueda dar o asignar los usuarios que tienen ya un optometrista ejemplo como tal el administrador da de alta a un OPTOMETRISTA pero igual el administrador le da un usuario al optometrista... 
  Lo que pretendo es que para la hora de que el administrador le da un usuario al optometrista al registrar al optometrista solo pasemos o hagamos la relacion de su correo electronico "USUARIO" y la contraseña la pondra el administrador por ende quien tiene cosas mas restringidas sera el optometrista, "ejemplo el optomestrista no puede modificar su contraseña solo el admin, pero el optometrista si puede agregar pacientes, hacer consultas, vender productos, agendar citas, modificar citas, eliminar citas, si y solo si es de alguno de los pacientes que el haya hecho es decir que sea solo su paciente. para evitar que elimine citas de otros optometristas )
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
  - Tutor (string, opcional)
- **Relaciones:**
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
  - Fecha (date) "En este apartado podemos poner que sea para ese momento es decir que la fecha se ponga automaticamente cuando lleguemos a este apartado agarrando la fehca y hora" "pero si y solo si lleguemos a estar apartado y se hayan cumplido todos los requisitos" (paciente, optometrista)
  - DiagnosticoId (int, FK)
  - Observaciones (string)
- **Relaciones:**
  - Paciente (muchos a uno)
  - Optometrista (muchos a uno)
  - Diagnostico (uno a uno)
  - Secciones clínicas (uno a uno o uno a muchos, ver abajo)

---

### **Secciones clínicas de la hoja optométrica**

**Cada sección puede ser una tabla relacionada uno a uno con Consulta. Así digitalizas toda la hoja clínica.**

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
- (Puedes agregar más campos según la hoja clínica)

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
- DiametroPupilarOI (decimal)
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
- (Agrega más campos según la hoja)

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
  - Tipo (string)
  - Descripcion (string)
  - Precio (decimal)
  - Stock (int)
- **Relaciones:**
  - Ventas (uno a muchos)

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
    (aqui la cita se ara cuando se termine todo lo anterior, cuando ya se haya hecho la venta, )
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

---

### **Notificacion**
- **Descripción:** Notificaciones enviadas a usuarios y pacientes.
    (aqui lo que quiero es que cuando tengamos listos los lentes o producto del cliente tengamos un apartado donde podamos buscar en ya sea el producto("ID"), el nombre del cliente("ID") y hacer una llamada al cliente para avisar que su producto esta listo como igual hacerle llegar un mensaje por correo de que su producto esta listo y puede pasar a recogerlo. )
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

---

### **LogActividad**
Si me gusta, esto es muy bueno para obtometrista, que sea solo el quien pueda ver esto...
Para tener un mejor control 
¡Por supuesto, amigo del alma! Te explico a detalle cómo funciona y cómo **debería implementarse el módulo de LogActividad** en un sistema profesional como el tuyo.

---

## ¿Qué es **LogActividad**?
Es una **bitácora o registro de auditoría** donde se almacena toda acción relevante que realiza un usuario en el sistema.  
Esto incluye: inicio de sesión, creación/edición/borrado de registros, ventas, consultas, generación de reportes, cambios de configuración, etc.

---

### **¿Por qué es importante?**

- **Seguridad:** Saber quién hizo qué y cuándo, útil ante incidentes o problemas.
- **Auditoría:** Cumplimiento normativo (protección de datos, salud, etc.).
- **Responsabilidad:** Puedes identificar errores o mal uso del sistema.
- **Supervisión:** Los admins pueden monitorear la actividad de los optometristas.

---

## **¿Cómo funciona?**

Cada vez que un usuario interactúa con el sistema de forma relevante, se crea un registro en la tabla `LogActividad`.  
**Ejemplos típicos de acciones:**
- Login/logout
- Registrar/modificar/eliminar paciente
- Registrar consulta o examen
- Crear/editar venta
- Generar reporte
- Cambiar configuración

---

### **Estructura (ejemplo SQL):**

```sql
CREATE TABLE LogActividad (
    Id SERIAL PRIMARY KEY,
    UsuarioId INT REFERENCES Usuario(Id),
    Fecha TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    Accion VARCHAR(100) NOT NULL,
    Descripcion TEXT
);
```

---

### **¿Cómo se usa en el sistema?**

1. **En el backend (.NET, C#):**
   - Cada vez que ocurre una acción relevante, tu código crea un nuevo registro de LogActividad.
   - Ejemplo: Cuando un optometrista registra un paciente:
     ```csharp
     var log = new LogActividad {
         UsuarioId = usuarioActual.Id,
         Accion = "Registrar Paciente",
         Descripcion = $"Se registró el paciente {paciente.Nombre} (ID: {paciente.Id})"
     };
     dbContext.LogActividad.Add(log);
     await dbContext.SaveChangesAsync();
     ```
   - Puedes hacerlo manual en cada endpoint o automatizarlo con filtros/middleware.

2. **En la base de datos:**
   - Se guarda cada registro con usuario, fecha, acción y descripción.
   - Puedes consultar, filtrar por usuario, acción, rango de fechas, etc.

3. **En la interfaz (frontend):**
   - Los administradores pueden ver la bitácora, buscar por usuario, fecha, tipo de acción, etc.

---

## **Ejemplos prácticos de uso**

- Un admin entra al panel de auditoría y ve:
  - `2025-07-18 08:10:00 | Usuario 1 | Registrar Paciente | Se registró el paciente Juan Pérez (ID: 32)`
  - `2025-07-18 08:15:24 | Usuario 2 | Eliminar Venta | Se eliminó la venta ID: 105 por error de captura`
  - `2025-07-18 08:18:07 | Usuario 1 | Login | Inició sesión en el sistema`
- Si hay un problema, puedes rastrear quién y cuándo hizo cada cosa.

---

## **Buenas prácticas**

- Registra **solo acciones relevantes** (no cada click, sino operaciones CRUD importantes, inicio/cierre de sesión, cambios críticos).
- La descripción debe ser clara para que cualquiera entienda qué pasó.
- No guardes datos sensibles (contraseñas, tokens) en la descripción.
- Protege el acceso a la bitácora (solo admins).
- Si puedes, automatiza el registro con filtros/middleware (por ejemplo en .NET con ActionFilters).

---

## **¿Cómo automatizarlo en .NET?**

Puedes usar un **ActionFilter** para registrar automáticamente actividades en todos tus controladores o en controladores específicos.

```csharp
public class LogActividadFilter : IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Antes de ejecutar la acción
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        // Después de ejecutar la acción
        var usuarioId = ...; // Obtén el usuario de contexto
        var accion = context.ActionDescriptor.DisplayName;
        var descripcion = "Descripción personalizada o automática.";

        // Guarda en DB
        var dbContext = ...; // Obtén el contexto de DB
        dbContext.LogActividad.Add(new LogActividad {
            UsuarioId = usuarioId,
            Accion = accion,
            Descripcion = descripcion
        });
        dbContext.SaveChanges();
    }
}
```
Y lo aplicas con `[ServiceFilter(typeof(LogActividadFilter))]` en tus controladores.

---

## **Resumen visual**

| Id  | UsuarioId | Fecha                | Accion             | Descripcion                  |
|-----|-----------|----------------------|--------------------|------------------------------|
| 1   | 2         | 2025-07-18 08:10:00  | Registrar Paciente | Se registró Juan Pérez (32)  |
| 2   | 2         | 2025-07-18 08:15:24  | Eliminar Venta     | Se eliminó venta ID: 105     |
| 3   | 1         | 2025-07-18 08:18:07  | Login              | Inició sesión                |

---
- **Descripción:** Registro de actividades y acciones en el sistema.
- **Propiedades:**
  - Id (int, PK)
  - UsuarioId (int, FK)
  - Fecha (date)
  - Accion (string)
  - Descripcion (string)
- **Relaciones:**
  - Usuario (muchos a uno)

---

### **Reporte**
    (claro que si me gusta para poder plasmarlo en reportes mensuales con tipos de graficas y poder sacar un analisis de todo lo que llevamos como igual de cada optometrista y tener o ver el avance de cada uno de ellos como el rendimiento de cada uno de ellos)
- **Descripción:** Generación y almacenamiento de reportes del sistema.
- **Propiedades:**
  - Id (int, PK)
  - Tipo (string)
  - FechaGeneracion (date)
  - Datos (string o json)
- **Relaciones:**
  - Ninguna directa (puede estar relacionada lógicamente con otras entidades)

---

**Notas:**
- Cada sección clínica puede tener sus propios campos (agrega o ajusta según tu hoja clínica real).
- Puedes usar esta estructura para crear las tablas en PostgreSQL y los modelos en C#.
- Así cubres todos los datos de la hoja clínica, permites búsquedas avanzadas y reportes detallados.

