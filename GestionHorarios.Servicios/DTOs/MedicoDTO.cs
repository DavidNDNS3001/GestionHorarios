namespace GestionHorarios.Servicios.DTOs
{
    /// <summary>
    /// DTO para Médico
    /// </summary>
    public class MedicoDTO
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string RegistroMedico { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;
        public int IdEspecialidad { get; set; }
        public string? NombreEspecialidad { get; set; }
        public string NombreCompleto => $"{Nombres} {Apellidos}";
    }
}