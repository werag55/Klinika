namespace Klinika.Domain.Models
{
    public class Appoitment
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime Date { get; set; }
        public int CatId { get; set; }
        public Cat Cat { get; set; } = null!;
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
    }
}
