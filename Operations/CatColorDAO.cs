using AutosEJ.Context;
using AutosEJ.Models.DTO;
using System.Drawing;

namespace AutosEJ.Operations
{
    public class CatColorDAO
    {

        private readonly AutosEjContext _context;

        public CatColorDAO(AutosEjContext context) 
        { 
            _context = context;
        }

        public List<CatColorDTO> AllSelects()
        {
            var listColors = _context.CatColors.Select(s => new CatColorDTO()
                                                            {
                                                                IdColor = s.IdColor,
                                                                Descripcion = s.Descripcion ?? "",
                                                                Tipo = s.Tipo ?? ""
                                                            }).ToList();

            return listColors;
        }

        public CatColorDTO GetById(int id) 
        {
            var color = _context.CatColors.Where(c => c.IdColor == id)
                                          .Select(s => new CatColorDTO() 
                                          {
                                             IdColor = s.IdColor,
                                             Descripcion = s.Descripcion ?? "",
                                             Tipo = s.Tipo ?? ""
                                          }).FirstOrDefault<CatColorDTO>();

            return color ?? new CatColorDTO();
        }

        public static string GetColorNameById(AutosEjContext context, int id) 
        {
            var color = context.CatColors.Where(c => c.IdColor == id).Select(s => s.Descripcion).SingleOrDefault();

            return color ?? string.Empty;
        }
    }
}
