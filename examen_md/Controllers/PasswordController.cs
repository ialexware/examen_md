using examen_md.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace examen_md.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        private readonly IPasswordService _passwordService;

        public PasswordController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }

        [HttpGet]
        public IActionResult EvalPasswords([FromQuery] string passwords)
        {
            // Valida que la cadena de passwords no sea nula o vacía
            if (string.IsNullOrEmpty(passwords))
            {
                // Devolver un código de error 400 y un mensaje si la cadena es nula o vacía
                return BadRequest("Parámetro passwords inválido");
            }

            // Evaluar la cadena de passwords y obtener la longitud de la contraseña más larga
            object longestPassword = _passwordService.FindLongestPassword(passwords);

            // Devolver el objeto JSON con un código de éxito 200 y el tipo de contenido application/json
            return Ok(longestPassword);

        }
    }
}
