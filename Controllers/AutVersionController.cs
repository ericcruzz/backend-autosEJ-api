using AutosEJ.Context;
using AutosEJ.Models.Repository;
using AutosEJ.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutosEJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutVersionController : ControllerBase
    {
        private readonly AutosEjContext _db;
        private RepositorioBase _autVersionDAO;

        public AutVersionController(AutosEjContext db)
        {
            _db = db;
            _autVersionDAO = new AutVersionDAO(db);
        }

        [HttpGet]
        [Route("ObtenerLista")]
        public ActionResult ObtenerLista()
        {
            var listaVersiones = _autVersionDAO.ObtenerLista();

            return Ok(listaVersiones);
        }

        [HttpGet]
        [Route("BuscarPorId/{id}")]
        public ActionResult BuscarPorId(int id) 
        {
            var version = _autVersionDAO.BuscarPorId(id);

            return Ok(version);
        }
    }
}
