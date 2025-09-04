using AutosEJ.Context;
using AutosEJ.Models;
using AutosEJ.Models.DTO;
using System;
using System.Linq;
using System.Numerics;
using System.Text.RegularExpressions;

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
            catch 
            {
                return null;                
            }
            
        }

        public VehiculoDTO VehiculoById(int id)
        {
            try
            {
                //var vehiculo = _context.Vehiculos.Where(vehiculo => vehiculo.IdVehiculo == id).FirstOrDefault();

                //if (vehiculo == null)
                //{
                //    return new VehiculoDTO();
                //}

                //var version = _context.AutVersions.Where(version => version.IdAutVersion == vehiculo.IdAutVersion).FirstOrDefault();
                //var modelo = _context.Modelos.Where(modelo => modelo.IdModelo == version.IdModelo).FirstOrDefault();
                //var marca = _context.Marcas.Where(marca => marca.IdMarca == modelo.IdMarca).FirstOrDefault();
                //string colorExterior = CatColorDAO.GetColorNameById(_context, vehiculo?.IdColorExterior ?? 0);
                //string colorInterior = CatColorDAO.GetColorNameById(_context, vehiculo?.IdColorInterior ?? 0);

                //VehiculoDTO vehiculoDto = TransferDataFromVehiculoToVehiculoDTO(vehiculo, version, marca, modelo, colorExterior, colorInterior);

                //return vehiculoDto;

                var query = from veh in _context.Vehiculos
                            join version in _context.AutVersions on veh.IdAutVersion equals version.IdAutVersion
                            join modelo in _context.Modelos on version.IdModelo equals modelo.IdModelo
                            join marca in _context.Marcas on modelo.IdMarca equals marca.IdMarca
                            join colorExt in _context.CatColors on veh.IdColorExterior equals colorExt.IdColor
                            join colorInt in _context.CatColors on veh.IdColorInterior equals colorInt.IdColor
                            where veh.IdVehiculo == id
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


                VehiculoDTO vehiculo = new VehiculoDTO();

                if (query != null)
                {
                    vehiculo = query.First();
                }

                return vehiculo;
            }
            catch
            {
                return null;
            }
            
        }


        private VehiculoDTO TransferDataFromVehiculoToVehiculoDTO(Vehiculo vehiculo, AutVersion version, Marca marca, Modelo modelo, string colorExt, string colorInt)
        {
            VehiculoDTO vehiculoDto = new VehiculoDTO();

            vehiculoDto.IdVehiculo = vehiculo.IdVehiculo;
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
