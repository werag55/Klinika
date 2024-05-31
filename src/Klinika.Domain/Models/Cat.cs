namespace Klinika.Domain.Models
{
    public class Cat
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Color { get; set; } = null!;
        public List<Client> Owners { get; set; } = null!;
    }
}
