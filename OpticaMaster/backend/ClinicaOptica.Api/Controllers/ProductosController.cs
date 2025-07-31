using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Api.Controllers
{
    /// <summary>
    /// Controlador para la gestión de productos
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        /// <summary>
        /// Obtiene todos los productos
        /// </summary>
        /// <returns>Lista de productos</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductoDto>), 200)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var productos = await _productoService.GetAllAsync();
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un producto por ID
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <returns>Producto encontrado</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductoDto), 200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var producto = await _productoService.GetByIdAsync(id);
                if (producto == null)
                    return NotFound(new { message = "Producto no encontrado" });

                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Busca productos por nombre
        /// </summary>
        /// <param name="nombre">Nombre a buscar</param>
        /// <returns>Lista de productos que coinciden</returns>
        [HttpGet("search")]
        [ProducesResponseType(typeof(IEnumerable<ProductoDto>), 200)]
        public async Task<IActionResult> SearchByName([FromQuery] string nombre)
        {
            try
            {
                var productos = await _productoService.SearchByNameAsync(nombre);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene productos por tipo
        /// </summary>
        /// <param name="tipo">Tipo de producto</param>
        /// <returns>Lista de productos del tipo especificado</returns>
        [HttpGet("tipo/{tipo}")]
        [ProducesResponseType(typeof(IEnumerable<ProductoDto>), 200)]
        public async Task<IActionResult> GetByTipo(string tipo)
        {
            try
            {
                var productos = await _productoService.GetByTipoAsync(tipo);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene productos con stock bajo
        /// </summary>
        /// <param name="stockMinimo">Stock mínimo (opcional, por defecto 10)</param>
        /// <returns>Lista de productos con stock bajo</returns>
        [HttpGet("stock-bajo")]
        [ProducesResponseType(typeof(IEnumerable<ProductoDto>), 200)]
        public async Task<IActionResult> GetStockBajo([FromQuery] int stockMinimo = 10)
        {
            try
            {
                var productos = await _productoService.GetStockBajoAsync(stockMinimo);
                return Ok(productos);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo producto
        /// </summary>
        /// <param name="createProductoDto">Datos del producto a crear</param>
        /// <returns>Producto creado</returns>
        [HttpPost]
        [ProducesResponseType(typeof(ProductoDto), 201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Create([FromBody] CreateProductoDto createProductoDto)
        {
            try
            {
                var producto = await _productoService.CreateAsync(createProductoDto);
                return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza un producto existente
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="updateProductoDto">Datos actualizados</param>
        /// <returns>Producto actualizado</returns>
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductoDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductoDto updateProductoDto)
        {
            try
            {
                var producto = await _productoService.UpdateAsync(id, updateProductoDto);
                return Ok(producto);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un producto
        /// </summary>
        /// <param name="id">ID del producto a eliminar</param>
        /// <returns>True si se eliminó correctamente</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _productoService.DeleteAsync(id);
                return Ok(new { success = result });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        /// <summary>
        /// Actualiza el stock de un producto
        /// </summary>
        /// <param name="id">ID del producto</param>
        /// <param name="cantidad">Cantidad a agregar/quitar</param>
        /// <returns>Producto actualizado</returns>
        [HttpPut("{id}/stock")]
        [ProducesResponseType(typeof(ProductoDto), 200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] int cantidad)
        {
            try
            {
                var producto = await _productoService.UpdateStockAsync(id, cantidad);
                return Ok(producto);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
} 