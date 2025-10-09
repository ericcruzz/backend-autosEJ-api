using AutosEJ.Context;
using AutosEJ.Models.DTO;
using AutosEJ.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutosEJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorController : ControllerBase
    {
        private readonly AutosEjContext _db;
        private CatColorDAO _catColorDAO;

        public ColorController(AutosEjContext db) 
        { 
            _db = db;
            _catColorDAO = new CatColorDAO(_db);
        }

        [HttpGet]
        [Route("ObtenerLista")]
        public ActionResult ObtenerLista()
        {
            var listaColores = _catColorDAO.ObtenerLista();

            return Ok(listaColores);
        }

        [HttpGet]
        [Route("BuscarPorId")]
        public ActionResult BuscarPorId(int id) 
        {
            var color = _catColorDAO.BuscarPorId(id);

            return Ok(color);
        }
    }
}
