using TurnosConsultorioMedico.Models;

namespace TurnosConsultorioMedico.Repositories.Interfaces
{
    public interface IMedicosRepository
    {
        List<TMedico> GetAllMedicos();
        bool Delete(int id);

        bool Save(TMedico medico);
        bool Update(TMedico medico);
        TMedico? GetById(int id);
    }
}
