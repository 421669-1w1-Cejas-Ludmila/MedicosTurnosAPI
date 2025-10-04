using TurnosConsultorioMedico.Dtos;
using TurnosConsultorioMedico.Models;

namespace TurnosConsultorioMedico.Services.Interfaces
{
    public interface ITurnoService
    {      
        bool Save(TurnoDto turnoDTO);
        List<TTurno> GetTurnos(string? fecha, string? hora, int? matricula);
        bool Delete (int id);
        bool Update (TurnoDto turnoDto);
    }
}
