namespace HayvanDto.CommentDtos
{
    public class GetAllPetCommentDto
    {
        public int PetCommentId { get; set; }
        public string PetName { get; set; }
        public string UserName { get; set; }
        public string UserImageUrl { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CommentText { get; set; }
    }
}
