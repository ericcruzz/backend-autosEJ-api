using AutosEJ.Context;
using AutosEJ.Models;
using AutosEJ.Models.DTO;
using AutosEJ.Models.Repository;
using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutosEJ.Operations
{
    public class VehiculoDAO : RepositorioBase
    {
        public VehiculoDAO(AutosEjContext context) : base(context) { }

        public override List<VehiculoDTO> ObtenerLista()
        {
            try
            {
                var query = from veh in _context.Vehiculos
                            join version in _context.AutVersions on veh.IdAutVersion equals version.IdAutVersion
                            join modelo in _context.Modelos on version.IdModelo equals modelo.IdModelo
                            join marca in _context.Marcas on modelo.IdMarca equals marca.IdMarca
                            join colorExt in _context.CatColors on veh.IdColorExterior equals colorExt.IdColor
                            join colorInt in _context.CatColors on veh.IdColorInterior equals colorInt.IdColor
                            select new VehiculoDTO
                            {
                                Id = veh.IdVehiculo,
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

                List<VehiculoDTO> vehiculoList = query.ToList();

                return vehiculoList;
            }
            catch 
            {
                return null;                
            }
            
        }

        public override VehiculoDTO BuscarPorId(int id)
        {
            try
            {
                var vehiculo = _context.Vehiculos.Find(id);

                if (vehiculo == null)
                {
                    return new VehiculoDTO();
                }

                var version = _context.AutVersions.Find(vehiculo.IdAutVersion);
                var modelo = _context.Modelos.Find(version?.IdModelo);
                var marca = _context.Marcas.Find(modelo?.IdMarca);
                string colorExterior = CatColorDAO.GetColorNameById(_context, vehiculo?.IdColorExterior ?? 0);
                string colorInterior = CatColorDAO.GetColorNameById(_context, vehiculo?.IdColorInterior ?? 0);

                VehiculoDTO vehiculoDto =  TransferDataFromVehiculoToVehiculoDTO(vehiculo, version, marca, modelo, colorExterior, colorInterior);

                return vehiculoDto;

            }
            catch
            {
                return null;
            }
            
        }


        private VehiculoDTO TransferDataFromVehiculoToVehiculoDTO(Vehiculo vehiculo, AutVersion version, Marca marca, Modelo modelo, string colorExt, string colorInt)
        {
            VehiculoDTO vehiculoDto = new VehiculoDTO();

            vehiculoDto.Id = vehiculo.IdVehiculo;
            vehiculoDto.Serie = vehiculo.Serie;
            vehiculoDto.Niv = vehiculo.Niv;
            vehiculoDto.Placa = vehiculo.Placa;
            vehiculoDto.Motor = vehiculo.Motor;
            vehiculoDto.Version = version.Nombre + " " + version.Descripcion ?? "";
            vehiculoDto.Marca = marca.Nombre ?? "";
            vehiculoDto.Modelo = modelo.Nombre ?? "";
            vehiculoDto.Anio = version.Anio ?? "";
            vehiculoDto.ColorExterior = colorExt;
            vehiculoDto.ColorInterior = colorInt;

            return vehiculoDto;
        }
    }
}
