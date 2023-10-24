using examen_md.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace examen_md.Controllers
{
    [Route("v1/locations/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {

        private readonly IPhotoLocationService _photoLocationService;

        public LocationsController(IPhotoLocationService photoLocationService)
        {
            _photoLocationService = photoLocationService;
        }

        [HttpGet]
        public async Task<IActionResult> Search(
       [FromQuery] string access_token, // Obtener el parámetro access_token de la URL
       [FromQuery] string lat, // Obtener el parámetro lat de la URL
       [FromQuery] string lng) // Obtener el parámetro lng de la URL
        {
            // Validar el parámetro access_token
            if (access_token != "ACCESS_TOKEN")
            {
                // Devolver un código de error 401 y un mensaje si no es válido
                return Unauthorized("Access token inválido");
            }

            // Validar los parámetros lat y lng
            if (!double.TryParse(lat, out double latitude) || !double.TryParse(lng, out double longitude))
            {
                // Devolver un código de error 400 y un mensaje si no son números válidos
                return BadRequest("Parámetros lat y lng inválidos");
            }

            // Obtener las ubicaciones de fotos más cercanas a las coordenadas dadas usando el servicio
            var locations = await _photoLocationService.GetNearbyLocationsAsync(latitude, longitude);

            // Crear un objeto JSON con la estructura indicada en la respuesta
            var response = new
            {
                meta = new
                {
                    code = HttpStatusCode.OK,
                },
                data = locations
            };

            // Devolver el objeto JSON con un código de éxito 200 y el tipo de contenido application/json
            return Ok(response);

        }
    }
}
