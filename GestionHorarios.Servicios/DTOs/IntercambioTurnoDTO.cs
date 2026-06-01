using GestionHorarios.Modelos.Entidades;

namespace GestionHorarios.Servicios.DTOs
{
    /// <summary>
    /// DTO para Intercambio de Turno
    /// </summary>
    public class IntercambioTurnoDTO
    {
        public int Id { get; set; }
        public EstadoIntercambio Estado { get; set; } = EstadoIntercambio.Pendiente;
        public string? Motivo { get; set; }
        public DateTime FechaSolicitud { get; set; } = DateTime.UtcNow;
        public int IdHorarioOriginal { get; set; }
        public int IdMedicoReemplaza { get; set; }
        public string? MedicoReemplazaNombre { get; set; }
    }
}