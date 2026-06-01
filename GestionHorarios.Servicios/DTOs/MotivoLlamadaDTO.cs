namespace GestionHorarios.Servicios.DTOs
{
    /// <summary>
    /// DTO para Motivo de Llamada
    /// </summary>
    public class MotivoLlamadaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
    }
}