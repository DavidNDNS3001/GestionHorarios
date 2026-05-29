namespace GestionHorarios.Modelos.Entidades
{
    /// <summary>
    /// Entidad que representa un médico
    /// </summary>
    public class Medico
    {
        public int Id { get; set; }
        public string Cedula { get; set; } = string.Empty;
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string RegistroMedico { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;

        // Foreign Keys
        public int IdEspecialidad { get; set; }

        // Relaciones
        public Especialidad? Especialidad { get; set; }
        public ICollection<HorarioLlamada> HorariosLlamada { get; set; } = new List<HorarioLlamada>();
        public ICollection<IntercambioTurno> IntercambiosTurnoRealizado { get; set; } = new List<IntercambioTurno>();
        public Usuario? Usuario { get; set; }

        public string NombreCompleto => $"{Nombres} {Apellidos}";
    }
}