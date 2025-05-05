namespace Domain
{
    public class User : Entity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string? AboutMe { get; set; } // Profil açıklaması

        public ICollection<Pet> Pets { get; set; } = new List<Pet>();
        public  ICollection<PetComment> PetComments { get; set; } = new List<PetComment>();
        public  ICollection<PetLike> PetLikes { get; set; } = new List<PetLike>();
        public  ICollection<Message> SentMessages { get; set; } = new List<Message>();
        public  ICollection<Message> ReceivedMessages { get; set; } = new List<Message>();
        public  ICollection<AdoptionRequest> SentRequests { get; set; } = new List<AdoptionRequest>();
        public  ICollection<AdoptionRequest> ReceivedRequests { get; set; } = new List<AdoptionRequest>();
    }
}
