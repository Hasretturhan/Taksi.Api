namespace Taksi.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public string? Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
