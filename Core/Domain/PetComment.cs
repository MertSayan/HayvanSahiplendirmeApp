namespace Domain
{
    public class PetComment : Entity
    {
        public int PetCommentId { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string CommentText { get; set; }
    }
}
