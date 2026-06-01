namespace GestionHorarios.Datos.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz para el patrón Unit of Work
    /// Centraliza la gestión de todas las transacciones de la aplicación
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Repositorio para Especialidades
        /// </summary>
        IRepository<Modelos.Entidades.Especialidad> Especialidades { get; }

        /// <summary>
        /// Repositorio para Médicos
        /// </summary>
        IRepository<Modelos.Entidades.Medico> Medicos { get; }

        /// <summary>
        /// Repositorio para Tipos de Turno
        /// </summary>
        IRepository<Modelos.Entidades.TipoTurno> TiposTurno { get; }

        /// <summary>
        /// Repositorio para Motivos de Llamada
        /// </summary>
        IRepository<Modelos.Entidades.MotivoLlamada> MotivosLlamada { get; }

        /// <summary>
        /// Repositorio para Horarios de Llamada
        /// </summary>
        IRepository<Modelos.Entidades.HorarioLlamada> HorariosLlamada { get; }

        /// <summary>
        /// Repositorio para Registros de Llamada
        /// </summary>
        IRepository<Modelos.Entidades.RegistroLlamada> RegistrosLlamada { get; }

        /// <summary>
        /// Repositorio para Intercambios de Turno
        /// </summary>
        IRepository<Modelos.Entidades.IntercambioTurno> IntercambiosTurno { get; }

        /// <summary>
        /// Repositorio para Usuarios
        /// </summary>
        IRepository<Modelos.Entidades.Usuario> Usuarios { get; }

        /// <summary>
        /// Guarda todos los cambios en la base de datos
        /// </summary>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// Inicia una transacción
        /// </summary>
        Task BeginTransactionAsync();

        /// <summary>
        /// Confirma la transacción actual
        /// </summary>
        Task CommitAsync();

        /// <summary>
        /// Revierte la transacción actual
        /// </summary>
        Task RollbackAsync();
    }
}