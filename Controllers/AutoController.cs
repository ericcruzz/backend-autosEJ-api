using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutosEJ.Models;

namespace AutosEJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly AutosEjContext _db;
        public AutoController(AutosEjContext db) 
        {
            _db = db;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult> Get()
        {
            var listaAuto = await _db.Vehiculos.ToListAsync();
            return Ok(listaAuto);
        }
    }
}
