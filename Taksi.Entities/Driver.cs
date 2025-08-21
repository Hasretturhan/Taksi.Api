namespace Taksi.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public string? TcKimlik { get; set; }
        public string? Phone { get; set; }
        public string? VehicleType { get; set; }
        public string? Plate { get; set; }
    }
}