using ClinicaOptica.Domain.ClasesOptica;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el repositorio de productos
    /// </summary>
    public interface IProductoRepository
    {
        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns>Lista de productos</returns>
        Task<IEnumerable<Producto>> GetAllAsync();

        /// <summary>
        /// Obtiene un producto por ID
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <returns>Producto encontrado o null</returns>
        Task<Producto?> GetByIdAsync(int id);

        /// <summary>
        /// Busca productos por nombre
        /// </summary>
        /// <param name="nombre">Nombre a buscar</param>
        /// <returns>Lista de productos que coinciden</returns>
        Task<IEnumerable<Producto>> SearchByNameAsync(string nombre);

        /// <summary>
        /// Obtiene productos por tipo
        /// </summary>
        /// <param name="tipo">Tipo de producto</param>
        /// <returns>Lista de productos del tipo especificado</returns>
        Task<IEnumerable<Producto>> GetByTipoAsync(string tipo);

        /// <summary>
        /// Obtiene productos con stock bajo
        /// </summary>
        /// <param name="stockMinimo">Stock mínimo</param>
        /// <returns>Lista de productos con stock bajo</returns>
        Task<IEnumerable<Producto>> GetStockBajoAsync(int stockMinimo);

        /// <summary>
        /// Crea un nuevo producto
        /// </summary>
        /// <param name="producto">Datos del producto</param>
        /// <returns>Producto creado</returns>
        Task<Producto> CreateAsync(Producto producto);

        /// <summary>
        /// Actualiza un producto existente
        /// </summary>
        /// <param name="producto">Datos actualizados del producto</param>
        /// <returns>Producto actualizado</returns>
        Task<Producto> UpdateAsync(Producto producto);

        /// <summary>
        /// Elimina un producto
        /// </summary>
        /// <param name="id">ID del producto a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Actualiza el stock de un producto
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="cantidad">Cantidad a agregar/quitar</param>
        /// <returns>Producto actualizado</returns>
        Task<Producto> UpdateStockAsync(int id, int cantidad);
    }
} 