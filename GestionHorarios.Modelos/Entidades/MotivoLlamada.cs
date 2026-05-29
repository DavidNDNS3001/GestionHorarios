namespace GestionHorarios.Modelos.Entidades
{
    /// <summary>
    /// Entidad que representa un motivo de llamada
    /// </summary>
    public class MotivoLlamada
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public bool Activo { get; set; } = true;

        // Relaciones
        public ICollection<RegistroLlamada> RegistrosLlamada { get; set; } = new List<RegistroLlamada>();
    }
}