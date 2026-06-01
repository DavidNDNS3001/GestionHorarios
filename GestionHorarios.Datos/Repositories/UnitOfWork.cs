using GestionHorarios.Datos.Context;
using GestionHorarios.Datos.Repositories.Interfaces;
using GestionHorarios.Modelos.Entidades;

namespace GestionHorarios.Datos.Repositories
{
    /// <summary>
    /// Implementación del patrón Unit of Work
    /// Centraliza la gestión de todas las transacciones de la aplicación
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GestionHorariosContext _context;
        private IRepository<Especialidad>? _especialidades;
        private IRepository<Medico>? _medicos;
        private IRepository<TipoTurno>? _tiposTurno;
        private IRepository<MotivoLlamada>? _motivosLlamada;
        private IRepository<HorarioLlamada>? _horariosLlamada;
        private IRepository<RegistroLlamada>? _registrosLlamada;
        private IRepository<IntercambioTurno>? _intercambiosTurno;
        private IRepository<Usuario>? _usuarios;

        public UnitOfWork(GestionHorariosContext context)
        {
            _context = context;
        }

        public IRepository<Especialidad> Especialidades
        {
            get { return _especialidades ??= new Repository<Especialidad>(_context); }
        }

        public IRepository<Medico> Medicos
        {
            get { return _medicos ??= new Repository<Medico>(_context); }
        }

        public IRepository<TipoTurno> TiposTurno
        {
            get { return _tiposTurno ??= new Repository<TipoTurno>(_context); }
        }

        public IRepository<MotivoLlamada> MotivosLlamada
        {
            get { return _motivosLlamada ??= new Repository<MotivoLlamada>(_context); }
        }

        public IRepository<HorarioLlamada> HorariosLlamada
        {
            get { return _horariosLlamada ??= new Repository<HorarioLlamada>(_context); }
        }

        public IRepository<RegistroLlamada> RegistrosLlamada
        {
            get { return _registrosLlamada ??= new Repository<RegistroLlamada>(_context); }
        }

        public IRepository<IntercambioTurno> IntercambiosTurno
        {
            get { return _intercambiosTurno ??= new Repository<IntercambioTurno>(_context); }
        }

        public IRepository<Usuario> Usuarios
        {
            get { return _usuarios ??= new Repository<Usuario>(_context); }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                await _context.Database.CommitTransactionAsync();
            }
            catch
            {
                await _context.Database.RollbackTransactionAsync();
                throw;
            }
        }

        public async Task RollbackAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}