using ClinicaOptica.Domain.ValueObjects;

namespace ClinicaOptica.Domain.ClasesOptica
{
    /// <summary>
    /// Registro de actividades y acciones en el sistema.
    /// </summary>
    public class LogActividad : BaseEntity  // ← Hereda de BaseEntity
    {
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Accion { get; set; } = string.Empty;
        public string? Descripcion { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}