using Microsoft.EntityFrameworkCore;
using TurnosConsultorioMedico.Models;
using TurnosConsultorioMedico.Repositories.Interfaces;

namespace TurnosConsultorioMedico.Repositories.Implementations
{
    public class MedicosRepository : IMedicosRepository
    {

        private readonly TurnosContext _context;

        public MedicosRepository(TurnosContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var medico = _context.TMedicos.Find(id);
            if (medico != null)
            {
                _context.TMedicos.Remove(medico);
                return _context.SaveChanges() > 0;
            }
            return false;
        }

        public List<TMedico> GetAllMedicos()
        {
            return _context.TMedicos.ToList();
        }

        public bool Save(TMedico medico)
        {
            _context.TMedicos.Add(medico);
            return _context.SaveChanges() > 0;
        }

        public bool Update(TMedico medico)
        {
            var existente = GetById(medico.Matricula);
            if (existente == null) // si no existe
                return false;

            // Actualizar campos
            existente.Nombre = medico.Nombre;
            existente.Apellido = medico.Apellido;
            existente.Especialidad = medico.Especialidad;

            _context.TMedicos.Update(existente);
            return _context.SaveChanges() > 0;
        }


        public TMedico? GetById(int id)
        {
            return _context.TMedicos.Find(id);
        }
    }
}
