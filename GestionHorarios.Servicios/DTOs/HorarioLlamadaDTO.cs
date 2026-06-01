using GestionHorarios.Modelos.Entidades;

namespace GestionHorarios.Servicios.DTOs
{
    /// <summary>
    /// DTO para Horario de Llamada
    /// </summary>
    public class HorarioLlamadaDTO
    {
        public int Id { get; set; }
        public DateOnly Fecha { get; set; }
        public EstadoHorario Estado { get; set; } = EstadoHorario.Programado;
        public string? Observaciones { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int IdMedico { get; set; }
        public int IdTipoTurno { get; set; }
        public string? NombreMedico { get; set; }
        public string? NombreTurno { get; set; }
    }
}