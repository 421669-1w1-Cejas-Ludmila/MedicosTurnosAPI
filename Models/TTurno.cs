using System;
using System.Collections.Generic;

namespace TurnosConsultorioMedico.Models;

public partial class TTurno
{
    // GENERADO POR ENTITY FRAMEWORK CORE SCAFFOLD
    public int Id { get; set; }

    public string Paciente { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<TDetallesTurno> TDetallesTurnos { get; set; } = new List<TDetallesTurno>();
}
