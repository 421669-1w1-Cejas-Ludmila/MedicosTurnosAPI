using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurnosConsultorioMedico.Dtos;
using TurnosConsultorioMedico.Models;
using TurnosConsultorioMedico.Services.Interfaces;

namespace TurnosConsultorioMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnosController : ControllerBase
    {
        private readonly ITurnoService _turnoService;

        public TurnosController(ITurnoService turnoService)
        {
            _turnoService = turnoService;
        }

        [HttpGet("turnos")]
        public IActionResult GetTurnos([FromQuery] string? fecha, [FromQuery] string? hora, [FromQuery] int? matricula)
        {
            var turnos = _turnoService.GetTurnos(fecha, hora, matricula);
            return Ok(turnos);
        }

        [HttpGet("turnos/count")]
        public IActionResult GetCantidadTurnos([FromQuery] int matricula, [FromQuery] string fecha, [FromQuery] string hora)
        {
            var turnos = _turnoService.GetTurnos(fecha, hora, matricula);
            return Ok(new { cantidad = turnos.Count });
        }

        [HttpPost]
        public IActionResult SaveTurno(TurnoDto turno)
        {
            try
            {
                var result = _turnoService.Save(turno);
                return Ok("Turno agendado correctamente");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message); // 409 Conflicto
            }
        }

        [HttpDelete]
        public IActionResult DeleteTurno(int id)
        {
            var eliminado = _turnoService.Delete(id);
            if (eliminado)
                return Ok(new { message = "Turno eliminado correctamente" });
            else
                return NotFound(new { message = "No se encontró el turno para eliminar" });
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTurno(int id, [FromBody] TurnoDto turnoDto)
        {
            var actualizado = _turnoService.Update(turnoDto);
            if (actualizado)
                return Ok(new { message = "Turno actualizado correctamente" });
            else
                return NotFound(new { message = "No se encontró el turno para actualizar" });
        }


    }
}
