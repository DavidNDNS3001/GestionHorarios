namespace GestionHorarios.Modelos.Entidades
{
    /// <summary>
    /// Enumeración para los estados de intercambio de turno
    /// </summary>
    public enum EstadoIntercambio
    {
        Pendiente = 0,
        Aprobado = 1,
        Rechazado = 2,
        Cancelado = 3
    }

    /// <summary>
    /// Entidad que representa el intercambio de turno entre médicos
    /// </summary>
    public class IntercambioTurno
    {
        public int Id { get; set; }
        public EstadoIntercambio Estado { get; set; } = EstadoIntercambio.Pendiente;
        public string? Motivo { get; set; }
        public DateTime FechaSolicitud { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        public int IdHorarioOriginal { get; set; }
        public int IdMedicoReemplaza { get; set; }
        public int? AprobadoPor { get; set; }

        // Relaciones
        public HorarioLlamada? HorarioOriginal { get; set; }
        public Medico? MedicoReemplaza { get; set; }
        public Usuario? UsuarioAprobador { get; set; }
    }
}