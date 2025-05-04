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

        public ICollection<PetComment> PetComments { get; set; } = new List<PetComment>();
        public ICollection<PetLike> PetLikes { get; set; } = new List<PetLike>();
        public ICollection<AdoptionRequest> AdoptionRequests { get; set; } = new List<AdoptionRequest>();
    }
}
