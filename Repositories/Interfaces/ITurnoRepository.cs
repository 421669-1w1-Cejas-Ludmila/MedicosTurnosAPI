using TurnosConsultorioMedico.Dtos;
using TurnosConsultorioMedico.Models;

namespace TurnosConsultorioMedico.Repositories.Interfaces
{
    public interface ITurnoRepository
    {
       
        bool Save(TTurno turno);
        List<TTurno> GetTurnos(string? fecha, string? hora, int?matricula);
         bool Delete(int id);
        bool Update (TTurno turno);

       TTurno? GetById(int id);
    }
}
