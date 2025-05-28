using Domain;

namespace Application.Interfaces.PetLikeInterface
{
    public interface IPetLikeRepository
    {
        Task<List<PetLike>> GetAllPetLikeByPetIdAsync(int id);
        Task<List<PetLike>> GetAllPetLikeByUserIdAsync(int id);
        Task<PetLike> GetPetLikeByIdAsync(int userId, int petId);
        Task DeletePetLikeAsync(PetLike entity);
        Task<bool> IsLiked(int userId,int petId);
        
    }
}
