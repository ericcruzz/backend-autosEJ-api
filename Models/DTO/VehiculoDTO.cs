namespace AutosEJ.Models.DTO
{
    public class VehiculoDTO
    {
        public int IdVehiculo { get; set; }

        public string? Serie { get; set; }

        public string? Niv { get; set; }

        public string? Placa { get; set; }

        public string? Motor { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Version { get; set; }
        public string Anio { get; set; }

        public string ColorExterior { get; set; }

        public string ColorInterior { get; set; }
    }
}
