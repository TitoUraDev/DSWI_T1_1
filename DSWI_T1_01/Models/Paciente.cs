using System;
using System.Collections.Generic;

namespace DSWI_T1_01.Models;

public partial class Paciente
{
    public int PacienteId { get; set; }

    public string? Nombre { get; set; }

    public string? Dni { get; set; }

    public virtual ICollection<Cita> Citas { get; set; } = new List<Cita>();
}
