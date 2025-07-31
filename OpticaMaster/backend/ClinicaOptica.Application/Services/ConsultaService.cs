using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Application.DTOs;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.Mappings;
using AutoMapper;

namespace ClinicaOptica.Application.Services
{
    /// <summary>
    /// Servicio para la gestión de consultas
    /// </summary>
    public class ConsultaService : IConsultaService
    {
        private readonly IConsultaRepository _consultaRepository;
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IOptometristaRepository _optometristaRepository;
        private readonly IMapper _mapper;

        public ConsultaService(
            IConsultaRepository consultaRepository,
            IPacienteRepository pacienteRepository,
            IOptometristaRepository optometristaRepository,
            IMapper mapper)
        {
            _consultaRepository = consultaRepository;
            _pacienteRepository = pacienteRepository;
            _optometristaRepository = optometristaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todas las consultas
        /// </summary>
        public async Task<IEnumerable<ConsultaDto>> GetAllAsync()
        {
            var consultas = await _consultaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ConsultaDto>>(consultas);
        }

        /// <summary>
        /// Obtiene una consulta por ID
        /// </summary>
        public async Task<ConsultaDto?> GetByIdAsync(int id)
        {
            var consulta = await _consultaRepository.GetByIdAsync(id);
            return _mapper.Map<ConsultaDto>(consulta);
        }

        /// <summary>
        /// Crea una nueva consulta
        /// </summary>
        public async Task<ConsultaDto> CreateAsync(CreateConsultaDto createConsultaDto)
        {
            // Validar que el paciente existe
            var paciente = await _pacienteRepository.GetByIdAsync(createConsultaDto.PacienteId);
            if (paciente == null)
                throw new InvalidOperationException("Paciente no encontrado");

            // Validar que el optometrista existe
            var optometrista = await _optometristaRepository.GetByIdAsync(createConsultaDto.OptometristaId);
            if (optometrista == null)
                throw new InvalidOperationException("Optometrista no encontrado");

            // Crear consulta
            var consulta = new Consulta
            {
                PacienteId = createConsultaDto.PacienteId,
                OptometristaId = createConsultaDto.OptometristaId,
                Fecha = createConsultaDto.Fecha,
                Observaciones = createConsultaDto.Observaciones
            };

            // Crear diagnóstico si se proporciona
            if (createConsultaDto.Diagnostico != null)
            {
                consulta.Diagnostico = new Diagnostico
                {
                    Descripcion = createConsultaDto.Diagnostico.Descripcion,
                    PlanTratamiento = createConsultaDto.Diagnostico.PlanTratamiento,
                    Pronostico = createConsultaDto.Diagnostico.Pronostico
                };
            }

            // Guardar consulta
            var consultaCreada = await _consultaRepository.CreateAsync(consulta);

            // Mapear respuesta
            return _mapper.Map<ConsultaDto>(consultaCreada);
        }

        /// <summary>
        /// Actualiza una consulta existente
        /// </summary>
        public async Task<ConsultaDto> UpdateAsync(int id, UpdateConsultaDto updateConsultaDto)
        {
            // Obtener consulta existente
            var consultaExistente = await _consultaRepository.GetByIdAsync(id);
            if (consultaExistente == null)
                throw new InvalidOperationException("Consulta no encontrada");

            // Actualizar propiedades
            consultaExistente.Fecha = updateConsultaDto.Fecha;
            consultaExistente.Observaciones = updateConsultaDto.Observaciones;

            // Actualizar diagnóstico si se proporciona
            if (updateConsultaDto.Diagnostico != null)
            {
                if (consultaExistente.Diagnostico == null)
                {
                    consultaExistente.Diagnostico = new Diagnostico();
                }

                consultaExistente.Diagnostico.Descripcion = updateConsultaDto.Diagnostico.Descripcion;
                consultaExistente.Diagnostico.PlanTratamiento = updateConsultaDto.Diagnostico.PlanTratamiento;
                consultaExistente.Diagnostico.Pronostico = updateConsultaDto.Diagnostico.Pronostico;
            }

            // Actualizar consulta
            var consultaActualizada = await _consultaRepository.UpdateAsync(consultaExistente);

            // Mapear respuesta
            return _mapper.Map<ConsultaDto>(consultaActualizada);
        }

        /// <summary>
        /// Elimina una consulta
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            return await _consultaRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Obtiene las consultas de un paciente
        /// </summary>
        public async Task<IEnumerable<ConsultaDto>> GetByPacienteAsync(int pacienteId)
        {
            var consultas = await _consultaRepository.GetByPacienteAsync(pacienteId);
            return _mapper.Map<IEnumerable<ConsultaDto>>(consultas);
        }

        /// <summary>
        /// Obtiene las consultas de un optometrista
        /// </summary>
        public async Task<IEnumerable<ConsultaDto>> GetByOptometristaAsync(int optometristaId)
        {
            var consultas = await _consultaRepository.GetByOptometristaAsync(optometristaId);
            return _mapper.Map<IEnumerable<ConsultaDto>>(consultas);
        }

        /// <summary>
        /// Obtiene las consultas por rango de fechas
        /// </summary>
        public async Task<IEnumerable<ConsultaDto>> GetByFechaRangeAsync(DateTime fechaDesde, DateTime fechaHasta)
        {
            var consultas = await _consultaRepository.GetByFechaRangeAsync(fechaDesde, fechaHasta);
            return _mapper.Map<IEnumerable<ConsultaDto>>(consultas);
        }
    }
} 