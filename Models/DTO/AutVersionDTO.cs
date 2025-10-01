using AutosEJ.Models.Interfaces;

namespace AutosEJ.Models.DTO
{
    public class AutVersionDTO : IDataTransferObject
    {
        public int Id { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public string Anio { get; set; } = string.Empty;
        public ModeloDTO? Modelo { get; set; }
    }
}
