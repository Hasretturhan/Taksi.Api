namespace Taksi.Entities
{
    public class Trip
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public int DriverId { get; set; }
        public string? StartAddress { get; set; }
        public string? EndAddress { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public double DistanceKm { get; set; }
        public decimal Fare { get; set; }
        public string? TaxiType { get; set; }
    }
}