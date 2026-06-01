using GestionHorarios.Servicios.DTOs;

namespace GestionHorarios.Servicios.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de Médicos
    /// </summary>
    public interface IMedicoService
    {
        Task<IEnumerable<MedicoDTO>> GetAllAsync();
        Task<MedicoDTO?> GetByIdAsync(int id);
        Task<MedicoDTO?> GetByCedulaAsync(string cedula);
        Task<IEnumerable<MedicoDTO>> GetByEspecialidadAsync(int idEspecialidad);
        Task<int> CreateAsync(MedicoDTO medicoDTO);
        Task UpdateAsync(MedicoDTO medicoDTO);
        Task DeleteAsync(int id);
    }
}