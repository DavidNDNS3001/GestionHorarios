using GestionHorarios.Servicios.DTOs;

namespace GestionHorarios.Servicios.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de Registros de Llamada
    /// </summary>
    public interface IRegistroLlamadaService
    {
        Task<IEnumerable<RegistroLlamadaDTO>> GetAllAsync();
        Task<RegistroLlamadaDTO?> GetByIdAsync(int id);
        Task<IEnumerable<RegistroLlamadaDTO>> GetByHorarioAsync(int idHorario);
        Task<int> CreateAsync(RegistroLlamadaDTO registroDTO);
        Task UpdateAsync(RegistroLlamadaDTO registroDTO);
        Task DeleteAsync(int id);
    }
}