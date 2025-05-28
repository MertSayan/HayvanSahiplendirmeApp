namespace HayvanDto.PetDtos
{
    public class AddPetCommentDto
    {
        public int PetId { get; set; }
        public int UserId { get; set; }
        public string CommentText { get; set; }
    }
}
