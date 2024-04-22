namespace NbaPlayoffs.Services.DTOs
{
    public class PlayoffPredictionDto
    {
        public string Email { get; set; }
        public List<PlayoffTeamDto> Teams { get; set; }
    }
}
