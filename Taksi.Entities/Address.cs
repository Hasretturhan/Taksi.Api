namespace Taksi.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public string? Type { get; set; }  // "Ev", "İş", "Ailem", vb.
        public string? Description { get; set; } 
    }
}
