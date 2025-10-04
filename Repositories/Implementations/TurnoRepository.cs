using Microsoft.EntityFrameworkCore;
using TurnosConsultorioMedico.Dtos;
using TurnosConsultorioMedico.Models;
using TurnosConsultorioMedico.Repositories.Interfaces;

namespace TurnosConsultorioMedico.Repositories.Implementations
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly TurnosContext _context;

        public TurnoRepository(TurnosContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            // Buscar el turno por ID incluyendo los detalles
            var turno = _context.TTurnos
                .Include(t => t.TDetallesTurnos)
                .FirstOrDefault(t => t.Id == id);

            if (turno == null)
                return false;

            // Eliminar los detalles asociados
            _context.TDetallesTurnos.RemoveRange(turno.TDetallesTurnos);

            // Eliminar el turno principal
            _context.TTurnos.Remove(turno);

            // Guardar cambios
            return _context.SaveChanges() > 0;
        }

        public List<TTurno> GetTurnos(string? fecha, string? hora, int? matricula)
        {
            return _context.TTurnos
                .Include(t => t.TDetallesTurnos)
                .Where(t => (fecha == null || t.TDetallesTurnos.Any(d => d.Fecha == fecha)) &&
                            (hora == null || t.TDetallesTurnos.Any(d => d.Hora == hora)) &&
                            (matricula == null || t.TDetallesTurnos.Any(d => d.Matricula == matricula)))
                .ToList();
        }

        public bool Save(TTurno turno)
        {
            _context.TTurnos.Add(turno);
            return _context.SaveChanges() > 0;
        }

        public TTurno GetById(int id)
        {
            return _context.TTurnos
                .Include(t => t.TDetallesTurnos) // cargar detalles
                .FirstOrDefault(t => t.Id == id);
        }
        public bool Update(TTurno turno)
        {
            _context.TTurnos.Update(turno);
            return _context.SaveChanges() > 0;
        }
    }
}
