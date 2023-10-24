using examen_md.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace examen_md.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class MaximumSimultaneousGamesController : ControllerBase
    {
        private readonly IMaximumSimultaneousGamesService _maximumSimultaneousGamesService;

        public MaximumSimultaneousGamesController(IMaximumSimultaneousGamesService maximumSimultaneousGamesService)
        {
            _maximumSimultaneousGamesService = maximumSimultaneousGamesService;
        }

        [HttpGet]
        public IActionResult EvalPasswords([FromQuery] int playersNumber, [FromQuery] int fieldsNuimber)
        {
            // Valida que playersNumber y fieldsNuimber sean mayores a 0
            if (playersNumber <= 0 || fieldsNuimber <= 0)
            {
                // Devolver un código de error 400 y un mensaje si la cadena es nula o vacía
                return BadRequest("Parámetro playersNumber o fieldsNuimber inválido");
            }

            // Evaluar la cadena de passwords y obtener la longitud de la contraseña más larga
            object maxNumberOfGames = _maximumSimultaneousGamesService.MaximumSimultaneousGames(playersNumber, fieldsNuimber);

            // Devolver el resultado código de éxito 200 y el tipo de contenido application/json
            return Ok(maxNumberOfGames);

        }
    }
}
