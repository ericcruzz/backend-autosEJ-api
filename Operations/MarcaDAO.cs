using AutosEJ.Context;
using AutosEJ.Models.DTO;
using AutosEJ.Models.Interfaces;
using AutosEJ.Models.Repository;
using System.Collections;

namespace AutosEJ.Operations
{
    public class MarcaDAO : RepositorioBase
    {
        public MarcaDAO(AutosEjContext context) : base(context) { }

        public override List<MarcaDTO> ObtenerLista()
        {
            List<MarcaDTO> listaMarcas = _context.Marcas.Select(marca => new MarcaDTO()
                                                        {
                                                            Id = marca.IdMarca,
                                                            Nombre = marca.Nombre ?? ""
                                                        }).ToList();

            return listaMarcas;            
        }

        public override MarcaDTO BuscarPorId(int id)
        {
            var objetoBuscado = _context.Marcas.Where(m => m.IdMarca == id)
                                                .Select(s => new MarcaDTO()
                                                {
                                                    Id = s.IdMarca,
                                                    Nombre = s.Nombre ?? ""
                                                }).SingleOrDefault();

            MarcaDTO marca = objetoBuscado != null ? objetoBuscado : new MarcaDTO();

            return marca;

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

    }
}
