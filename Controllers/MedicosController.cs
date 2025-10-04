using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TurnosConsultorioMedico.Dtos;
using TurnosConsultorioMedico.Models;
using TurnosConsultorioMedico.Services.Interfaces;

namespace TurnosConsultorioMedico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        private readonly IMedicosService _medicosService;

        public MedicosController(IMedicosService medicosService)
        {
            _medicosService = medicosService;
        }

        [HttpGet("medicos")]
        public IActionResult GetAllMedicos()
        {
            var medicos = _medicosService.GetAllMedicos();
            return Ok(medicos);
        }

        [HttpPost]
        public IActionResult PostMedico([FromBody] MedicosDto medico)
        {
            var resultado = _medicosService.Save(medico);
            if (resultado)
                return Ok(new { message = "Médico agregado correctamente" });
            else
                return BadRequest(new { message = "No se pudo agregar el médico" });
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] MedicosDto medicoDto)
        {
            if (id != medicoDto.Matricula)
                return BadRequest("El id de la URL no coincide con el del cuerpo");

            var actualizado = _medicosService.Update(medicoDto);
            if (!actualizado)
                return NotFound("No se encontró el médico a actualizar");

            return Ok("Médico actualizado correctamente");
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteMedico(int id)
        {
            var eliminado = _medicosService.Delete(id);
            if (eliminado)
                return Ok(new { message = "Médico eliminado correctamente" });
            else
                return NotFound(new { message = "No se encontró el médico para eliminar" });
        }
    }
}
