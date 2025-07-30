using System.ComponentModel.DataAnnotations;
using ClinicaOptica.Domain.ValueObjects;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa a un optometrista profesional del sistema.
    /// </summary>
    public class Optometrista : BaseEntity
    {
        /// <summary>
        /// Nombre completo del optometrista.
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, MinimumLength = 2)]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Cédula profesional del optometrista.
        /// </summary>
        [Required(ErrorMessage = "La cédula profesional es obligatoria")]
        [StringLength(20)]
        public string CedulaProfesional { get; set; } = string.Empty;

        /// <summary>
        /// Especialidad del optometrista.
        /// </summary>
        [Required(ErrorMessage = "La especialidad es obligatoria")]
        [StringLength(100)]
        public string Especialidad { get; set; } = string.Empty;

        /// <summary>
        /// Correo electrónico profesional del optometrista.
        /// </summary>
        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress]
        [StringLength(100)]
        public string Correo { get; set; } = string.Empty;

        /// <summary>
        /// Número de teléfono de contacto.
        /// </summary>
        [StringLength(15)]
        public string? Telefono { get; set; }

        /// <summary>
        /// Identificador del usuario asociado.
        /// </summary>
        [Required]
        public int UsuarioId { get; set; }

        // Propiedades de navegación

        /// <summary>
        /// Usuario asociado a este optometrista.
        /// </summary>
        public virtual Usuario? Usuario { get; set; }

        /// <summary>
        /// Lista de consultas realizadas por este optometrista.
        /// </summary>
        public virtual ICollection<Consulta> Consultas { get; set; } = new List<Consulta>();
    }
}