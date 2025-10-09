using AutosEJ.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutosEJ.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpPost("autenticacion")]
        public string? Login([FromBody] User usuario)
        {
            if (usuario == null)
                return null;

            return usuario.Usuario == "EriCZZ" && usuario.Password == "12345" ? "true" : null;
        }
    }
}
