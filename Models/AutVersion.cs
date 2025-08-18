using System;
using System.Collections.Generic;

namespace AutosEJ.Models;

public partial class AutVersion
{
    public int IdAutVersion { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public string? Anio { get; set; }

    public int IdModelo { get; set; }

    public virtual Modelo IdModeloNavigation { get; set; } = null!;

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
