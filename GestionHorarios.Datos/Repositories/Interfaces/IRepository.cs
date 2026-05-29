namespace GestionHorarios.Datos.Repositories.Interfaces
{
    /// <summary>
    /// Interfaz genérica para el patrón Repository
    /// Proporciona operaciones CRUD básicas para cualquier entidad
    /// </summary>
    /// <typeparam name="T">Tipo de entidad</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Obtiene una entidad por su identificador
        /// </summary>
        Task<T?> GetByIdAsync(int id);

        /// <summary>
        /// Obtiene todas las entidades
        /// </summary>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Añade una nueva entidad
        /// </summary>
        Task AddAsync(T entity);

        /// <summary>
        /// Añade múltiples entidades
        /// </summary>
        Task AddRangeAsync(IEnumerable<T> entities);

        /// <summary>
        /// Actualiza una entidad
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// Elimina una entidad
        /// </summary>
        void Delete(T entity);

        /// <summary>
        /// Elimina múltiples entidades
        /// </summary>
        void DeleteRange(IEnumerable<T> entities);

        /// <summary>
        /// Obtiene entidades según una condición
        /// </summary>
        Task<IEnumerable<T>> FindAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Obtiene la primera entidad que cumple una condición
        /// </summary>
        Task<T?> FindFirstAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Cuenta todas las entidades
        /// </summary>
        Task<int> CountAsync();

        /// <summary>
        /// Cuenta entidades que cumplen una condición
        /// </summary>
        Task<int> CountAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);

        /// <summary>
        /// Comprueba si existe alguna entidad que cumple una condición
        /// </summary>
        Task<bool> AnyAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate);
    }
}