using AutoMapper;
using GestionHorarios.Modelos.Entidades;
using GestionHorarios.Servicios.DTOs;

namespace GestionHorarios.Servicios.Mappings
{
    /// <summary>
    /// Perfil de AutoMapper para mapeo entre entidades y DTOs
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Especialidad
            CreateMap<Especialidad, EspecialidadDTO>().ReverseMap();

            // Médico
            CreateMap<Medico, MedicoDTO>()
                .ForMember(dest => dest.NombreEspecialidad, opt => opt.MapFrom(src => src.Especialidad!.Nombre))
                .ReverseMap();

            // TipoTurno
            CreateMap<TipoTurno, TipoTurnoDTO>().ReverseMap();

            // MotivoLlamada
            CreateMap<MotivoLlamada, MotivoLlamadaDTO>().ReverseMap();

            // HorarioLlamada
            CreateMap<HorarioLlamada, HorarioLlamadaDTO>()
                .ForMember(dest => dest.NombreMedico, opt => opt.MapFrom(src => src.Medico!.NombreCompleto))
                .ForMember(dest => dest.NombreTurno, opt => opt.MapFrom(src => src.TipoTurno!.Nombre))
                .ReverseMap();

            // RegistroLlamada
            CreateMap<RegistroLlamada, RegistroLlamadaDTO>()
                .ForMember(dest => dest.MotivoNombre, opt => opt.MapFrom(src => src.Motivo!.Nombre))
                .ReverseMap();

            // IntercambioTurno
            CreateMap<IntercambioTurno, IntercambioTurnoDTO>()
                .ForMember(dest => dest.MedicoReemplazaNombre, opt => opt.MapFrom(src => src.MedicoReemplaza!.NombreCompleto))
                .ReverseMap();

            // Usuario
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}