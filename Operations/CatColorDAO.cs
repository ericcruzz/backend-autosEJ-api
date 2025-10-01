using AutosEJ.Context;
using AutosEJ.Models.DTO;
using AutosEJ.Models.Repository;

namespace AutosEJ.Operations
{
    public class CatColorDAO : RepositorioBase
    {

        public CatColorDAO(AutosEjContext context) : base(context) {  }

        public override List<CatColorDTO> ObtenerLista()
        {
            try
            {
                var listColors = _context.CatColors.Select(s => new CatColorDTO()
                {
                    Id = s.IdColor,
                    Descripcion = s.Descripcion ?? "",
                    Tipo = s.Tipo ?? ""
                }).ToList();

                return listColors;
            }
            catch  
            {
                return new List<CatColorDTO>();
            }
        }

        public override CatColorDTO BuscarPorId(int id) 
        {
            try
            {
                var colorBuscado = _context.CatColors.Where(c => c.IdColor == id)
                                          .Select(s => new CatColorDTO()
                                          {
                                              Id = s.IdColor,
                                              Descripcion = s.Descripcion ?? "",
                                              Tipo = s.Tipo ?? ""
                                          }).FirstOrDefault();

                CatColorDTO color = colorBuscado != null ? colorBuscado : new CatColorDTO();

                return color;
            }
            catch 
            {
                return new CatColorDTO();
            }
            
        }

        public static string GetColorNameById(AutosEjContext context, int id) 
        {
            if (id == 0)
                return "";

            try
            {
                var color = context.CatColors.Where(c => c.IdColor == id).Select(s => s.Descripcion).SingleOrDefault();

                return color ?? "";
            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}
