namespace Domain
{
    public class Pet : Entity
    {
        public int PetId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Name { get; set; }
        public int PetTypeId { get; set; }
        public PetType PetType { get; set; }
        public string Age { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public bool IsVaccinated { get; set; }
        public bool IsNeutered { get; set; } //kısırlaştırıldı mı
        public bool IsAdopted { get; set; } // sahiplendirilip sahiplendirilmediği ( ilan aktif mi pasif mi gibi )
        public string? Breed { get; set; } // Örn: "Golden Retriever"
        public string MainImageUrl { get; set; }
        public ICollection<PetImage> Images { get; set; }=new List<PetImage>();

        public ICollection<PetComment> PetComments { get; set; } = new List<PetComment>();
        public ICollection<PetLike> PetLikes { get; set; } = new List<PetLike>();
        public ICollection<AdoptionRequest> AdoptionRequests { get; set; } = new List<AdoptionRequest>();
        public ICollection<PetFavorite> PetFavorites { get; set; } = new List<PetFavorite>();

    }
}
