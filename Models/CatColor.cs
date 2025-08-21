using System;
using System.Collections.Generic;

namespace AutosEJ.Models;

public partial class CatColor
{
    public int IdColor { get; set; }

    public string? Descripcion { get; set; }

    public string? Tipo { get; set; }

    public virtual ICollection<Vehiculo> VehiculoIdColorExteriorNavigations { get; set; } = new List<Vehiculo>();

    public virtual ICollection<Vehiculo> VehiculoIdColorInteriorNavigations { get; set; } = new List<Vehiculo>();
}
