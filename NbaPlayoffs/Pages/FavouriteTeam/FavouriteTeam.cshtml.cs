using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NbaPlayoffs.Services.DTOs;
using NbaPlayoffs.Services.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace NbaPlayoffs.Pages.FavouriteTeam
{
    public class FavouriteTeamModel : PageModel
    {
        private ITeamServices _teamServices;
        private IFavouriteTeamServices _favouriteTeamServices;

        public FavouriteTeamModel(ITeamServices teamServices, IFavouriteTeamServices favouriteTeamServices)
        {
            _teamServices = teamServices;
            _favouriteTeamServices = favouriteTeamServices;
            Form = new();
            TeamsOptions = Task.Run(() => _teamServices.GetAll()).Result;
        }

        [BindProperty]
        public FavouriteTeamDto Form { get; set; }
        public List<TeamDto> TeamsOptions { get; set; }

        public async Task OnGetAsync()
        {
            TeamsOptions = await _teamServices.GetAll();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = new ResponseDto();
            if (ModelState.IsValid)
            {
                response = await _favouriteTeamServices.Save(Form);


                var jsonResponse = JsonSerializer.Serialize(response);

                // Devolvemos la respuesta JSON al cliente
                return new ContentResult
                {
                    Content = jsonResponse,
                    ContentType = "application/json",
                    StatusCode = 200
                };

            }
            else
            {
                var page = Page();
                page.StatusCode = 400;

                return page;

            }
        }
    }
}
