using AutosEJ.Context;
using AutosEJ.Models;
using AutosEJ.Models.DTO;

namespace AutosEJ.Operations
{
    public class VehiculoDAO
    {
        private readonly AutosEjContext _context;

        public VehiculoDAO(AutosEjContext context) 
        { 
            _context = context;
        }

        public List<VehiculoDTO> AllSelects()
        {
            var query = from veh in _context.Vehiculos
                        join version in _context.AutVersions on veh.IdAutVersion equals version.IdAutVersion
                        join modelo in _context.Modelos on version.IdModelo equals modelo.IdModelo
                        join marca in _context.Marcas on modelo.IdMarca equals marca.IdMarca
                        join colorExt in _context.CatColors on veh.IdColorExterior equals colorExt.IdColor
                        join colorInt in _context.CatColors on veh.IdColorInterior equals colorInt.IdColor
                        select new VehiculoDTO
                        {
                            IdVehiculo = veh.IdVehiculo,
                            Serie = veh.Serie,
                            Niv = veh.Niv,
                            Placa = veh.Placa,
                            Motor = veh.Motor,
                            Version = version.Nombre + " " + version.Descripcion ?? "",
                            Marca = marca.Nombre ?? "",
                            Modelo = modelo.Nombre ?? "",
                            Anio = version.Anio ?? "",
                            ColorExterior = colorExt.Descripcion ?? "",
                            ColorInterior = colorInt.Descripcion ?? ""
                        };
            
                        
            return query.ToList();
        }
    }
}
