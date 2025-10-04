using TurnosConsultorioMedico.Dtos;
using TurnosConsultorioMedico.Models;

namespace TurnosConsultorioMedico.Services.Interfaces
{
    public interface IMedicosService
    {
        List<TMedico> GetAllMedicos();
        bool Delete(int id);

        bool Save(MedicosDto medicosDto);

        bool Update(MedicosDto medicosDto);
    }
}
