using GestionHorarios.Modelos.Entidades;

namespace GestionHorarios.Servicios.DTOs
{
    /// <summary>
    /// DTO para Registro de Llamada
    /// </summary>
    public class RegistroLlamadaDTO
    {
        public int Id { get; set; }
        public DateTime FechaHoraLlamada { get; set; } = DateTime.UtcNow;
        public ResultadoLlamada Resultado { get; set; }
        public int? MinutosRespuesta { get; set; }
        public string? Observaciones { get; set; }
        public int IdHorario { get; set; }
        public int IdMotivo { get; set; }
        public string? MotivoNombre { get; set; }
    }
}