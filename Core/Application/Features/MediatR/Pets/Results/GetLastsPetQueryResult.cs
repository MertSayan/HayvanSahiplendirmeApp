namespace Application.Features.MediatR.Pets.Results
{
    public class GetLastsPetQueryResult
    {
        public int PetId { get; set; }
        public string UserNameSurname { get; set; }
        public string Name { get; set; }
        public string PetTypeName { get; set; }
        public DateTime CreatedDate { get; set; }
        
    }
}
