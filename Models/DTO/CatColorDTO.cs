using AutosEJ.Models.Interfaces;

namespace AutosEJ.Models.DTO
{
    public class CatColorDTO : IDataTransferObject
    {
        public int Id { get; set; } 

        public string Descripcion { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;
    }
}
