namespace NbaPlayoffs.Services.DTOs
{
    public class PlayerDto
    {
        public string PositionCode { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int Rebounds { get; set; }
        public int GamesPlayed { get; set; }
        public double PointsPerGame { get; set; }
        public double ReboundsPerGame { get; set; }
    }
}
