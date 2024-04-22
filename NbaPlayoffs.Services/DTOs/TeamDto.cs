namespace NbaPlayoffs.Services.DTOs
{
    public class TeamDto
    {
        public int IdTeam { get; set; }
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public List<PlayerDto> Players { get; set; }
    }
}
