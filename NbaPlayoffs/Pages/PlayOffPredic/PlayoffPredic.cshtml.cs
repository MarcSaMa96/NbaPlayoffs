using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NbaPlayoffs.Services.DTOs;
using NbaPlayoffs.Services.Interfaces;
using System.Text.Json;

namespace NbaPlayoffs.Pages
{
    public class PlayoffPredicModel : PageModel
    {
        private IPlayoffServices _playoffServices;

        public List<PlayoffTeamDto> ConferenciaEste { get; set; }
        public List<PlayoffTeamDto> ConferenciaOeste { get; set; }

        public PlayoffPredicModel(IPlayoffServices playoffServices)
        {
            _playoffServices = playoffServices; 
        }

        public async Task OnGetAsync()
        {
            var equipos = await _playoffServices.GetFirstRoundTeams();
            ConferenciaEste = equipos["Este"];
            ConferenciaOeste = equipos["Oeste"];
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var stringData = Request.Form["datos"].FirstOrDefault();

            if (!string.IsNullOrEmpty(stringData))
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                PlayoffPredictionDto model = JsonSerializer.Deserialize<PlayoffPredictionDto>(stringData, options);

                var response = await _playoffServices.InsertPrediction(model);

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
                return new ContentResult
                {
                    StatusCode = 404
                };
            }

        }
    }
}
