using Microsoft.EntityFrameworkCore;
using TurnosConsultorioMedico.Dtos;
using TurnosConsultorioMedico.Models;
using TurnosConsultorioMedico.Repositories.Interfaces;
using TurnosConsultorioMedico.Services.Interfaces;

namespace TurnosConsultorioMedico.Services.Implementations
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _turnoRepository;
        public TurnoService(ITurnoRepository turnoRepository)
        {
            _turnoRepository = turnoRepository;
        }

        public bool Delete(int id)
        {
            return _turnoRepository.Delete(id);
        }

        public List<TTurno> GetTurnos(string? fecha, string? hora, int? matricula)
        {
            return _turnoRepository.GetTurnos(fecha, hora, matricula);
        }

        public bool Save(TurnoDto turnoDto)
        {
            // Validaciones previas
            if (string.IsNullOrWhiteSpace(turnoDto.Paciente))
                throw new ArgumentException("El campo paciente no puede estar vacío");
            if (turnoDto.TDetallesTurnos == null || !turnoDto.TDetallesTurnos.Any())
                throw new ArgumentException("El turno debe contener al menos un detalle");
            if (string.IsNullOrWhiteSpace(turnoDto.Estado))
                throw new ArgumentException("El campo estado es requerido");

            // Validar que no se repita el mismo médico en el mismo turno
            var duplicados = turnoDto.TDetallesTurnos
                .GroupBy(d => new { d.Matricula, d.Fecha, d.Hora })
                .Where(g => g.Count() > 1)
                .ToList();
            if (duplicados.Any())
                throw new ArgumentException("No se puede asignar el mismo médico en la misma fecha y hora dentro del turno");

            // Validar que el médico no tenga ya ocupado ese horario en la BD
            foreach (var detalle in turnoDto.TDetallesTurnos)
            {
                var existe = _turnoRepository
                    .GetTurnos(detalle.Fecha, detalle.Hora, detalle.Matricula)
                    .Any(); // suponiendo que GetTurnos devuelve lista

                if (existe)
                    throw new InvalidOperationException(
                        $"Ya existe un turno para el médico {detalle.Matricula} en la fecha {detalle.Fecha} a las {detalle.Hora}"
                    );
            }

            // Mapear a la entidad
            var turno = new TTurno
            {
                Paciente = turnoDto.Paciente,
                Estado = turnoDto.Estado,
                TDetallesTurnos = turnoDto.TDetallesTurnos.Select(d => new TDetallesTurno
                {
                    Matricula = d.Matricula,
                    MotivoConsulta = d.MotivoConsulta,
                    Fecha = d.Fecha,
                    Hora = d.Hora
                }).ToList()
            };

            // Guardar en el repositorio
            return _turnoRepository.Save(turno);

        }

        public bool Update(TurnoDto turnoDto)
        {
            // 1. Traer el turno existente
            var turnoExistente = _turnoRepository.GetById(turnoDto.id);
            if (turnoExistente == null)
                return false;

            // 2. Actualizar campos principales
            turnoExistente.Paciente = turnoDto.Paciente;
            turnoExistente.Estado = turnoDto.Estado;

            // 3. Actualizar detalles
            turnoExistente.TDetallesTurnos = turnoDto.TDetallesTurnos.Select(d => new TDetallesTurno
            {
                Matricula = d.Matricula,
                MotivoConsulta = d.MotivoConsulta,
                Fecha = d.Fecha,
                Hora = d.Hora
            }).ToList();

            // 4. Guardar cambios usando el repositorio
            return _turnoRepository.Update(turnoExistente);
        }
    }

}


