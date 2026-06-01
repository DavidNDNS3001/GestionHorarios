namespace GestionHorarios.Servicios.DTOs
{
    /// <summary>
    /// DTO para Especialidad
    /// </summary>
    public class EspecialidadDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
    }
}