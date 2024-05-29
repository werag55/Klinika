namespace Klinika.Models
{
    public class Appoitment
    {
        public int Id { get; set; }
        public string GUID { get; set; } = null!;
        public DateTime date { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
        public int CatId { get; set; }
        public Cat Cat { get; set; } = null!;

    }
}
