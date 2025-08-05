namespace AutosEJ.Entities
{
    public class Vehiculo
    {
        public int IdVehidulo { get; set; }
        public string Serie { get; set; }
        public string NIV { get; set; }
        public string Placa { get; set; }
        public string Motor {  get; set; }

        public int IdAutVersion { get; set; }
        public AutVersion AutVersion { get; set; }
        public int IdColorExterior { get; set; }
        public CatColor ColorExterior { get; set; }
        public int IdColorInterior { get; set; }
        public CatColor ColorInterior { get; set; }

    }
}
