using examen_md.Models.Dto;

namespace examen_md.Services.Interface
{
    public interface IPhotoLocationService
    {
        Task<IEnumerable<LocationDto>> GetNearbyLocationsAsync(double lat, double lng);
    }
}
