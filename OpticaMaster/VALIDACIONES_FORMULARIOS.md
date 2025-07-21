# 🔍 Guía de Validaciones de Formularios - Sistema de Gestión de Óptica

## 📖 Índice
1. [Introducción](#introducción)
2. [Validaciones por Entidad](#validaciones-por-entidad)
3. [Reglas de Validación Comunes](#reglas-de-validación-comunes)
4. [Implementación en Frontend](#implementación-en-frontend)
5. [Implementación en Backend](#implementación-en-backend)
6. [Mensajes de Error](#mensajes-de-error)
7. [Ejemplos Prácticos](#ejemplos-prácticos)

---

## 🎯 Introducción

La validación de formularios es crucial para garantizar la integridad de los datos y proporcionar una experiencia de usuario fluida. Este documento define todas las reglas de validación necesarias para el sistema de gestión de óptica.

### Principios de Validación
- **Validación en tiempo real**: Mostrar errores mientras el usuario escribe
- **Validación en el servidor**: Doble verificación de seguridad
- **Mensajes claros**: Errores comprensibles y específicos
- **Experiencia fluida**: No interrumpir el flujo del usuario

---

## 👥 Validaciones por Entidad

### 1. Usuario

#### Campos y Validaciones:
```javascript
{
  username: {
    required: true,
    minLength: 3,
    maxLength: 50,
    pattern: /^[a-zA-Z0-9_]+$/,
    unique: true
  },
  email: {
    required: true,
    pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
    unique: true
  },
  password: {
    required: true,
    minLength: 8,
    pattern: /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]/,
    confirmPassword: true
  }
}
```

#### Mensajes de Error:
- **Username**: "El nombre de usuario debe tener entre 3 y 50 caracteres, solo letras, números y guiones bajos"
- **Email**: "Ingrese un correo electrónico válido"
- **Password**: "La contraseña debe tener al menos 8 caracteres, incluyendo mayúsculas, minúsculas, números y símbolos"

### 2. Paciente

#### Campos y Validaciones:
```javascript
{
  nombre: {
    required: true,
    minLength: 2,
    maxLength: 100,
    pattern: /^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/
  },
  genero: {
    required: true,
    enum: ['Masculino', 'Femenino', 'Otro']
  },
  edad: {
    required: true,
    min: 0,
    max: 120,
    type: 'number'
  },
  estadoCivil: {
    required: true,
    enum: ['Soltero', 'Casado', 'Divorciado', 'Viudo', 'Unión Libre']
  },
  escolaridad: {
    required: true,
    enum: ['Primaria', 'Secundaria', 'Preparatoria', 'Universidad', 'Posgrado']
  },
  ocupacion: {
    required: true,
    maxLength: 100
  },
  domicilio: {
    required: true,
    maxLength: 200
  },
  email: {
    required: false,
    pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
    allowEmpty: true
  },
  telefono: {
    required: true,
    pattern: /^[\d\s\-\+\(\)]{10,15}$/,
    minLength: 10,
    maxLength: 15
  },
  tutorId: {
    required: false,
    conditional: 'edad < 18',
    exists: 'tutores'
  }
}
```

#### Mensajes de Error:
- **Nombre**: "El nombre debe contener solo letras y espacios"
- **Edad**: "La edad debe estar entre 0 y 120 años"
- **Teléfono**: "Ingrese un número de teléfono válido (10-15 dígitos)"
- **TutorId**: "El tutor es obligatorio para menores de 18 años"

### 3. Tutor

#### Campos y Validaciones:
```javascript
{
  nombre: {
    required: true,
    minLength: 2,
    maxLength: 100,
    pattern: /^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/
  },
  genero: {
    required: true,
    enum: ['Masculino', 'Femenino', 'Otro']
  },
  edad: {
    required: true,
    min: 18,
    max: 120,
    type: 'number'
  },
  ocupacion: {
    required: true,
    maxLength: 100
  },
  domicilio: {
    required: true,
    maxLength: 200
  },
  email: {
    required: false,
    pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
    allowEmpty: true
  },
  telefono: {
    required: true,
    pattern: /^[\d\s\-\+\(\)]{10,15}$/,
    minLength: 10,
    maxLength: 15
  },
  relacionConPaciente: {
    required: true,
    enum: ['Padre', 'Madre', 'Abuelo', 'Abuela', 'Tío', 'Tía', 'Hermano', 'Hermana', 'Otro']
  },
  esResponsableLegal: {
    required: true,
    type: 'boolean'
  }
}
```

#### Mensajes de Error:
- **Nombre**: "El nombre debe contener solo letras y espacios"
- **Edad**: "La edad debe ser mayor a 18 años"
- **Teléfono**: "Ingrese un número de teléfono válido"
- **Relación**: "Seleccione la relación con el paciente"
- **Responsable Legal**: "Debe confirmar si es el responsable legal"

### 4. Optometrista

#### Campos y Validaciones:
```javascript
{
  nombre: {
    required: true,
    minLength: 2,
    maxLength: 100,
    pattern: /^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/
  },
  cedulaProfesional: {
    required: true,
    pattern: /^\d{6,10}$/,
    unique: true
  },
  especialidad: {
    required: true,
    maxLength: 100
  },
  correo: {
    required: true,
    pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/
  },
  telefono: {
    required: true,
    pattern: /^[\d\s\-\+\(\)]{10,15}$/
  }
}
```

### 5. Producto

#### Campos y Validaciones:
```javascript
{
  nombre: {
    required: true,
    minLength: 2,
    maxLength: 100
  },
  tipo: {
    required: true,
    enum: ['Armazón', 'Lentes', 'Accesorio', 'Otro']
  },
  descripcion: {
    required: false,
    maxLength: 500
  },
  precio: {
    required: true,
    min: 0,
    max: 999999.99,
    type: 'decimal',
    precision: 2
  },
  stock: {
    required: true,
    min: 0,
    max: 9999,
    type: 'integer'
  }
}
```

### 6. Consulta

#### Campos y Validaciones:
```javascript
{
  pacienteId: {
    required: true,
    exists: 'pacientes'
  },
  optometristaId: {
    required: true,
    exists: 'optometristas'
  },
  fecha: {
    required: true,
    type: 'date',
    max: 'today',
    min: '2020-01-01'
  },
  observaciones: {
    required: false,
    maxLength: 1000
  }
}
```

### 7. Cita

#### Campos y Validaciones:
```javascript
{
  pacienteId: {
    required: true,
    exists: 'pacientes'
  },
  optometristaId: {
    required: true,
    exists: 'optometristas'
  },
  fecha: {
    required: true,
    type: 'date',
    min: 'today'
  },
  hora: {
    required: true,
    type: 'time',
    businessHours: '08:00-18:00'
  },
  tipo: {
    required: true,
    enum: ['Primera Consulta', 'Seguimiento', 'Entrega', 'Otro']
  },
  duracion: {
    required: true,
    min: 15,
    max: 120,
    type: 'integer'
  }
}
```

---

## 🔧 Reglas de Validación Comunes

### Validaciones de Texto
```javascript
const textValidations = {
  // Solo letras y espacios
  onlyLetters: /^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/,
  
  // Solo números
  onlyNumbers: /^\d+$/,
  
  // Letras y números
  alphanumeric: /^[a-zA-Z0-9\s]+$/,
  
  // Sin caracteres especiales peligrosos
  safeText: /^[^<>{}()\[\]]+$/,
  
  // Nombre completo (nombre y apellidos)
  fullName: /^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]{2,100}$/
}
```

### Validaciones de Contacto
```javascript
const contactValidations = {
  // Email básico
  email: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
  
  // Teléfono mexicano
  phoneMX: /^[\d\s\-\+\(\)]{10,15}$/,
  
  // Código postal mexicano
  zipCodeMX: /^\d{5}$/,
  
  // RFC mexicano
  rfc: /^[A-Z&Ñ]{3,4}[0-9]{6}[A-Z0-9]{3}$/
}
```

### Validaciones de Fechas
```javascript
const dateValidations = {
  // Fecha futura
  futureDate: (date) => new Date(date) > new Date(),
  
  // Fecha pasada
  pastDate: (date) => new Date(date) < new Date(),
  
  // Edad mínima
  minAge: (birthDate, minAge) => {
    const age = new Date().getFullYear() - new Date(birthDate).getFullYear();
    return age >= minAge;
  },
  
  // Horario laboral
  businessHours: (time) => {
    const hour = parseInt(time.split(':')[0]);
    return hour >= 8 && hour <= 18;
  }
}
```

---

## 🎨 Implementación en Frontend

### React Hook para Validaciones
```javascript
import { useState, useEffect } from 'react';

const useFormValidation = (initialValues, validationRules) => {
  const [values, setValues] = useState(initialValues);
  const [errors, setErrors] = useState({});
  const [touched, setTouched] = useState({});

  const validateField = (name, value) => {
    const rules = validationRules[name];
    if (!rules) return '';

    // Validación requerida
    if (rules.required && (!value || value.trim() === '')) {
      return `${name} es obligatorio`;
    }

    // Validación de longitud mínima
    if (rules.minLength && value.length < rules.minLength) {
      return `${name} debe tener al menos ${rules.minLength} caracteres`;
    }

    // Validación de longitud máxima
    if (rules.maxLength && value.length > rules.maxLength) {
      return `${name} debe tener máximo ${rules.maxLength} caracteres`;
    }

    // Validación de patrón
    if (rules.pattern && !rules.pattern.test(value)) {
      return rules.errorMessage || `${name} no tiene el formato correcto`;
    }

    // Validación de tipo numérico
    if (rules.type === 'number' && isNaN(value)) {
      return `${name} debe ser un número`;
    }

    // Validación de rango
    if (rules.min !== undefined && parseFloat(value) < rules.min) {
      return `${name} debe ser mayor o igual a ${rules.min}`;
    }

    if (rules.max !== undefined && parseFloat(value) > rules.max) {
      return `${name} debe ser menor o igual a ${rules.max}`;
    }

    return '';
  };

  const handleChange = (name, value) => {
    setValues(prev => ({ ...prev, [name]: value }));
    
    if (touched[name]) {
      const error = validateField(name, value);
      setErrors(prev => ({ ...prev, [name]: error }));
    }
  };

  const handleBlur = (name) => {
    setTouched(prev => ({ ...prev, [name]: true }));
    const error = validateField(name, values[name]);
    setErrors(prev => ({ ...prev, [name]: error }));
  };

  const validateForm = () => {
    const newErrors = {};
    Object.keys(validationRules).forEach(name => {
      const error = validateField(name, values[name]);
      if (error) newErrors[name] = error;
    });
    setErrors(newErrors);
    return Object.keys(newErrors).length === 0;
  };

  return {
    values,
    errors,
    touched,
    handleChange,
    handleBlur,
    validateForm,
    setValues
  };
};
```

### Componente de Campo con Validación
```javascript
const FormField = ({ 
  name, 
  label, 
  type = 'text', 
  validation, 
  value, 
  onChange, 
  onBlur, 
  error, 
  touched 
}) => {
  return (
    <div className="form-field">
      <label htmlFor={name} className="form-label">
        {label}
        {validation?.required && <span className="required">*</span>}
      </label>
      
      <input
        id={name}
        name={name}
        type={type}
        value={value}
        onChange={(e) => onChange(name, e.target.value)}
        onBlur={() => onBlur(name)}
        className={`form-input ${error && touched ? 'error' : ''}`}
      />
      
      {error && touched && (
        <div className="error-message">
          {error}
        </div>
      )}
    </div>
  );
};
```

### Ejemplo de Uso en Formulario de Paciente con Tutor
```javascript
const PacienteForm = () => {
  const [showTutorForm, setShowTutorForm] = useState(false);
  const [tutores, setTutores] = useState([]);
  
  const validationRules = {
    nombre: {
      required: true,
      minLength: 2,
      maxLength: 100,
      pattern: /^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/,
      errorMessage: 'El nombre debe contener solo letras y espacios'
    },
    email: {
      required: false,
      pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
      errorMessage: 'Ingrese un correo electrónico válido'
    },
    telefono: {
      required: true,
      pattern: /^[\d\s\-\+\(\)]{10,15}$/,
      errorMessage: 'Ingrese un número de teléfono válido'
    },
    edad: {
      required: true,
      type: 'number',
      min: 0,
      max: 120
    },
    tutorId: {
      required: false,
      conditional: 'edad < 18'
    }
  };

  const {
    values,
    errors,
    touched,
    handleChange,
    handleBlur,
    validateForm
  } = useFormValidation({
    nombre: '',
    email: '',
    telefono: '',
    edad: ''
  }, validationRules);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (validateForm()) {
      // Enviar datos al servidor
      console.log('Datos válidos:', values);
    }
  };

  // Efecto para mostrar/ocultar formulario de tutor
  useEffect(() => {
    if (values.edad < 18) {
      setShowTutorForm(true);
    } else {
      setShowTutorForm(false);
      setValues(prev => ({ ...prev, tutorId: null }));
    }
  }, [values.edad]);

  return (
    <form onSubmit={handleSubmit} className="patient-form">
      <FormField
        name="nombre"
        label="Nombre Completo"
        validation={validationRules.nombre}
        value={values.nombre}
        onChange={handleChange}
        onBlur={handleBlur}
        error={errors.nombre}
        touched={touched.nombre}
      />
      
      <FormField
        name="email"
        label="Correo Electrónico"
        type="email"
        validation={validationRules.email}
        value={values.email}
        onChange={handleChange}
        onBlur={handleBlur}
        error={errors.email}
        touched={touched.email}
      />
      
      <FormField
        name="telefono"
        label="Teléfono"
        type="tel"
        validation={validationRules.telefono}
        value={values.telefono}
        onChange={handleChange}
        onBlur={handleBlur}
        error={errors.telefono}
        touched={touched.telefono}
      />
      
      <FormField
        name="edad"
        label="Edad"
        type="number"
        validation={validationRules.edad}
        value={values.edad}
        onChange={handleChange}
        onBlur={handleBlur}
        error={errors.edad}
        touched={touched.edad}
      />
      
      {/* Sección de Tutor */}
      {showTutorForm && (
        <div className="tutor-section">
          <h3>Información del Tutor</h3>
          
          <div className="tutor-options">
            <label>
              <input
                type="radio"
                name="tutorOption"
                value="existing"
                onChange={() => setShowTutorForm('existing')}
              />
              Seleccionar tutor existente
            </label>
            
            <label>
              <input
                type="radio"
                name="tutorOption"
                value="new"
                onChange={() => setShowTutorForm('new')}
              />
              Registrar nuevo tutor
            </label>
          </div>
          
          {showTutorForm === 'existing' && (
            <FormField
              name="tutorId"
              label="Seleccionar Tutor"
              type="select"
              options={tutores}
              validation={validationRules.tutorId}
              value={values.tutorId}
              onChange={handleChange}
              onBlur={handleBlur}
              error={errors.tutorId}
              touched={touched.tutorId}
            />
          )}
          
          {showTutorForm === 'new' && (
            <TutorForm onTutorCreated={(tutor) => {
              setTutores(prev => [...prev, tutor]);
              setValues(prev => ({ ...prev, tutorId: tutor.id }));
            }} />
          )}
        </div>
      )}
      
      <button type="submit" className="submit-btn">
        Guardar Paciente
      </button>
    </form>
  );
};
```

---

## 🔒 Implementación en Backend

### Modelo con Validaciones (C#)
```csharp
using System.ComponentModel.DataAnnotations;

public class Tutor
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre debe contener solo letras y espacios")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El género es obligatorio")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "La edad es obligatoria")]
    [Range(18, 120, ErrorMessage = "La edad debe ser mayor a 18 años")]
    public int Edad { get; set; }

    [Required(ErrorMessage = "La ocupación es obligatoria")]
    [StringLength(100, ErrorMessage = "La ocupación no puede exceder 100 caracteres")]
    public string Ocupacion { get; set; }

    [Required(ErrorMessage = "El domicilio es obligatorio")]
    [StringLength(200, ErrorMessage = "El domicilio no puede exceder 200 caracteres")]
    public string Domicilio { get; set; }

    [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [RegularExpression(@"^[\d\s\-\+\(\)]{10,15}$", ErrorMessage = "Ingrese un número de teléfono válido")]
    public string Telefono { get; set; }

    [Required(ErrorMessage = "La relación con el paciente es obligatoria")]
    public string RelacionConPaciente { get; set; }

    [Required(ErrorMessage = "Debe confirmar si es el responsable legal")]
    public bool EsResponsableLegal { get; set; }

    // Propiedad de navegación
    public virtual ICollection<Paciente> Pacientes { get; set; }
}

public class Paciente
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres")]
    [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$", ErrorMessage = "El nombre debe contener solo letras y espacios")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El género es obligatorio")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "La edad es obligatoria")]
    [Range(0, 120, ErrorMessage = "La edad debe estar entre 0 y 120 años")]
    public int Edad { get; set; }

    [Required(ErrorMessage = "El estado civil es obligatorio")]
    public string EstadoCivil { get; set; }

    [Required(ErrorMessage = "La escolaridad es obligatoria")]
    public string Escolaridad { get; set; }

    [Required(ErrorMessage = "La ocupación es obligatoria")]
    [StringLength(100, ErrorMessage = "La ocupación no puede exceder 100 caracteres")]
    public string Ocupacion { get; set; }

    [Required(ErrorMessage = "El domicilio es obligatorio")]
    [StringLength(200, ErrorMessage = "El domicilio no puede exceder 200 caracteres")]
    public string Domicilio { get; set; }

    [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "El teléfono es obligatorio")]
    [RegularExpression(@"^[\d\s\-\+\(\)]{10,15}$", ErrorMessage = "Ingrese un número de teléfono válido")]
    public string Telefono { get; set; }

    // Clave foránea al tutor (opcional)
    public int? TutorId { get; set; }

    // Propiedades de navegación
    public virtual Tutor Tutor { get; set; }
    public virtual ICollection<Consulta> Consultas { get; set; }
    public virtual ICollection<Venta> Ventas { get; set; }
    public virtual ICollection<Cita> Citas { get; set; }
}
```

### Servicio de Validación
```csharp
public class ValidationService
{
    public ValidationResult ValidatePaciente(Paciente paciente)
    {
        var result = new ValidationResult();

        // Validación personalizada para tutor
        if (paciente.Edad < 18 && string.IsNullOrEmpty(paciente.Tutor))
        {
            result.AddError("Tutor", "El tutor es obligatorio para menores de 18 años");
        }

        // Validación de formato de teléfono
        if (!IsValidPhoneNumber(paciente.Telefono))
        {
            result.AddError("Telefono", "El formato del teléfono no es válido");
        }

        // Validación de email único
        if (!string.IsNullOrEmpty(paciente.Email) && !IsEmailUnique(paciente.Email, paciente.Id))
        {
            result.AddError("Email", "Este correo electrónico ya está registrado");
        }

        return result;
    }

    private bool IsValidPhoneNumber(string phone)
    {
        // Lógica de validación de teléfono
        return Regex.IsMatch(phone, @"^[\d\s\-\+\(\)]{10,15}$");
    }

    private bool IsEmailUnique(string email, int pacienteId)
    {
        // Lógica para verificar email único
        // Implementar consulta a base de datos
        return true;
    }
}

public class ValidationResult
{
    public List<ValidationError> Errors { get; set; } = new List<ValidationError>();
    public bool IsValid => !Errors.Any();

    public void AddError(string field, string message)
    {
        Errors.Add(new ValidationError { Field = field, Message = message });
    }
}

public class ValidationError
{
    public string Field { get; set; }
    public string Message { get; set; }
}
```

### Controlador con Validación
```csharp
[ApiController]
[Route("api/[controller]")]
public class PacientesController : ControllerBase
{
    private readonly IPacienteService _pacienteService;
    private readonly ValidationService _validationService;

    public PacientesController(IPacienteService pacienteService, ValidationService validationService)
    {
        _pacienteService = pacienteService;
        _validationService = validationService;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePaciente([FromBody] Paciente paciente)
    {
        // Validación del modelo
        if (!ModelState.IsValid)
        {
            return BadRequest(new
            {
                Message = "Datos inválidos",
                Errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new
                    {
                        Field = x.Key,
                        Errors = x.Value.Errors.Select(e => e.ErrorMessage)
                    })
            });
        }

        // Validación personalizada
        var validationResult = _validationService.ValidatePaciente(paciente);
        if (!validationResult.IsValid)
        {
            return BadRequest(new
            {
                Message = "Validación fallida",
                Errors = validationResult.Errors
            });
        }

        // Crear paciente
        var createdPaciente = await _pacienteService.CreateAsync(paciente);
        return CreatedAtAction(nameof(GetPaciente), new { id = createdPaciente.Id }, createdPaciente);
    }
}
```

---

## ⚠️ Mensajes de Error

### Estructura de Mensajes
```javascript
const errorMessages = {
  // Mensajes generales
  required: "Este campo es obligatorio",
  invalid: "El formato no es válido",
  tooShort: "Demasiado corto",
  tooLong: "Demasiado largo",
  
  // Mensajes específicos por campo
  nombre: {
    required: "El nombre es obligatorio",
    invalid: "El nombre debe contener solo letras y espacios",
    tooShort: "El nombre debe tener al menos 2 caracteres",
    tooLong: "El nombre no puede exceder 100 caracteres"
  },
  
  email: {
    required: "El correo electrónico es obligatorio",
    invalid: "Ingrese un correo electrónico válido",
    duplicate: "Este correo electrónico ya está registrado"
  },
  
  telefono: {
    required: "El teléfono es obligatorio",
    invalid: "Ingrese un número de teléfono válido (10-15 dígitos)",
    format: "Formato: (123) 456-7890 o 123-456-7890"
  },
  
  edad: {
    required: "La edad es obligatoria",
    invalid: "La edad debe ser un número",
    range: "La edad debe estar entre 0 y 120 años"
  }
};
```

### Componente de Mensaje de Error
```javascript
const ErrorMessage = ({ error, field }) => {
  if (!error) return null;

  return (
    <div className="error-message" role="alert">
      <i className="error-icon">⚠️</i>
      <span className="error-text">{error}</span>
    </div>
  );
};
```

---

## 🎯 Ejemplos Prácticos

### Validación de Formulario Completo
```javascript
// Reglas de validación para formulario de paciente
const pacienteValidationRules = {
  nombre: {
    required: true,
    minLength: 2,
    maxLength: 100,
    pattern: /^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$/,
    errorMessage: 'El nombre debe contener solo letras y espacios'
  },
  genero: {
    required: true,
    enum: ['Masculino', 'Femenino', 'Otro']
  },
  edad: {
    required: true,
    type: 'number',
    min: 0,
    max: 120
  },
  email: {
    required: false,
    pattern: /^[^\s@]+@[^\s@]+\.[^\s@]+$/,
    errorMessage: 'Ingrese un correo electrónico válido'
  },
  telefono: {
    required: true,
    pattern: /^[\d\s\-\+\(\)]{10,15}$/,
    errorMessage: 'Ingrese un número de teléfono válido'
  }
};

// Validación condicional
const conditionalValidation = (values) => {
  const errors = {};
  
  // Si es menor de 18 años, el tutor es obligatorio
  if (values.edad < 18 && !values.tutorId) {
    errors.tutorId = 'El tutor es obligatorio para menores de 18 años';
  }
  
  // Si el email está presente, debe ser único
  if (values.email && !isEmailUnique(values.email)) {
    errors.email = 'Este correo electrónico ya está registrado';
  }
  
  return errors;
};
```

### Validación de Citas
```javascript
const citaValidationRules = {
  fecha: {
    required: true,
    type: 'date',
    min: 'today',
    errorMessage: 'La fecha debe ser hoy o en el futuro'
  },
  hora: {
    required: true,
    type: 'time',
    businessHours: '08:00-18:00',
    errorMessage: 'La hora debe estar entre 8:00 AM y 6:00 PM'
  },
  duracion: {
    required: true,
    type: 'number',
    min: 15,
    max: 120,
    errorMessage: 'La duración debe estar entre 15 y 120 minutos'
  }
};

// Validación de disponibilidad
const validateAvailability = async (fecha, hora, duracion, optometristaId) => {
  // Verificar que no haya conflictos de horario
  const existingCitas = await getCitasByDateAndOptometrista(fecha, optometristaId);
  
  const startTime = new Date(`${fecha} ${hora}`);
  const endTime = new Date(startTime.getTime() + duracion * 60000);
  
  for (const cita of existingCitas) {
    const citaStart = new Date(`${cita.fecha} ${cita.hora}`);
    const citaEnd = new Date(citaStart.getTime() + cita.duracion * 60000);
    
    if (startTime < citaEnd && endTime > citaStart) {
      return 'Ya existe una cita en este horario';
    }
  }
  
  return null;
};
```

---

## 📋 Checklist de Validaciones

### ✅ Validaciones Implementadas
- [ ] Campos obligatorios
- [ ] Longitud mínima y máxima
- [ ] Patrones de formato (email, teléfono, etc.)
- [ ] Rangos numéricos
- [ ] Validación de tipos de datos
- [ ] Validación de fechas
- [ ] Validación de horarios
- [ ] Validación de unicidad
- [ ] Validación condicional
- [ ] Mensajes de error claros

### 🔄 Validaciones en Tiempo Real
- [ ] Validación mientras el usuario escribe
- [ ] Validación al perder el foco (blur)
- [ ] Validación al enviar el formulario
- [ ] Feedback visual inmediato

### 🛡️ Validaciones de Seguridad
- [ ] Sanitización de datos
- [ ] Prevención de XSS
- [ ] Validación en frontend y backend
- [ ] Logs de errores de validación

---

## 🎨 Estilos CSS para Validaciones

```css
/* Campo con error */
.form-input.error {
  border-color: #dc3545;
  box-shadow: 0 0 0 0.2rem rgba(220, 53, 69, 0.25);
}

/* Campo válido */
.form-input.valid {
  border-color: #28a745;
  box-shadow: 0 0 0 0.2rem rgba(40, 167, 69, 0.25);
}

/* Mensaje de error */
.error-message {
  color: #dc3545;
  font-size: 0.875rem;
  margin-top: 0.25rem;
  display: flex;
  align-items: center;
  gap: 0.5rem;
}

.error-icon {
  font-size: 1rem;
}

/* Indicador de campo requerido */
.required {
  color: #dc3545;
  margin-left: 0.25rem;
}

/* Animación de validación */
.form-input {
  transition: border-color 0.15s ease-in-out, box-shadow 0.15s ease-in-out;
}

/* Estado de carga */
.form-input.loading {
  background-image: url('data:image/svg+xml;base64,PHN2ZyB3aWR0aD0iMjAiIGhlaWdodD0iMjAiIHZpZXdCb3g9IjAgMCAyMCAyMCIgZmlsbD0ibm9uZSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIj4KPHBhdGggZD0iTTEwIDMuNVYxMEwxNS41IDEwIiBzdHJva2U9IiM2YzY5N2UiIHN0cm9rZS13aWR0aD0iMiIgc3Ryb2tlLWxpbmVjYXA9InJvdW5kIiBzdHJva2UtbGluZWpvaW49InJvdW5kIi8+Cjwvc3ZnPgo=');
  background-repeat: no-repeat;
  background-position: right 0.75rem center;
  background-size: 1rem;
}
```

---

*Esta guía debe ser actualizada conforme se implementen nuevas validaciones o se descubran casos especiales.* 