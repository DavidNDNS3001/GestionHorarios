using AutoMapper;
using GestionHorarios.Datos.Repositories.Interfaces;
using GestionHorarios.Modelos.Entidades;
using GestionHorarios.Servicios.DTOs;
using GestionHorarios.Servicios.Interfaces;

namespace GestionHorarios.Servicios.Implementacion
{
    /// <summary>
    /// Servicio para operaciones de Registros de Llamada
    /// </summary>
    public class RegistroLlamadaService : IRegistroLlamadaService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegistroLlamadaService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RegistroLlamadaDTO>> GetAllAsync()
        {
            var registros = await _unitOfWork.RegistrosLlamada.GetAllAsync();
            return _mapper.Map<IEnumerable<RegistroLlamadaDTO>>(registros);
        }

        public async Task<RegistroLlamadaDTO?> GetByIdAsync(int id)
        {
            var registro = await _unitOfWork.RegistrosLlamada.GetByIdAsync(id);
            return registro == null ? null : _mapper.Map<RegistroLlamadaDTO>(registro);
        }

        public async Task<IEnumerable<RegistroLlamadaDTO>> GetByHorarioAsync(int idHorario)
        {
            var registros = await _unitOfWork.RegistrosLlamada.FindAsync(r => r.IdHorario == idHorario);
            return _mapper.Map<IEnumerable<RegistroLlamadaDTO>>(registros);
        }

        public async Task<int> CreateAsync(RegistroLlamadaDTO registroDTO)
        {
            var registro = _mapper.Map<RegistroLlamada>(registroDTO);
            await _unitOfWork.RegistrosLlamada.AddAsync(registro);
            await _unitOfWork.SaveChangesAsync();
            return registro.Id;
        }

        public async Task UpdateAsync(RegistroLlamadaDTO registroDTO)
        {
            var registro = _mapper.Map<RegistroLlamada>(registroDTO);
            _unitOfWork.RegistrosLlamada.Update(registro);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var registro = await _unitOfWork.RegistrosLlamada.GetByIdAsync(id);
            if (registro != null)
            {
                _unitOfWork.RegistrosLlamada.Delete(registro);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}