using ClinicaOptica.Application.Interfaces;
using ClinicaOptica.Application.DTOs;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.Mappings;
using AutoMapper;

namespace ClinicaOptica.Application.Services
{
    /// <summary>
    /// Servicio para la gestión de pacientes
    /// </summary>
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IConsultaRepository _consultaRepository;
        private readonly IVentaRepository _ventaRepository;
        private readonly IMapper _mapper;

        public PacienteService(
            IPacienteRepository pacienteRepository,
            IConsultaRepository consultaRepository,
            IVentaRepository ventaRepository,
            IMapper mapper)
        {
            _pacienteRepository = pacienteRepository;
            _consultaRepository = consultaRepository;
            _ventaRepository = ventaRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los pacientes
        /// </summary>
        public async Task<IEnumerable<PacienteDto>> GetAllAsync()
        {
            var pacientes = await _pacienteRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PacienteDto>>(pacientes);
        }

        /// <summary>
        /// Obtiene un paciente por ID
        /// </summary>
        public async Task<PacienteDto?> GetByIdAsync(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            return _mapper.Map<PacienteDto>(paciente);
        }

        /// <summary>
        /// Busca pacientes por nombre
        /// </summary>
        public async Task<IEnumerable<PacienteDto>> SearchByNameAsync(string nombre)
        {
            var pacientes = await _pacienteRepository.SearchByNameAsync(nombre);
            return _mapper.Map<IEnumerable<PacienteDto>>(pacientes);
        }

        /// <summary>
        /// Busca pacientes por teléfono
        /// </summary>
        public async Task<IEnumerable<PacienteDto>> SearchByPhoneAsync(string telefono)
        {
            var pacientes = await _pacienteRepository.SearchByPhoneAsync(telefono);
            return _mapper.Map<IEnumerable<PacienteDto>>(pacientes);
        }

        /// <summary>
        /// Crea un nuevo paciente
        /// </summary>
        public async Task<PacienteDto> CreateAsync(CreatePacienteDto createPacienteDto)
        {
            // Validar que el email no esté duplicado si se proporciona
            if (!string.IsNullOrEmpty(createPacienteDto.Email))
            {
                if (await _pacienteRepository.ExistsByEmailAsync(createPacienteDto.Email))
                    throw new InvalidOperationException("Ya existe un paciente con este correo electrónico");
            }

            // Mapear DTO a entidad
            var paciente = _mapper.Map<Paciente>(createPacienteDto);

            // Si el paciente es menor de edad, validar que tenga tutor
            if (paciente.Edad < 18 && paciente.TutorId == null)
                throw new InvalidOperationException("Los pacientes menores de 18 años deben tener un tutor asignado");

            // Crear paciente
            var pacienteCreado = await _pacienteRepository.CreateAsync(paciente);

            // Mapear respuesta
            return _mapper.Map<PacienteDto>(pacienteCreado);
        }

        /// <summary>
        /// Actualiza un paciente existente
        /// </summary>
        public async Task<PacienteDto> UpdateAsync(int id, UpdatePacienteDto updatePacienteDto)
        {
            // Obtener paciente existente
            var pacienteExistente = await _pacienteRepository.GetByIdAsync(id);
            if (pacienteExistente == null)
                throw new InvalidOperationException("Paciente no encontrado");

            // Validar que el email no esté duplicado si se proporciona
            if (!string.IsNullOrEmpty(updatePacienteDto.Email))
            {
                if (await _pacienteRepository.ExistsByEmailAsync(updatePacienteDto.Email, id))
                    throw new InvalidOperationException("Ya existe un paciente con este correo electrónico");
            }

            // Actualizar propiedades
            pacienteExistente.Nombre = updatePacienteDto.Nombre;
            pacienteExistente.Genero = updatePacienteDto.Genero;
            pacienteExistente.Edad = updatePacienteDto.Edad;
            pacienteExistente.EstadoCivil = updatePacienteDto.EstadoCivil;
            pacienteExistente.Escolaridad = updatePacienteDto.Escolaridad;
            pacienteExistente.Ocupacion = updatePacienteDto.Ocupacion;
            pacienteExistente.Domicilio = updatePacienteDto.Domicilio;
            pacienteExistente.Email = updatePacienteDto.Email;
            pacienteExistente.Telefono = updatePacienteDto.Telefono;

            // Actualizar paciente
            var pacienteActualizado = await _pacienteRepository.UpdateAsync(pacienteExistente);

            // Mapear respuesta
            return _mapper.Map<PacienteDto>(pacienteActualizado);
        }

        /// <summary>
        /// Elimina un paciente
        /// </summary>
        public async Task<bool> DeleteAsync(int id)
        {
            // Verificar si el paciente tiene consultas o ventas asociadas
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            if (paciente == null)
                return false;

            if (paciente.Consultas.Any() || paciente.Ventas.Any())
                throw new InvalidOperationException("No se puede eliminar un paciente que tiene consultas o ventas asociadas");

            return await _pacienteRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Obtiene el historial de consultas de un paciente
        /// </summary>
        public async Task<IEnumerable<ConsultaDto>> GetConsultasAsync(int pacienteId)
        {
            var consultas = await _consultaRepository.GetByPacienteAsync(pacienteId);
            return _mapper.Map<IEnumerable<ConsultaDto>>(consultas);
        }

        /// <summary>
        /// Obtiene el historial de ventas de un paciente
        /// </summary>
        public async Task<IEnumerable<VentaDto>> GetVentasAsync(int pacienteId)
        {
            var ventas = await _ventaRepository.GetByPacienteAsync(pacienteId);
            return _mapper.Map<IEnumerable<VentaDto>>(ventas);
        }
    }
} 