using AutosEJ.Context;
using AutosEJ.Models.Repository;
using AutosEJ.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutosEJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloController : ControllerBase
    {
        private readonly AutosEjContext _db;
        private RepositorioBase _modeloDAO;

        public ModeloController(AutosEjContext db)
        {
            _db = db;
            _modeloDAO = new ModeloDAO(_db);
        }

        [HttpGet]
        [Route("ObtenerLista")]
        public ActionResult ObtenerLista()
        {
            var listaModelos = _modeloDAO.ObtenerLista();

            return Ok(listaModelos);
        }

        [HttpGet]
        [Route("BuscarPorId/{id}")]
        public ActionResult BuscarPorId(int id) 
        {
            var modelo = _modeloDAO.BuscarPorId(id);

            return Ok(modelo);
        }
    }
}
