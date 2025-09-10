namespace AutosEJ.Models.DTO
{
    public class AutVersionDTO
    {
        public int IdAutVersion { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Anio { get; set; } = string.Empty;
        public ModeloDTO? Modelo { get; set; }
    }
}
