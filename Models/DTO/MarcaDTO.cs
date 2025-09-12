using AutosEJ.Models.Interfaces;

namespace AutosEJ.Models.DTO
{
    public class MarcaDTO : IDataTransferObject
    {
        public int Id { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
    }
}
