using AutoMapper;
using GestionHorarios.Datos.Repositories.Interfaces;
using GestionHorarios.Modelos.Entidades;
using GestionHorarios.Servicios.DTOs;
using GestionHorarios.Servicios.Interfaces;

namespace GestionHorarios.Servicios.Implementacion
{
    /// <summary>
    /// Servicio para operaciones de Horarios de Llamada
    /// </summary>
    public class HorarioLlamadaService : IHorarioLlamadaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HorarioLlamadaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HorarioLlamadaDTO>> GetAllAsync()
        {
            var horarios = await _unitOfWork.HorariosLlamada.GetAllAsync();
            return _mapper.Map<IEnumerable<HorarioLlamadaDTO>>(horarios);
        }

        public async Task<HorarioLlamadaDTO?> GetByIdAsync(int id)
        {
            var horario = await _unitOfWork.HorariosLlamada.GetByIdAsync(id);
            return horario == null ? null : _mapper.Map<HorarioLlamadaDTO>(horario);
        }

        public async Task<IEnumerable<HorarioLlamadaDTO>> GetByMedicoAsync(int idMedico)
        {
            var horarios = await _unitOfWork.HorariosLlamada.FindAsync(h => h.IdMedico == idMedico);
            return _mapper.Map<IEnumerable<HorarioLlamadaDTO>>(horarios);
        }

        public async Task<IEnumerable<HorarioLlamadaDTO>> GetByFechaAsync(DateOnly fecha)
        {
            var horarios = await _unitOfWork.HorariosLlamada.FindAsync(h => h.Fecha == fecha);
            return _mapper.Map<IEnumerable<HorarioLlamadaDTO>>(horarios);
        }

        public async Task<IEnumerable<HorarioLlamadaDTO>> GetByFechaRangeAsync(DateOnly desde, DateOnly hasta)
        {
            var horarios = await _unitOfWork.HorariosLlamada.FindAsync(h => h.Fecha >= desde && h.Fecha <= hasta);
            return _mapper.Map<IEnumerable<HorarioLlamadaDTO>>(horarios);
        }

        public async Task<int> CreateAsync(HorarioLlamadaDTO horarioDTO)
        {
            var horario = _mapper.Map<HorarioLlamada>(horarioDTO);
            await _unitOfWork.HorariosLlamada.AddAsync(horario);
            await _unitOfWork.SaveChangesAsync();
            return horario.Id;
        }

        public async Task UpdateAsync(HorarioLlamadaDTO horarioDTO)
        {
            var horario = _mapper.Map<HorarioLlamada>(horarioDTO);
            _unitOfWork.HorariosLlamada.Update(horario);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var horario = await _unitOfWork.HorariosLlamada.GetByIdAsync(id);
            if (horario != null)
            {
                _unitOfWork.HorariosLlamada.Delete(horario);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}