using System;
using System.Collections.Generic;

namespace TurnosConsultorioMedico.Models;

public partial class TMedico
{
    // GENERADO POR ENTITY FRAMEWORK CORE SCAFFOLD
    public int Matricula { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Especialidad { get; set; } = null!;

    public virtual ICollection<TDetallesTurno> TDetallesTurnos { get; set; } = new List<TDetallesTurno>();
}
