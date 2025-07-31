using AutoMapper;
using ClinicaOptica.Domain.ClasesOptica;
using ClinicaOptica.Application.DTOs;

namespace ClinicaOptica.Application.Mappings
{
    /// <summary>
    /// Perfil de AutoMapper para mapear entre entidades y DTOs
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapeos para Usuario
            CreateMap<Usuario, UsuarioDto>()
                .ForMember(dest => dest.RolNombre, opt => opt.MapFrom(src => src.Rol!.Nombre));

            // Mapeos para Paciente
            CreateMap<Paciente, PacienteDto>()
                .ForMember(dest => dest.FechaCreacion, opt => opt.MapFrom(src => DateTime.Now)); // Temporalmente usamos DateTime.Now

            CreateMap<CreatePacienteDto, Paciente>();

            CreateMap<UpdatePacienteDto, Paciente>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            // Mapeos para Tutor
            CreateMap<Tutor, TutorDto>();
            CreateMap<CreateTutorDto, Tutor>();

            // Mapeos para Optometrista
            CreateMap<Optometrista, OptometristaDto>();

            // Mapeos para Consulta
            CreateMap<Consulta, ConsultaDto>()
                .ForMember(dest => dest.PacienteNombre, opt => opt.MapFrom(src => src.Paciente!.Nombre))
                .ForMember(dest => dest.OptometristaNombre, opt => opt.MapFrom(src => src.Optometrista!.Nombre));

            // Mapeos para Diagnóstico
            CreateMap<Diagnostico, DiagnosticoDto>();

            // Mapeos para Venta
            CreateMap<Venta, VentaDto>()
                .ForMember(dest => dest.PacienteNombre, opt => opt.MapFrom(src => src.Paciente!.Nombre))
                .ForMember(dest => dest.ProductoNombre, opt => opt.MapFrom(src => src.Producto!.Nombre))
                .ForMember(dest => dest.PrecioUnitario, opt => opt.MapFrom(src => src.PrecioUnitario))
                .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total));

            // Mapeos para Producto
            CreateMap<Producto, ProductoDto>();

            // Mapeos para Cita
            CreateMap<Cita, CitaDto>()
                .ForMember(dest => dest.PacienteNombre, opt => opt.MapFrom(src => src.Paciente!.Nombre))
                .ForMember(dest => dest.OptometristaNombre, opt => opt.MapFrom(src => src.Optometrista!.Nombre));
        }
    }
} 