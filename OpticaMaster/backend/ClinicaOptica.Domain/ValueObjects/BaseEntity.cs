namespace ClinicaOptica.Domain.ValueObjects
{
    /// <summary>
    /// Clase base para todas las entidades del dominio.
    /// Proporciona propiedades comunes y funcionalidad base.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Identificador único de la entidad.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Determina si la entidad es transitoria (no persistida).
        /// </summary>
        /// <returns>True si la entidad no ha sido persistida.</returns>
        public bool IsTransient()
        {
            return Id == default;
        }

        /// <summary>
        /// Compara dos entidades por su Id.
        /// </summary>
        public override bool Equals(object? obj)
        {
            if (obj is not BaseEntity entity)
                return false;

            if (ReferenceEquals(this, entity))
                return true;

            if (GetType() != entity.GetType())
                return false;

            if (IsTransient() || entity.IsTransient())
                return false;

            return Id == entity.Id;
        }

        /// <summary>
        /// Obtiene el código hash basado en el Id.
        /// </summary>
        public override int GetHashCode()
        {
            if (IsTransient())
                return base.GetHashCode();

            return Id.GetHashCode();
        }

        /// <summary>
        /// Operador de igualdad.
        /// </summary>
        public static bool operator ==(BaseEntity? left, BaseEntity? right)
        {
            return left?.Equals(right) ?? Equals(right, null);
        }

        /// <summary>
        /// Operador de desigualdad.
        /// </summary>
        public static bool operator !=(BaseEntity? left, BaseEntity? right)
        {
            return !(left == right);
        }
    }
}