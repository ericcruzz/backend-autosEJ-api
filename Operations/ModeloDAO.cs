using AutosEJ.Context;
using AutosEJ.Models.DTO;
using AutosEJ.Models.Interfaces;
using AutosEJ.Models.Repository;

namespace AutosEJ.Operations
{
    public class ModeloDAO : RepositorioBase
    {
        public ModeloDAO(AutosEjContext context) : base(context) { }

        public override List<ModeloDTO> ObtenerLista() 
        { 
            List<ModeloDTO> listaModelos = _context.Modelos
                                                   .GroupJoin(_context.Marcas, 
                                                         modelo => modelo.IdMarca, 
                                                         marca => marca.IdMarca,
                                                         (modelo,marcas) => new {modelo, marcas})
                                                   .SelectMany(x => x.marcas.DefaultIfEmpty(),
                                                         (x, marca) =>new ModeloDTO
                                                         {
                                                             Id = x.modelo.IdModelo,
                                                             Nombre = x.modelo.Nombre ?? "",
                                                             Marca = new MarcaDTO { Id = marca != null ? marca.IdMarca : 0, 
                                                                                    Nombre = marca.Nombre ?? ""}
                                                         }).ToList();

            return listaModelos;
        }

        public override ModeloDTO BuscarPorId(int id)
        {
            var modeloBuscado = _context.Modelos
                                        .Where(m => m.IdModelo == id)
                                        .GroupJoin(_context.Marcas,
                                                modelo => modelo.IdMarca,
                                                marca => marca.IdMarca,
                                                (modelo, marcas) => new { modelo, marcas })
                                        .SelectMany(x => x.marcas.DefaultIfEmpty(),
                                                (x, marca) => new ModeloDTO
                                                {
                                                    Id = x.modelo.IdModelo,
                                                    Nombre = x.modelo.Nombre ?? "",
                                                    Marca = new MarcaDTO
                                                    {
                                                        Id = marca != null ? marca.IdMarca : 0,
                                                        Nombre = marca.Nombre ?? ""
                                                    }
                                                }).SingleOrDefault();

            ModeloDTO modelo = modeloBuscado != null ? modeloBuscado : new ModeloDTO();

            return modelo;
        }
    }
}
