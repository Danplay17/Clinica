using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Application.DTOs;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.Mappings;
using AutoMapper;

namespace ClinicaOptica.Application.Services
{
    /// <summary>
    /// Servicio para la gestión de optometristas
    /// </summary>
    public class OptometristaService : IOptometristaService
    {
        private readonly IOptometristaRepository _optometristaRepository;
        private readonly IConsultaRepository _consultaRepository;
        private readonly ICitaRepository _citaRepository;
        private readonly IMapper _mapper;

        public OptometristaService(
            IOptometristaRepository optometristaRepository,
            IConsultaRepository consultaRepository,
            ICitaRepository citaRepository,
            IMapper mapper)
        {
            _optometristaRepository = optometristaRepository;
            _consultaRepository = consultaRepository;
            _citaRepository = citaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los optometristas
        /// </summary>
        public async Task<IEnumerable<OptometristaDto>> GetAllAsync()
        {
            var optometristas = await _optometristaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OptometristaDto>>(optometristas);
        }

        /// <summary>
        /// Obtiene un optometrista por ID
        /// </summary>
        public async Task<OptometristaDto?> GetByIdAsync(int id)
        {
            var optometrista = await _optometristaRepository.GetByIdAsync(id);
            return _mapper.Map<OptometristaDto>(optometrista);
        }

        /// <summary>
        /// Crea un nuevo optometrista
        /// </summary>
        public async Task<OptometristaDto> CreateAsync(CreateOptometristaDto createOptometristaDto)
        {
            // Validar que la cédula no esté duplicada
            if (await _optometristaRepository.ExistsByCedulaAsync(createOptometristaDto.CedulaProfesional))
                throw new InvalidOperationException("Ya existe un optometrista con esta cédula profesional");

            // Validar que el correo no esté duplicado
            if (await _optometristaRepository.ExistsByCorreoAsync(createOptometristaDto.Correo))
                throw new InvalidOperationException("Ya existe un optometrista con este correo electrónico");

            // Mapear DTO a entidad
            var optometrista = _mapper.Map<Optometrista>(createOptometristaDto);

            // Crear optometrista
            var optometristaCreado = await _optometristaRepository.CreateAsync(optometrista);

            // Mapear respuesta
            return _mapper.Map<OptometristaDto>(optometristaCreado);
        }

        /// <summary>
        /// Actualiza un optometrista existente
        /// </summary>
        public async Task<OptometristaDto> UpdateAsync(int id, UpdateOptometristaDto updateOptometristaDto)
        {
            // Obtener optometrista existente
            var optometristaExistente = await _optometristaRepository.GetByIdAsync(id);
            if (optometristaExistente == null)
                throw new InvalidOperationException("Optometrista no encontrado");

            // Validar que la cédula no esté duplicada
            if (await _optometristaRepository.ExistsByCedulaAsync(updateOptometristaDto.CedulaProfesional, id))
                throw new InvalidOperationException("Ya existe un optometrista con esta cédula profesional");

            // Validar que el correo no esté duplicado
            if (await _optometristaRepository.ExistsByCorreoAsync(updateOptometristaDto.Correo, id))
                throw new InvalidOperationException("Ya existe un optometrista con este correo electrónico");

            // Actualizar propiedades
            optometristaExistente.Nombre = updateOptometristaDto.Nombre;
            optometristaExistente.CedulaProfesional = updateOptometristaDto.CedulaProfesional;
            optometristaExistente.Especialidad = updateOptometristaDto.Especialidad;
            optometristaExistente.Correo = updateOptometristaDto.Correo;
            optometristaExistente.Telefono = updateOptometristaDto.Telefono;

            // Actualizar optometrista
            var optometristaActualizado = await _optometristaRepository.UpdateAsync(optometristaExistente);

            // Mapear respuesta
            return _mapper.Map<OptometristaDto>(optometristaActualizado);
        }

        /// <summary>
        /// Elimina un optometrista
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            // Verificar si el optometrista tiene consultas o citas asociadas
            var optometrista = await _optometristaRepository.GetByIdAsync(id);
            if (optometrista == null)
                return false;

            if (optometrista.Consultas.Any())
                throw new InvalidOperationException("No se puede eliminar un optometrista que tiene consultas asociadas");

            return await _optometristaRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Obtiene las consultas de un optometrista
        /// </summary>
        public async Task<IEnumerable<ConsultaDto>> GetConsultasAsync(int optometristaId)
        {
            var consultas = await _consultaRepository.GetByOptometristaAsync(optometristaId);
            return _mapper.Map<IEnumerable<ConsultaDto>>(consultas);
        }

        /// <summary>
        /// Obtiene las citas de un optometrista
        /// </summary>
        public async Task<IEnumerable<CitaDto>> GetCitasAsync(int optometristaId)
        {
            var citas = await _citaRepository.GetByOptometristaAsync(optometristaId);
            return _mapper.Map<IEnumerable<CitaDto>>(citas);
        }
    }
} 