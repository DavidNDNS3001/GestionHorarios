namespace GestionHorarios.Servicios.DTOs
{
    /// <summary>
    /// DTO para Tipo de Turno
    /// </summary>
    public class TipoTurnoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public TimeOnly HoraInicio { get; set; }
        public TimeOnly HoraFin { get; set; }
        public int DuracionHoras { get; set; }
        public string Horario => $"{HoraInicio:HH:mm} - {HoraFin:HH:mm}";
    }
}