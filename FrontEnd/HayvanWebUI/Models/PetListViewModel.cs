using HayvanDto.PetDtos;

namespace HayvanWebUI.Models
{
    public class PetListViewModel
    {
        public List<GetAllFilterPetDto> Pets { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}
