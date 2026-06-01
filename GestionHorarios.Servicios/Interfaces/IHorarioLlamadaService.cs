using GestionHorarios.Servicios.DTOs;

namespace GestionHorarios.Servicios.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de Horarios de Llamada
    /// </summary>
    public interface IHorarioLlamadaService
    {
        Task<IEnumerable<HorarioLlamadaDTO>> GetAllAsync();
        Task<HorarioLlamadaDTO?> GetByIdAsync(int id);
        Task<IEnumerable<HorarioLlamadaDTO>> GetByMedicoAsync(int idMedico);
        Task<IEnumerable<HorarioLlamadaDTO>> GetByFechaAsync(DateOnly fecha);
        Task<IEnumerable<HorarioLlamadaDTO>> GetByFechaRangeAsync(DateOnly desde, DateOnly hasta);
        Task<int> CreateAsync(HorarioLlamadaDTO horarioDTO);
        Task UpdateAsync(HorarioLlamadaDTO horarioDTO);
        Task DeleteAsync(int id);
    }
}