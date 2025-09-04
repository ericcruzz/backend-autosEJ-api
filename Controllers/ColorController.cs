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
        [Route("listar")]
        public List<CatColorDTO> AllColors()
        {
            return _catColorDAO.AllSelects();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public CatColorDTO GetById(int id) 
        {
            return _catColorDAO.GetById(id);
        }
    }
}
