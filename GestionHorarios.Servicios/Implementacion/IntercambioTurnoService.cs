using AutoMapper;
using GestionHorarios.Datos.Repositories.Interfaces;
using GestionHorarios.Modelos.Entidades;
using GestionHorarios.Servicios.DTOs;
using GestionHorarios.Servicios.Interfaces;

namespace GestionHorarios.Servicios.Implementacion
{
    /// <summary>
    /// Servicio para operaciones de Intercambio de Turno
    /// </summary>
    public class IntercambioTurnoService : IIntercambioTurnoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public IntercambioTurnoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IntercambioTurnoDTO>> GetAllAsync()
        {
            var intercambios = await _unitOfWork.IntercambiosTurno.GetAllAsync();
            return _mapper.Map<IEnumerable<IntercambioTurnoDTO>>(intercambios);
        }

        public async Task<IntercambioTurnoDTO?> GetByIdAsync(int id)
        {
            var intercambio = await _unitOfWork.IntercambiosTurno.GetByIdAsync(id);
            return intercambio == null ? null : _mapper.Map<IntercambioTurnoDTO>(intercambio);
        }

        public async Task<IEnumerable<IntercambioTurnoDTO>> GetPendientesAsync()
        {
            var intercambios = await _unitOfWork.IntercambiosTurno.FindAsync(i => i.Estado == EstadoIntercambio.Pendiente);
            return _mapper.Map<IEnumerable<IntercambioTurnoDTO>>(intercambios);
        }

        public async Task<int> SolicitarIntercambioAsync(IntercambioTurnoDTO intercambioDTO)
        {
            var intercambio = _mapper.Map<IntercambioTurno>(intercambioDTO);
            intercambio.Estado = EstadoIntercambio.Pendiente;
            intercambio.FechaSolicitud = DateTime.UtcNow;
            await _unitOfWork.IntercambiosTurno.AddAsync(intercambio);
            await _unitOfWork.SaveChangesAsync();
            return intercambio.Id;
        }

        public async Task AprobarIntercambioAsync(int id, int usuarioAprobadorId)
        {
            var intercambio = await _unitOfWork.IntercambiosTurno.GetByIdAsync(id);
            if (intercambio != null && intercambio.Estado == EstadoIntercambio.Pendiente)
            {
                intercambio.Estado = EstadoIntercambio.Aprobado;
                intercambio.AprobadoPor = usuarioAprobadorId;
                _unitOfWork.IntercambiosTurno.Update(intercambio);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task RechazarIntercambioAsync(int id)
        {
            var intercambio = await _unitOfWork.IntercambiosTurno.GetByIdAsync(id);
            if (intercambio != null && intercambio.Estado == EstadoIntercambio.Pendiente)
            {
                intercambio.Estado = EstadoIntercambio.Rechazado;
                _unitOfWork.IntercambiosTurno.Update(intercambio);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var intercambio = await _unitOfWork.IntercambiosTurno.GetByIdAsync(id);
            if (intercambio != null)
            {
                _unitOfWork.IntercambiosTurno.Delete(intercambio);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}