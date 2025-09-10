using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutosEJ.Operations;
using AutosEJ.Models;
using AutosEJ.Context;
using AutosEJ.Models.DTO;

namespace AutosEJ.Controllers
{
    [Route("api/Vehiculo")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly AutosEjContext _db;

        private VehiculoDAO _vehiculoDAO;
        public AutoController(AutosEjContext db) 
        {
            _db = db;
            _vehiculoDAO = new VehiculoDAO(_db);
        }

        [HttpGet]
        [Route("listar")]
        public ActionResult AllVehiculos()
        {
            var vehiculoList = _vehiculoDAO.GetList();

            return Ok(vehiculoList);
        }

        [HttpGet]
        [Route("BuscarPorId/{id}")]
        public ActionResult VehiculoById(int id)
        {
            var vehiculo = _vehiculoDAO.GetById(id);

            return Ok(vehiculo);
        }
    }
}
