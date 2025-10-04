using TurnosConsultorioMedico.Models;

namespace TurnosConsultorioMedico.Dtos
{
    public class TurnoDto
    {
        public int id { get; set; }
        public string Paciente { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public List<DetalleTurnoDto> TDetallesTurnos { get; set; } = new List<DetalleTurnoDto>();
    }


}
