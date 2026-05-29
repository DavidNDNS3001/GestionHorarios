namespace GestionHorarios.Modelos.Entidades
{
    /// <summary>
    /// Enumeración para los resultados de llamada
    /// </summary>
    public enum ResultadoLlamada
    {
        Asistio = 0,
        NoAsistio = 1,
        EnCamino = 2,
        NoContesta = 3
    }

    /// <summary>
    /// Entidad que representa el registro de una llamada
    /// </summary>
    public class RegistroLlamada
    {
        public int Id { get; set; }
        public DateTime FechaHoraLlamada { get; set; } = DateTime.UtcNow;
        public ResultadoLlamada Resultado { get; set; }
        public int? MinutosRespuesta { get; set; }
        public string? Observaciones { get; set; }

        // Foreign Keys
        public int IdHorario { get; set; }
        public int IdMotivo { get; set; }
        public int RegistradoPor { get; set; }

        // Relaciones
        public HorarioLlamada? Horario { get; set; }
        public MotivoLlamada? Motivo { get; set; }
        public Usuario? UsuarioRegistrador { get; set; }
    }
}