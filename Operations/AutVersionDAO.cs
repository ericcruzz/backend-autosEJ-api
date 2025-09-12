using AutosEJ.Context;
using AutosEJ.Models.DTO;

namespace AutosEJ.Operations
{
    public class AutVersionDAO
    {
        private readonly AutosEjContext _context;

        public AutVersionDAO (AutosEjContext context)
        {
            _context = context;
        }

        //public List<AutVersionDTO> ObtenerLista()
        //{
        //    try
        //    {
        //        var query = _context.AutVersions.ToList();

        //        List<AutVersionDTO> lista = new List<AutVersionDTO>();

        //        foreach (var item in query) 
        //        { 
        //            AutVersionDTO version = new AutVersionDTO();
        //            version.IdAutVersion = item.IdAutVersion;
        //            version.Nombre = item.Nombre;
        //            version.Descripcion = item.Descripcion;
        //            version.Anio = item.Anio;
        //            version.Modelo = 
        //            lista.Add(version);
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return new List<AutVersionDTO> ();
        //    }
        //}
    }
}
