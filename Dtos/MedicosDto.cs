namespace TurnosConsultorioMedico.Dtos
{
    public class MedicosDto
    {
        public int Matricula { get; set; }
        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Especialidad { get; set; } = null!;
    }
}
