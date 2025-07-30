using ClinicaOptica.Domain.ValueObjects;

namespace ClinicaOptica.Domain.ClasesOptica
{
    public class Notificacion : BaseEntity
    {
        public int? UsuarioId { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public DateTime FechaEnvio { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}