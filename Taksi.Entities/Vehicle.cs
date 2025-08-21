namespace Taksi.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string? Type { get; set; } // "Sarı Taksi" veya "VIP Taksi"
        public string? Model { get; set; }
        public string? Plate { get; set; }
        public int DriverId { get; set; }
    }
}