namespace Klinika.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public List<Cat> Cats { get; } = [];
    }
}
