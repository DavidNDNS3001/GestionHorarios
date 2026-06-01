using GestionHorarios.Servicios.DTOs;

namespace GestionHorarios.Servicios.Interfaces
{
    /// <summary>
    /// Interfaz para el servicio de Intercambio de Turno
    /// </summary>
    public interface IIntercambioTurnoService
    {
        Task<IEnumerable<IntercambioTurnoDTO>> GetAllAsync();
        Task<IntercambioTurnoDTO?> GetByIdAsync(int id);
        Task<IEnumerable<IntercambioTurnoDTO>> GetPendientesAsync();
        Task<int> SolicitarIntercambioAsync(IntercambioTurnoDTO intercambioDTO);
        Task AprobarIntercambioAsync(int id, int usuarioAprobadorId);
        Task RechazarIntercambioAsync(int id);
        Task DeleteAsync(int id);
    }
}