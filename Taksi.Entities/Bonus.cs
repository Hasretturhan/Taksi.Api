namespace Taksi.Entities
{
    public class Bonus
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public decimal Amount { get; set; }
        public string? Description { get; set; }
    }
}
