using AutosEJ.Context;
using AutosEJ.Models.DTO;
using AutosEJ.Models.Interfaces;
using AutosEJ.Models.Repository;
using System.Collections;

namespace AutosEJ.Operations
{
    public class AutVersionDAO : RepositorioBase
    {
        public AutVersionDAO (AutosEjContext context) : base(context) { }



        public override List<AutVersionDTO> ObtenerLista()
        {
            var query = _context.AutVersions.ToList();

            List<AutVersionDTO> lista = new List<AutVersionDTO>();
            ModeloDAO modelos = new ModeloDAO(_context);
            List<ModeloDTO> listaModelos = modelos.ObtenerLista();

            foreach (var item in query)
            {
                AutVersionDTO version = new AutVersionDTO();
                version.Id = item.IdAutVersion;
                version.Nombre = item.Nombre ?? "";
                version.Descripcion = item.Descripcion ?? "";
                version.Anio = item.Anio ?? "";
                version.Modelo = listaModelos.Find(modelo => modelo.Id == item.IdModelo);
                lista.Add(version);
            }

            return lista;
        }

        public override AutVersionDTO BuscarPorId(int id)
        {

            AutVersionDTO version = new AutVersionDTO();

            var item = _context.AutVersions.Where(v => v.IdAutVersion == id).SingleOrDefault();

            if (item == null)
                return version;

            version.Id = item.IdAutVersion;
            version.Nombre = item.Nombre ?? "";
            version.Descripcion = item.Descripcion ?? "";
            version.Anio = item.Anio ?? "";
            ModeloDAO modeloItem = new ModeloDAO(_context);
            version.Modelo = modeloItem.BuscarPorId(item.IdModelo);

            return version;
        }
    }
}
