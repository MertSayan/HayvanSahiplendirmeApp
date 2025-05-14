using Domain;

namespace Application.Interfaces.AdoptionTrackingInterface
{
    public interface IAdoptionTrackingRepository
    {
        Task<List<AdoptionTracking>> GetAllAdoptionTrackingAsync();
        Task<AdoptionTracking> GetByIdAdoptionTrackingAsync(int id);
    }
}
