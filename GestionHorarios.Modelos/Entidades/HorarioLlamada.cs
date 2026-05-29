namespace GestionHorarios.Modelos.Entidades
{
    /// <summary>
    /// Enumeración para los estados del horario de llamada
    /// </summary>
    public enum EstadoHorario
    {
        Programado = 0,
        EnCurso = 1,
        Completado = 2,
        Cancelado = 3
    }

    /// <summary>
    /// Entidad que representa un horario de llamada (asignación de médico a turno)
    /// </summary>
    public class HorarioLlamada
    {
        public int Id { get; set; }
        public DateOnly Fecha { get; set; }
        public EstadoHorario Estado { get; set; } = EstadoHorario.Programado;
        public string? Observaciones { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Foreign Keys
        public int IdMedico { get; set; }
        public int IdTipoTurno { get; set; }
        public int CreadoPor { get; set; }

        // Relaciones
        public Medico? Medico { get; set; }
        public TipoTurno? TipoTurno { get; set; }
        public Usuario? UsuarioCreador { get; set; }
        public ICollection<RegistroLlamada> RegistrosLlamada { get; set; } = new List<RegistroLlamada>();
        public ICollection<IntercambioTurno> IntercambiosTurno { get; set; } = new List<IntercambioTurno>();
    }
}