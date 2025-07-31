using ClinicaOptica.Domain.ClasesOptica;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de antecedentes clínicos.
    /// </summary>
    public interface IAntecedentesRepository
    {
        /// <summary>
        /// Obtiene los antecedentes por ID de consulta.
        /// </summary>
        Task<Antecedentes?> GetByConsultaIdAsync(int consultaId);

        /// <summary>
        /// Crea nuevos antecedentes.
        /// </summary>
        Task<Antecedentes> CreateAsync(Antecedentes antecedentes);

        /// <summary>
        /// Actualiza antecedentes existentes.
        /// </summary>
        Task<Antecedentes> UpdateAsync(Antecedentes antecedentes);

        /// <summary>
        /// Elimina antecedentes.
        /// </summary>
        Task DeleteAsync(int id);

        /// <summary>
        /// Verifica si existen antecedentes para una consulta.
        /// </summary>
        Task<bool> ExistsByConsultaIdAsync(int consultaId);
    }
} 