using AutosEJ.Context;
using AutosEJ.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutosEJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly AutosEjContext _db;
        private MarcaDAO _marcaDAO;

        public MarcaController(AutosEjContext db)
        {
            _db = db;
            _marcaDAO = new MarcaDAO(_db);
        }

        [HttpGet]
        [Route("ObtenerLista")]
        public ActionResult ObtenerLista()
        {
            var listaMarcas = _marcaDAO.ObtenerLista();

            return Ok(listaMarcas);
        }

        [HttpGet]
        [Route("BuscarPorId")]
        public ActionResult BuscarPorId(int id) 
        {
            var marca = _marcaDAO.BuscarPorId(id);

            return Ok(marca);
        }
    }
}
