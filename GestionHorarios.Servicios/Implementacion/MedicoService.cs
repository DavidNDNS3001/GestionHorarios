using AutoMapper;
using GestionHorarios.Datos.Repositories.Interfaces;
using GestionHorarios.Modelos.Entidades;
using GestionHorarios.Servicios.DTOs;
using GestionHorarios.Servicios.Interfaces;

namespace GestionHorarios.Servicios.Implementacion
{
    /// <summary>
    /// Servicio para operaciones de Médicos
    /// </summary>
    public class MedicoService : IMedicoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MedicoDTO>> GetAllAsync()
        {
            var medicos = await _unitOfWork.Medicos.GetAllAsync();
            return _mapper.Map<IEnumerable<MedicoDTO>>(medicos);
        }

        public async Task<MedicoDTO?> GetByIdAsync(int id)
        {
            var medico = await _unitOfWork.Medicos.GetByIdAsync(id);
            return medico == null ? null : _mapper.Map<MedicoDTO>(medico);
        }

        public async Task<MedicoDTO?> GetByCedulaAsync(string cedula)
        {
            var medico = await _unitOfWork.Medicos.FindFirstAsync(m => m.Cedula == cedula);
            return medico == null ? null : _mapper.Map<MedicoDTO>(medico);
        }

        public async Task<IEnumerable<MedicoDTO>> GetByEspecialidadAsync(int idEspecialidad)
        {
            var medicos = await _unitOfWork.Medicos.FindAsync(m => m.IdEspecialidad == idEspecialidad && m.Activo);
            return _mapper.Map<IEnumerable<MedicoDTO>>(medicos);
        }

        public async Task<int> CreateAsync(MedicoDTO medicoDTO)
        {
            var medico = _mapper.Map<Medico>(medicoDTO);
            await _unitOfWork.Medicos.AddAsync(medico);
            await _unitOfWork.SaveChangesAsync();
            return medico.Id;
        }

        public async Task UpdateAsync(MedicoDTO medicoDTO)
        {
            var medico = _mapper.Map<Medico>(medicoDTO);
            _unitOfWork.Medicos.Update(medico);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var medico = await _unitOfWork.Medicos.GetByIdAsync(id);
            if (medico != null)
            {
                _unitOfWork.Medicos.Delete(medico);
                await _unitOfWork.SaveChangesAsync();
            }
        }
    }
}