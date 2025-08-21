namespace Taksi.Entities
{
    public class SupportRequest
    {
        public int Id { get; set; }
        public int PassengerId { get; set; }
        public string? Category { get; set; } // "Sürücü Sorunu", "Ücret Problemi", vb.
        public string? Description { get; set; }
        public DateTime RequestDate { get; set; }
        public bool IsResolved { get; set; }
    }
}
