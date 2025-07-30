using ClinicaOptica.Domain.ValueObjects;

namespace ClinicaOptica.Domain.ClasesOptica
{
    public class Consulta : BaseEntity
    {
        public int PacienteId { get; set; }
        public int OptometristaId { get; set; }
        public DateTime Fecha { get; set; }
        public string? Observaciones { get; set; }

        public virtual Paciente? Paciente { get; set; }
        public virtual Optometrista? Optometrista { get; set; }
    }
}