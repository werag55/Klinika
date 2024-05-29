using Klinika.Models;

namespace Klinika.DTO
{
    public class AppoitmentDTO
    {
        public string GUID { get; set; } = null!;
        public DateTime Date { get; set; }
        public int CatId { get; set; }
        public Cat Cat { get; set; } = null!;
        public int ClientId { get; set; }
        public Client Client { get; set; } = null!;
    }
}
