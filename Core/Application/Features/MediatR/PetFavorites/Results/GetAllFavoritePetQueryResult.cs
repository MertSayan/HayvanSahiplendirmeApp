namespace Application.Features.MediatR.PetFavorites.Results
{
    public class GetAllFavoritePetQueryResult
    {
        public int PetId { get; set; }
        public string Name { get; set; }
        public string PetTypeName { get; set; }
        public string Age { get; set; }
        public string Description { get; set; }
        public string MainImageUrl { get; set; }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
    }
}
