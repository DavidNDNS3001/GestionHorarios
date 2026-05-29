using Microsoft.AspNetCore.Identity;

namespace GestionHorarios.Modelos.Entidades
{
    /// <summary>
    /// Entidad que representa un usuario del sistema
    /// Extiende IdentityUser de ASP.NET Core Identity
    /// </summary>
    public class Usuario : IdentityUser<int>
    {
        public bool Activo { get; set; } = true;
        public int? IdMedico { get; set; }

        // Relaciones
        public Medico? Medico { get; set; }
        public ICollection<HorarioLlamada> HorariosCreados { get; set; } = new List<HorarioLlamada>();
        public ICollection<RegistroLlamada> RegistrosCreadosPor { get; set; } = new List<RegistroLlamada>();
        public ICollection<IntercambioTurno> IntercambiosAprobados { get; set; } = new List<IntercambioTurno>();
    }
}