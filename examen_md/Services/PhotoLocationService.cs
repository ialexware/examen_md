using examen_md.Models;
using examen_md.Models.Dto;
using examen_md.Services.Interface;

namespace examen_md.Services
{
    public class PhotoLocationService : IPhotoLocationService
    {
        // Definir la URL base de la fuente de datos externa
        private const string BaseUrl = "https://jsonplaceholder.typicode.com/";

        // Definir un cliente HTTP para realizar las peticiones
        private readonly HttpClient _httpClient;

        // Definir un constructor que recibe un cliente HTTP por inyección de dependencias
        public PhotoLocationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            // Establecer la URL base del cliente HTTP
            _httpClient.BaseAddress = new Uri(BaseUrl);
        }

        public async Task<IEnumerable<LocationDto>> GetNearbyLocationsAsync(double lat, double lng)
        {
            // Realizar una petición GET a la ruta /photos y obtener los datos en formato JSON
            IEnumerable<Photos>? photos = await _httpClient.GetFromJsonAsync<IEnumerable<Photos>>("/photos");

            // Crear una lista vacía para almacenar las ubicaciones
            var locations = new List<LocationDto>();
            if (photos != null)
            {
                // Recorrer cada foto obtenida
                foreach (var photo in photos.Take(100))
                {

                    // Crear una instancia de la clase Location con los datos de la foto y la dirección
                    var location = new LocationDto
                    {
                        Latitude = lat,
                        Longitude = lng,
                        Id = photo.Id,
                        Name = photo.Title
                    };

                    // Agregar la ubicación a la lista
                    locations.Add(location);

                }
            }

            // Devolver la lista de ubicaciones
            return locations;

        }
    }
}
