using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Application.DTOs;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.Mappings;
using AutoMapper;

namespace ClinicaOptica.Application.Services
{
    /// <summary>
    /// Servicio para la gestión de productos
    /// </summary>
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;

        public ProductoService(IProductoRepository productoRepository, IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        public async Task<IEnumerable<ProductoDto>> GetAllAsync()
        {
            var productos = await _productoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductoDto>>(productos);
        }

        /// <summary>
        /// Obtiene un producto por ID
        /// </summary>
        public async Task<ProductoDto?> GetByIdAsync(int id)
        {
            var producto = await _productoRepository.GetByIdAsync(id);
            return _mapper.Map<ProductoDto>(producto);
        }

        /// <summary>
        /// Crea un nuevo producto
        /// </summary>
        public async Task<ProductoDto> CreateAsync(CreateProductoDto createProductoDto)
        {
            // Mapear DTO a entidad
            var producto = _mapper.Map<Producto>(createProductoDto);
            producto.Activo = true; // Por defecto activo

            // Crear producto
            var productoCreado = await _productoRepository.CreateAsync(producto);

            // Mapear respuesta
            return _mapper.Map<ProductoDto>(productoCreado);
        }

        /// <summary>
        /// Actualiza un producto existente
        /// </summary>
        public async Task<ProductoDto> UpdateAsync(int id, UpdateProductoDto updateProductoDto)
        {
            // Obtener producto existente
            var productoExistente = await _productoRepository.GetByIdAsync(id);
            if (productoExistente == null)
                throw new InvalidOperationException("Producto no encontrado");

            // Actualizar propiedades
            productoExistente.Nombre = updateProductoDto.Nombre;
            productoExistente.Tipo = updateProductoDto.Tipo;
            productoExistente.Descripcion = updateProductoDto.Descripcion;
            productoExistente.Precio = updateProductoDto.Precio;
            productoExistente.Stock = updateProductoDto.Stock;
            productoExistente.Activo = updateProductoDto.Activo;

            // Actualizar producto
            var productoActualizado = await _productoRepository.UpdateAsync(productoExistente);

            // Mapear respuesta
            return _mapper.Map<ProductoDto>(productoActualizado);
        }

        /// <summary>
        /// Elimina un producto
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            // Verificar si el producto tiene ventas asociadas
            var producto = await _productoRepository.GetByIdAsync(id);
            if (producto == null)
                return false;

            if (producto.Ventas.Any())
                throw new InvalidOperationException("No se puede eliminar un producto que tiene ventas asociadas");

            return await _productoRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Busca productos por nombre
        /// </summary>
        public async Task<IEnumerable<ProductoDto>> SearchByNameAsync(string nombre)
        {
            var productos = await _productoRepository.SearchByNameAsync(nombre);
            return _mapper.Map<IEnumerable<ProductoDto>>(productos);
        }

        /// <summary>
        /// Obtiene productos por tipo
        /// </summary>
        public async Task<IEnumerable<ProductoDto>> GetByTipoAsync(string tipo)
        {
            var productos = await _productoRepository.GetByTipoAsync(tipo);
            return _mapper.Map<IEnumerable<ProductoDto>>(productos);
        }

        /// <summary>
        /// Obtiene productos con stock bajo
        /// </summary>
        public async Task<IEnumerable<ProductoDto>> GetStockBajoAsync(int stockMinimo = 10)
        {
            var productos = await _productoRepository.GetStockBajoAsync(stockMinimo);
            return _mapper.Map<IEnumerable<ProductoDto>>(productos);
        }

        /// <summary>
        /// Actualiza el stock de un producto
        /// </summary>
        public async Task<ProductoDto> UpdateStockAsync(int id, int cantidad)
        {
            var producto = await _productoRepository.UpdateStockAsync(id, cantidad);
            return _mapper.Map<ProductoDto>(producto);
        }
    }
} 