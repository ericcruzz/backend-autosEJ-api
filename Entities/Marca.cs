namespace AutosEJ.Entities
{
    public class Marca
    {
        public int IdMarca { get; set; }
        public string Nombre { get; set; }
        public string Abreviatura { get; set; }
        
        public virtual ICollection<Modelo> Modelos { get; set; }
    }
}
