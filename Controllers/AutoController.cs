using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutosEJ.Context;

namespace AutosEJ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly AutosEJDb _db;
        public AutoController(AutosEJDb db) 
        {
            _db = db;
        }

        [HttpGet]
        [Route("lista")]
        public async Task<ActionResult> Get()
        {
            var listaAuto = await _db.Marcas.ToListAsync();
            return Ok(listaAuto);
        }
    }
}
