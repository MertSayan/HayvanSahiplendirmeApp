namespace Domain
{
    public class PetLike : Entity
    {
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
