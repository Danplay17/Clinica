using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Application.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de gestión de productos
    /// </summary>
    public interface IProductoService
    {
        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns>Lista de productos</returns>
        Task<IEnumerable<ProductoDto>> GetAllAsync();

        /// <summary>
        /// Obtiene un producto por ID
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <returns>Producto encontrado</returns>
        Task<ProductoDto?> GetByIdAsync(int id);

        /// <summary>
        /// Crea un nuevo producto
        /// </summary>
        /// <param name="createProductoDto">Datos del producto a crear</param>
        /// <returns>Producto creado</returns>
        Task<ProductoDto> CreateAsync(CreateProductoDto createProductoDto);

        /// <summary>
        /// Actualiza un producto existente
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="updateProductoDto">Datos actualizados</param>
        /// <returns>Producto actualizado</returns>
        Task<ProductoDto> UpdateAsync(int id, UpdateProductoDto updateProductoDto);

        /// <summary>
        /// Elimina un producto
        /// </summary>
        /// <param name="id">ID del producto a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Busca productos por nombre
        /// </summary>
        /// <param name="nombre">Nombre a buscar</param>
        /// <returns>Lista de productos que coinciden</returns>
        Task<IEnumerable<ProductoDto>> SearchByNameAsync(string nombre);

        /// <summary>
        /// Obtiene productos por tipo
        /// </summary>
        /// <param name="tipo">Tipo de producto</param>
        /// <returns>Lista de productos del tipo especificado</returns>
        Task<IEnumerable<ProductoDto>> GetByTipoAsync(string tipo);

        /// <summary>
        /// Obtiene productos con stock bajo
        /// </summary>
        /// <param name="stockMinimo">Stock mínimo (por defecto 10)</param>
        /// <returns>Lista de productos con stock bajo</returns>
        Task<IEnumerable<ProductoDto>> GetStockBajoAsync(int stockMinimo = 10);

        /// <summary>
        /// Actualiza el stock de un producto
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="cantidad">Cantidad a agregar/quitar</param>
        /// <returns>Producto actualizado</returns>
        Task<ProductoDto> UpdateStockAsync(int id, int cantidad);
    }
} 