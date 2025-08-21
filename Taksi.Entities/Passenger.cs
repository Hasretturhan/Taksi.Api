namespace Taksi.Entities
{
    public class Passenger
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Gender { get; set; }
        public string? Phone { get; set; }
    }
}