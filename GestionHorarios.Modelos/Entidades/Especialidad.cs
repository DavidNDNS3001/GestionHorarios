namespace GestionHorarios.Modelos.Entidades
{
    /// <summary>
    /// Entidad que representa una especialidad médica
    /// </summary>
    public class Especialidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;

        // Relaciones
        public ICollection<Medico> Medicos { get; set; } = new List<Medico>();
    }
}