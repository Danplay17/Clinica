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

        // Propiedades de navegación

        /// <summary>
        /// Lista de consultas realizadas a este paciente.
        /// </summary>
        public virtual ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();

        /// <summary>
        /// Lista de ventas realizadas a este paciente.
        /// </summary>
        public virtual ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}