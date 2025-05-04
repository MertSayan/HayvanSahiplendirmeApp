namespace Domain
{
    public class PetType : Entity
    {
        public int PetTypeId { get; set; }
        public string PetTypeName { get; set; }

        public  ICollection<Pet> Pets { get; set; } = new List<Pet>();
    }
}
