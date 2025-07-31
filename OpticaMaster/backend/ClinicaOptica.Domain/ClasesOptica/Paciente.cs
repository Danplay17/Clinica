using System.ComponentModel.DataAnnotations;
using ClinicaOptica.Domain.ValueObjects;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa a un paciente de la óptica.
    /// </summary>
    public class Paciente : BaseEntity
    {
        /// <summary>
        /// Nombre completo del paciente.
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2)]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Género del paciente.
        /// </summary>
        [Required(ErrorMessage = "El género es obligatorio")]
        [StringLength(20)]
        public string Genero { get; set; } = string.Empty;

        /// <summary>
        /// Edad del paciente en años.
        /// </summary>
        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(0, 120)]
        public int Edad { get; set; }

        /// <summary>
        /// Estado civil del paciente.
        /// </summary>
        [Required(ErrorMessage = "El estado civil es obligatorio")]
        [StringLength(20)]
        public string EstadoCivil { get; set; } = string.Empty;

        /// <summary>
        /// Escolaridad del paciente.
        /// </summary>
        [Required(ErrorMessage = "La escolaridad es obligatoria")]
        [StringLength(50)]
        public string Escolaridad { get; set; } = string.Empty;

        /// <summary>
        /// Ocupación del paciente.
        /// </summary>
        [Required(ErrorMessage = "La ocupación es obligatoria")]
        [StringLength(100)]
        public string Ocupacion { get; set; } = string.Empty;

        /// <summary>
        /// Domicilio del paciente.
        /// </summary>
        [Required(ErrorMessage = "El domicilio es obligatorio")]
        [StringLength(200)]
        public string Domicilio { get; set; } = string.Empty;

        /// <summary>
        /// Correo electrónico del paciente.
        /// </summary>
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }

        /// <summary>
        /// Número de teléfono del paciente.
        /// </summary>
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(15)]
        public string Telefono { get; set; } = string.Empty;

        /// <summary>
        /// Identificador del tutor (opcional, para menores de edad).
        /// </summary>
        public int? TutorId { get; set; }

        // Propiedades de navegación

        /// <summary>
        /// Lista de consultas realizadas a este paciente.
        /// </summary>
        public virtual ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();

        /// <summary>
        /// Lista de ventas realizadas a este paciente.
        /// </summary>
        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();

        /// <summary>
        /// Lista de citas programadas para este paciente.
        /// </summary>
        public virtual ICollection<Cita> Citas { get; set; } = new List<Cita>();

        /// <summary>
        /// Tutor asociado (opcional, para menores de edad).
        /// </summary>
        public virtual Tutor? Tutor { get; set; }
    }
}