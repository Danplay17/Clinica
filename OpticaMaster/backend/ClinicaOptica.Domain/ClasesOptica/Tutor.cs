using System.ComponentModel.DataAnnotations;
using ClinicaOptica.Domain.ValueObjects;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa al tutor legal de un paciente menor de edad.
    /// </summary>
    public class Tutor : BaseEntity
    {
        /// <summary>
        /// Nombre completo del tutor.
        /// </summary>
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        /// <summary>
        /// Número de teléfono del tutor.
        /// </summary>
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [StringLength(15)]
        public string Telefono { get; set; } = string.Empty;

        /// <summary>
        /// Relación con el paciente.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string RelacionConPaciente { get; set; } = string.Empty;

        // Propiedades de navegación
        public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
    }
}