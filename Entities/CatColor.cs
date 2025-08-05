namespace AutosEJ.Entities
{
    public class CatColor
    {
        public int IdColor { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }

        public ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
