namespace AutosEJ.Models.DTO
{
    public class ModeloDTO
    {
        public int IdModelo { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public MarcaDTO? Marca { get; set; }
    }
}
