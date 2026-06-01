namespace GestionHorarios.Servicios.DTOs
{
    /// <summary>
    /// DTO para Usuario
    /// </summary>
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        public int? IdMedico { get; set; }
    }
}