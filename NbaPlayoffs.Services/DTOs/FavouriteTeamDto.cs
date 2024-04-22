using System.ComponentModel.DataAnnotations;

namespace NbaPlayoffs.Services.DTOs
{
    public class FavouriteTeamDto
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email is not valid.")]
        [MaxLength(50, ErrorMessage = "Email max length is 50")]
        public string Email { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Team is required.")]
        public int IdTeam { get; set; }
    }
}
