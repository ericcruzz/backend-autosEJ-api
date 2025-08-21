using System;
using System.Collections.Generic;

namespace AutosEJ.Models;

public partial class Modelo
{
    public int IdModelo { get; set; }

    public string? Nombre { get; set; }

    public int IdMarca { get; set; }

    public virtual ICollection<AutVersion> AutVersions { get; set; } = new List<AutVersion>();

    public virtual Marca IdMarcaNavigation { get; set; } = null!;
}
