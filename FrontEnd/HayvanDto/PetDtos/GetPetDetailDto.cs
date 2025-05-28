namespace HayvanDto.PetDtos
{
    public class GetPetDetailDto
    {
        public int PetId { get; set; }
        public string UserImageUrl { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public DateTime UserCreatedDate { get; set; }
        public string UserCity { get; set; }
        public string UserDistrict { get; set; }
        public string UserEmail { get; set; }
        public string Name { get; set; }
        public string PetTypeName { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsNeutered { get; set; } //kısırlaştırıldı mı
        public bool IsAdopted { get; set; } // sahiplendirilip sahiplendirilmediği ( ilan aktif mi pasif mi gibi )
        public string? Breed { get; set; } // Örn: "Golden Retriever"
        public string? MainImageUrl { get; set; }
        public int PetLikeCount { get; set; }
        public bool IsLiked { get; set; }



    }
}
