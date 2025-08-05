namespace AutosEJ.Entities
{
    public class Modelo
    {
        public int IdModelo { get; set; }
        public string Nombre { get; set; }

        public int IdMarca { get; set; }
        public Marca Marca { get; set; }

        public ICollection<AutVersion> AutVersions { get; set; }
    }
}
