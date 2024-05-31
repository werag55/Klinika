namespace Klinika.DTO
{
    public class CatDTO
    {
        public string Name { get; set; } = null!;
        public int Age { get; set; }
        public string Color { get; set; } = null!;
        public List<ClientDTO> Owners { get; set; } = null!;
    }
}
