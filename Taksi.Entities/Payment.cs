namespace Taksi.Entities
{
    public class Payment
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public string? CardType { get; set; } // Visa, Mastercard, vb.
        public string? CardNumberMasked { get; set; }
        public string? Expiry { get; set; }
    }
}