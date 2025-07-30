using ClinicaOptica.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Representa un diagnóstico médico para un paciente.
    /// </summary>
    public class Diagnostico : BaseEntity
    {
        /// <summary>
        /// Descripción del diagnóstico.
        /// </summary>
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(500)]
        public string Descripcion { get; set; } = string.Empty;

        /// <summary>
        /// Plan de tratamiento recomendado.
        /// </summary>
        [StringLength(1000)]
        public string? PlanTratamiento { get; set; }

        /// <summary>
        /// Pronóstico del paciente.
        /// </summary>
        [StringLength(500)]
        public string? Pronostico { get; set; }
    }
}