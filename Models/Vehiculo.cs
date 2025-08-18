using System;
using System.Collections.Generic;

namespace AutosEJ.Models;

public partial class Vehiculo
{
    public int IdVehiculo { get; set; }

    public string? Serie { get; set; }

    public string? Niv { get; set; }

    public string? Placa { get; set; }

    public string? Motor { get; set; }

    public int IdAutVersion { get; set; }

    public int? IdColorExterior { get; set; }

    public int? IdColorInterior { get; set; }

    public virtual AutVersion IdAutVersionNavigation { get; set; } = null!;

    public virtual CatColor? IdColorExteriorNavigation { get; set; }

    public virtual CatColor? IdColorInteriorNavigation { get; set; }
}
