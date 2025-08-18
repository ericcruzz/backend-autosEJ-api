using System;
using System.Collections.Generic;

namespace AutosEJ.Models;

public partial class Marca
{
    public int IdMarca { get; set; }

    public string? Nombre { get; set; }

    public string? Abreviatura { get; set; }

    public virtual ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
}
