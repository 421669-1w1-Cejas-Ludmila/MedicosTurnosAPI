using Microsoft.AspNetCore.Identity;
using TurnosConsultorioMedico.Dtos;
using TurnosConsultorioMedico.Models;
using TurnosConsultorioMedico.Repositories.Interfaces;
using TurnosConsultorioMedico.Services.Interfaces;

namespace TurnosConsultorioMedico.Services.Implementations
{
    public class MedicosService : IMedicosService
    {
        private readonly IMedicosRepository _medicosRepository;
        public MedicosService(IMedicosRepository medicosRepository)
        {
            _medicosRepository = medicosRepository;
        }

        public bool Delete(int id)
        {
            return _medicosRepository.Delete(id);
        }

        public List<TMedico> GetAllMedicos()
        {
            return _medicosRepository.GetAllMedicos();
        }

        public bool Save(MedicosDto medicosDto)
        {
            var medico = new TMedico
            {
                Matricula = medicosDto.Matricula, // si no es identity
                Nombre = medicosDto.Nombre,
                Apellido = medicosDto.Apellido,
                Especialidad = medicosDto.Especialidad
            };
            return _medicosRepository.Save(medico);
        }

        public bool Update(MedicosDto medicosDto)
        {
            var medico = new TMedico
            {
                Matricula = medicosDto.Matricula, // importante!!
                Nombre = medicosDto.Nombre,
                Apellido = medicosDto.Apellido,
                Especialidad = medicosDto.Especialidad
            };
            return _medicosRepository.Update(medico);
        }

    }
}
