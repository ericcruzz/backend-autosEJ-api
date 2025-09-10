using AutosEJ.Context;
using AutosEJ.Models.DTO;
using System.Collections;

namespace AutosEJ.Operations
{
    public class MarcaDAO : DBObject
    {
        //private readonly AutosEjContext _context;

        public MarcaDAO(AutosEjContext context) : base(context) 
        {
            //_context = context;
        }

        public override ICollection GetList()
        {
            try
            {
                var brands = context.Marcas.Select(marca => new MarcaDTO()
                {
                    IdMarca = marca.IdMarca,
                    Nombre = marca.Nombre
                }).ToList();

                return brands;
            }
            catch (Exception ex) 
            {
                return null;
            }
            
        }

        public MarcaDTO GetById(int id)
        {
            try
            {
                var brand = context.Marcas.Where(m => m.IdMarca == id)
                                      .Select(s => new MarcaDTO()
                                      {
                                          IdMarca = s.IdMarca,
                                          Nombre = s.Nombre
                                      }).FirstOrDefault();

                return brand;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetBrandNameById(AutosEjContext context, int id)
        {
            if (id == 0)
                return "";

            try
            {
                var brandName = context.Marcas.Where(m => m.IdMarca == id)
                                      .Select(s => s.Nombre).SingleOrDefault();

                return brandName ?? "";
            }
            catch (Exception ex) 
            {
                return null;
            }
        }

        //public override List<object> GetList()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
