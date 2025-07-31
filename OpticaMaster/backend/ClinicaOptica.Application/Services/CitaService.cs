using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Application.DTOs;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.Mappings;
using AutoMapper;

namespace ClinicaOptica.Application.Services
{
    /// <summary>
    /// Servicio para la gestión de citas
    /// </summary>
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _citaRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IOptometristaRepository _optometristaRepository;
        private readonly IMapper _mapper;

        public CitaService(
            ICitaRepository citaRepository,
            IPacienteRepository pacienteRepository,
            IOptometristaRepository optometristaRepository,
            IMapper mapper)
        {
            _citaRepository = citaRepository;
            _pacienteRepository = pacienteRepository;
            _optometristaRepository = optometristaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todas las citas
        /// </summary>
        public async Task<IEnumerable<CitaDto>> GetAllAsync()
        {
            var citas = await _citaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CitaDto>>(citas);
        }

        /// <summary>
        /// Obtiene una cita por ID
        /// </summary>
        public async Task<CitaDto?> GetByIdAsync(int id)
        {
            var cita = await _citaRepository.GetByIdAsync(id);
            return _mapper.Map<CitaDto>(cita);
        }

        /// <summary>
        /// Crea una nueva cita
        /// </summary>
        public async Task<CitaDto> CreateAsync(CreateCitaDto createCitaDto)
        {
            // Validar que el paciente existe
            var paciente = await _pacienteRepository.GetByIdAsync(createCitaDto.PacienteId);
            if (paciente == null)
                throw new InvalidOperationException("Paciente no encontrado");

            // Validar que el optometrista existe
            var optometrista = await _optometristaRepository.GetByIdAsync(createCitaDto.OptometristaId);
            if (optometrista == null)
                throw new InvalidOperationException("Optometrista no encontrado");

            // Validar disponibilidad de horario
            if (!await _citaRepository.VerificarDisponibilidadAsync(
                createCitaDto.OptometristaId,
                createCitaDto.Fecha,
                createCitaDto.Hora,
                createCitaDto.Duracion))
            {
                throw new InvalidOperationException("El horario seleccionado no está disponible");
            }

            // Crear cita
            var cita = new Cita
            {
                PacienteId = createCitaDto.PacienteId,
                OptometristaId = createCitaDto.OptometristaId,
                Fecha = createCitaDto.Fecha,
                Hora = createCitaDto.Hora,
                Tipo = createCitaDto.Tipo,
                Duracion = createCitaDto.Duracion,
                Observaciones = createCitaDto.Observaciones,
                Estado = "Programada" // Estado por defecto
            };

            // Guardar cita
            var citaCreada = await _citaRepository.CreateAsync(cita);

            // Mapear respuesta
            return _mapper.Map<CitaDto>(citaCreada);
        }

        /// <summary>
        /// Actualiza una cita existente
        /// </summary>
        public async Task<CitaDto> UpdateAsync(int id, UpdateCitaDto updateCitaDto)
        {
            // Obtener cita existente
            var citaExistente = await _citaRepository.GetByIdAsync(id);
            if (citaExistente == null)
                throw new InvalidOperationException("Cita no encontrada");

            // Validar disponibilidad de horario si se cambió
            if (citaExistente.Fecha != updateCitaDto.Fecha || 
                citaExistente.Hora != updateCitaDto.Hora || 
                citaExistente.Duracion != updateCitaDto.Duracion)
            {
                if (!await _citaRepository.VerificarDisponibilidadAsync(
                    citaExistente.OptometristaId,
                    updateCitaDto.Fecha,
                    updateCitaDto.Hora,
                    updateCitaDto.Duracion,
                    id))
                {
                    throw new InvalidOperationException("El horario seleccionado no está disponible");
                }
            }

            // Actualizar propiedades
            citaExistente.Fecha = updateCitaDto.Fecha;
            citaExistente.Hora = updateCitaDto.Hora;
            citaExistente.Tipo = updateCitaDto.Tipo;
            citaExistente.Estado = updateCitaDto.Estado;
            citaExistente.Duracion = updateCitaDto.Duracion;
            citaExistente.Observaciones = updateCitaDto.Observaciones;

            // Actualizar cita
            var citaActualizada = await _citaRepository.UpdateAsync(citaExistente);

            // Mapear respuesta
            return _mapper.Map<CitaDto>(citaActualizada);
        }

        /// <summary>
        /// Elimina una cita
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            return await _citaRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Obtiene las citas de un paciente
        /// </summary>
        public async Task<IEnumerable<CitaDto>> GetByPacienteAsync(int pacienteId)
        {
            var citas = await _citaRepository.GetByPacienteAsync(pacienteId);
            return _mapper.Map<IEnumerable<CitaDto>>(citas);
        }

        /// <summary>
        /// Obtiene las citas de un optometrista
        /// </summary>
        public async Task<IEnumerable<CitaDto>> GetByOptometristaAsync(int optometristaId)
        {
            var citas = await _citaRepository.GetByOptometristaAsync(optometristaId);
            return _mapper.Map<IEnumerable<CitaDto>>(citas);
        }

        /// <summary>
        /// Obtiene las citas por fecha
        /// </summary>
        public async Task<IEnumerable<CitaDto>> GetByFechaAsync(DateTime fecha)
        {
            var citas = await _citaRepository.GetByFechaAsync(fecha);
            return _mapper.Map<IEnumerable<CitaDto>>(citas);
        }

        /// <summary>
        /// Obtiene las citas por rango de fechas
        /// </summary>
        public async Task<IEnumerable<CitaDto>> GetByFechaRangeAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            var citas = await _citaRepository.GetByFechaRangeAsync(fechaDesde, fechaHasta);
            return _mapper.Map<IEnumerable<CitaDto>>(citas);
        }

        /// <summary>
        /// Obtiene las citas por estado
        /// </summary>
        public async Task<IEnumerable<CitaDto>> GetByEstadoAsync(string estado)
        {
            var citas = await _citaRepository.GetByEstadoAsync(estado);
            return _mapper.Map<IEnumerable<CitaDto>>(citas);
        }

        /// <summary>
        /// Verifica disponibilidad de horario
        /// </summary>
        public async Task<bool> VerificarDisponibilidadAsync(int optometristaId, DateTime fecha, TimeSpan hora, int duracion, int? excludeCitaId = null)
        {
            return await _citaRepository.VerificarDisponibilidadAsync(optometristaId, fecha, hora, duracion, excludeCitaId);
        }

        /// <summary>
        /// Cancela una cita
        /// </summary>
        public async Task<CitaDto> CancelarAsync(int id)
        {
            var cita = await _citaRepository.GetByIdAsync(id);
            if (cita == null)
                throw new InvalidOperationException("Cita no encontrada");

            cita.Estado = "Cancelada";
            var citaCancelada = await _citaRepository.UpdateAsync(cita);

            return _mapper.Map<CitaDto>(citaCancelada);
        }

        /// <summary>
        /// Confirma una cita
        /// </summary>
        public async Task<CitaDto> ConfirmarAsync(int id)
        {
            var cita = await _citaRepository.GetByIdAsync(id);
            if (cita == null)
                throw new InvalidOperationException("Cita no encontrada");

            cita.Estado = "Confirmada";
            var citaConfirmada = await _citaRepository.UpdateAsync(cita);

            return _mapper.Map<CitaDto>(citaConfirmada);
        }
    }
} 