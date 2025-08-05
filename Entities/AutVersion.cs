using System.ComponentModel.DataAnnotations.Schema;

namespace AutosEJ.Entities
{
    [Table("AutVersion")]
    public class AutVersion
    {
        public int IdAutVersion { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Anio { get; set; }

        public int IdModelo { get; set; }
        public Modelo Modelo { get; set; }

        public ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
