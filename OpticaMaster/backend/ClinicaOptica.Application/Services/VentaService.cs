using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Application.DTOs;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.Mappings;
using AutoMapper;

namespace ClinicaOptica.Application.Services
{
    /// <summary>
    /// Servicio para la gestión de ventas
    /// </summary>
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IProductoRepository _productoRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IMapper _mapper;

        public VentaService(
            IVentaRepository ventaRepository,
            IProductoRepository productoRepository,
            IPacienteRepository pacienteRepository,
            IMapper mapper)
        {
            _ventaRepository = ventaRepository;
            _productoRepository = productoRepository;
            _pacienteRepository = pacienteRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todas las ventas
        /// </summary>
        public async Task<IEnumerable<VentaDto>> GetAllAsync()
        {
            var ventas = await _ventaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<VentaDto>>(ventas);
        }

        /// <summary>
        /// Obtiene una venta por ID
        /// </summary>
        public async Task<VentaDto?> GetByIdAsync(int id)
        {
            var venta = await _ventaRepository.GetByIdAsync(id);
            return _mapper.Map<VentaDto>(venta);
        }

        /// <summary>
        /// Crea una nueva venta
        /// </summary>
        public async Task<VentaDto> CreateAsync(CreateVentaDto createVentaDto)
        {
            // Validar que el paciente existe
            var paciente = await _pacienteRepository.GetByIdAsync(createVentaDto.PacienteId);
            if (paciente == null)
                throw new InvalidOperationException("Paciente no encontrado");

            // Validar que el producto existe
            var producto = await _productoRepository.GetByIdAsync(createVentaDto.ProductoId);
            if (producto == null)
                throw new InvalidOperationException("Producto no encontrado");

            // Validar stock disponible
            if (producto.Stock < createVentaDto.Cantidad)
                throw new InvalidOperationException($"Stock insuficiente. Disponible: {producto.Stock}, Solicitado: {createVentaDto.Cantidad}");

            // Crear venta
            var venta = new Venta
            {
                PacienteId = createVentaDto.PacienteId,
                ProductoId = createVentaDto.ProductoId,
                Cantidad = createVentaDto.Cantidad,
                Fecha = createVentaDto.Fecha
            };

            // Guardar venta
            var ventaCreada = await _ventaRepository.CreateAsync(venta);

            // Actualizar stock del producto
            await _productoRepository.UpdateStockAsync(createVentaDto.ProductoId, -createVentaDto.Cantidad);

            // Mapear respuesta
            return _mapper.Map<VentaDto>(ventaCreada);
        }

        /// <summary>
        /// Actualiza una venta existente
        /// </summary>
        public async Task<VentaDto> UpdateAsync(int id, UpdateVentaDto updateVentaDto)
        {
            // Obtener venta existente
            var ventaExistente = await _ventaRepository.GetByIdAsync(id);
            if (ventaExistente == null)
                throw new InvalidOperationException("Venta no encontrada");

            // Calcular diferencia en cantidad
            var diferenciaCantidad = updateVentaDto.Cantidad - ventaExistente.Cantidad;

            // Validar stock si se está aumentando la cantidad
            if (diferenciaCantidad > 0)
            {
                var producto = await _productoRepository.GetByIdAsync(ventaExistente.ProductoId);
                if (producto.Stock < diferenciaCantidad)
                    throw new InvalidOperationException($"Stock insuficiente para actualizar la venta. Disponible: {producto.Stock}, Necesario: {diferenciaCantidad}");
            }

            // Actualizar propiedades
            ventaExistente.Cantidad = updateVentaDto.Cantidad;
            ventaExistente.Fecha = updateVentaDto.Fecha;

            // Actualizar venta
            var ventaActualizada = await _ventaRepository.UpdateAsync(ventaExistente);

            // Actualizar stock del producto
            await _productoRepository.UpdateStockAsync(ventaExistente.ProductoId, -diferenciaCantidad);

            // Mapear respuesta
            return _mapper.Map<VentaDto>(ventaActualizada);
        }

        /// <summary>
        /// Elimina una venta
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            // Obtener venta para restaurar stock
            var venta = await _ventaRepository.GetByIdAsync(id);
            if (venta == null)
                return false;

            // Restaurar stock del producto
            await _productoRepository.UpdateStockAsync(venta.ProductoId, venta.Cantidad);

            return await _ventaRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Obtiene las ventas de un paciente
        /// </summary>
        public async Task<IEnumerable<VentaDto>> GetByPacienteAsync(int pacienteId)
        {
            var ventas = await _ventaRepository.GetByPacienteAsync(pacienteId);
            return _mapper.Map<IEnumerable<VentaDto>>(ventas);
        }

        /// <summary>
        /// Obtiene las ventas por rango de fechas
        /// </summary>
        public async Task<IEnumerable<VentaDto>> GetByFechaRangeAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            var ventas = await _ventaRepository.GetByFechaRangeAsync(fechaDesde, fechaHasta);
            return _mapper.Map<IEnumerable<VentaDto>>(ventas);
        }

        /// <summary>
        /// Obtiene el total de ventas por período
        /// </summary>
        public async Task<decimal> GetTotalVentasAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            return await _ventaRepository.GetTotalVentasAsync(fechaDesde, fechaHasta);
        }

        /// <summary>
        /// Obtiene estadísticas de ventas
        /// </summary>
        public async Task<VentasEstadisticasDto> GetEstadisticasAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            var totalVentas = await _ventaRepository.GetTotalVentasAsync(fechaDesde, fechaHasta);
            var ventas = await _ventaRepository.GetByFechaRangeAsync(fechaDesde, fechaHasta);
            var estadisticasPorDia = await _ventaRepository.GetEstadisticasPorDiaAsync(fechaDesde, fechaHasta);
            var estadisticasPorProducto = await _ventaRepository.GetEstadisticasPorProductoAsync(fechaDesde, fechaHasta);

            var ventasList = ventas.ToList();
            var numeroTransacciones = ventasList.Count;
            var promedioPorVenta = numeroTransacciones > 0 ? totalVentas / numeroTransacciones : 0;

            // Obtener producto más vendido
            var productoMasVendido = estadisticasPorProducto.FirstOrDefault() as dynamic;
            var nombreProductoMasVendido = productoMasVendido?.ProductoNombre ?? "N/A";
            var cantidadProductoMasVendido = productoMasVendido?.Cantidad ?? 0;

            // Mapear estadísticas por día
            var ventasPorDia = estadisticasPorDia.Select(x => new VentaPorDiaDto
            {
                Fecha = ((dynamic)x).Fecha,
                Total = ((dynamic)x).Total,
                NumeroTransacciones = ((dynamic)x).NumeroTransacciones
            }).ToList();

            // Mapear estadísticas por producto
            var ventasPorProducto = estadisticasPorProducto.Select(x => new VentaPorProductoDto
            {
                ProductoId = ((dynamic)x).ProductoId,
                ProductoNombre = ((dynamic)x).ProductoNombre,
                Cantidad = ((dynamic)x).Cantidad,
                Total = ((dynamic)x).Total
            }).ToList();

            return new VentasEstadisticasDto
            {
                TotalVentas = totalVentas,
                NumeroTransacciones = numeroTransacciones,
                PromedioPorVenta = promedioPorVenta,
                ProductoMasVendido = nombreProductoMasVendido,
                CantidadProductoMasVendido = cantidadProductoMasVendido,
                VentasPorDia = ventasPorDia,
                VentasPorProducto = ventasPorProducto
            };
        }
    }
} 