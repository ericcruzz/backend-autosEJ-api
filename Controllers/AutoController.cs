using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutosEJ.Operations;
using AutosEJ.Models;
using AutosEJ.Context;
using AutosEJ.Models.DTO;

namespace AutosEJ.Controllers
{
    [Route("api/[controller]")]
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
        public List<VehiculoDTO> AllVehiculos()
        {
            return _vehiculoDAO.AllSelects();
        }

        //[HttpGet]
        //[Route("BuscarPorId/{id}")]
        //public async Task<ActionResult> Get(int id)
        //{
        //    var auto = await _db.Vehiculos.ToListAsync();
        //    return Ok(auto);
        //}
    }
}
