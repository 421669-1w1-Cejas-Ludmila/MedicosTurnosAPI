using System;
using System.Collections.Generic;

namespace TurnosConsultorioMedico.Models;

public partial class TDetallesTurno
{
    // GENERADO POR ENTITY FRAMEWORK CORE SCAFFOLD
    public int IdTurno { get; set; }

    public int Matricula { get; set; }

    public string? MotivoConsulta { get; set; }

    public string Fecha { get; set; } = null!;

    public string Hora { get; set; } = null!;

    public virtual TTurno IdTurnoNavigation { get; set; } = null!;

    public virtual TMedico MatriculaNavigation { get; set; } = null!;
}
