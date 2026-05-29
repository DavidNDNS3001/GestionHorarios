namespace GestionHorarios.Modelos.Entidades
{
    /// <summary>
    /// Entidad que representa un tipo de turno
    /// </summary>
    public class TipoTurno
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        public int DuracionHoras { get; set; }

        // Relaciones
        public ICollection<HorarioLlamada> HorariosLlamada { get; set; } = new List<HorarioLlamada>();

        public string Horario => $"{HoraInicio:HH:mm} - {HoraFin:HH:mm}";
    }
}