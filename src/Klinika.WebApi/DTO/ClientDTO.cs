namespace Klinika.DTO
{
    public class ClientDTO
    {
        public string UserName { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public List<CatDTO> Cats { get; } = [];
    }
}
