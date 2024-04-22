namespace NbaPlayoffs.Services.DTOs
{
    public class ClasificacionDto
    {
        public int Position { get; set; }
        public string TeamName { get; set; }
        public int TeamId { get; set; } 
        public int TeamRecordId { get; set; } 
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string TeamImageSrc { get; set; }
    }
}
