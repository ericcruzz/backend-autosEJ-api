using AutosEJ.Context;
using AutosEJ.Models.DTO;

namespace AutosEJ.Operations
{
    public class CatColorDAO
    {

        private readonly AutosEjContext _context;

        public CatColorDAO(AutosEjContext context) 
        { 
            _context = context;
        }

        public List<CatColorDTO> GetList()
        {
            try
            {
                var listColors = _context.CatColors.Select(s => new CatColorDTO()
                {
                    IdColor = s.IdColor,
                    Descripcion = s.Descripcion ?? "",
                    Tipo = s.Tipo ?? ""
                }).ToList();

                return listColors;
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        public CatColorDTO GetById(int id) 
        {
            try
            {
                var color = _context.CatColors.Where(c => c.IdColor == id)
                                          .Select(s => new CatColorDTO()
                                          {
                                              IdColor = s.IdColor,
                                              Descripcion = s.Descripcion ?? "",
                                              Tipo = s.Tipo ?? ""
                                          }).FirstOrDefault();

                return color ?? new CatColorDTO();
            }
            catch (Exception ex)
            {
                return null;
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
