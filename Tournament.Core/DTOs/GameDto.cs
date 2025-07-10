
namespace Tournament.Core.DTOs
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int TournamentId { get; set; }
    }
}
