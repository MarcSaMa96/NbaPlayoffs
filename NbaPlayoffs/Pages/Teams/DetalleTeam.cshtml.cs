using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NbaPlayoffs.Services.DTOs;
using NbaPlayoffs.Services.Interfaces;

namespace NbaPlayoffs.Pages.Teams
{
    public class DetalleTeamModel : PageModel
    {
        #region Private Properties
        private readonly ITeamServices _teamServices;
        #endregion

        #region Public Properties
        public TeamDto Team { get; set; }
        #endregion

        public DetalleTeamModel(ITeamServices teamServices)
        {
            _teamServices= teamServices;
        }

        public async Task OnGetAsync(int idTeam, int year)
        {
            Team = await _teamServices.GetByIdYear(idTeam, year);
            ViewData["Title"] = Team.Name;
        }
    }
}
