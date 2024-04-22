using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NbaPlayoffs.Services.DTOs;
using NbaPlayoffs.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace NbaPlayoffs.Pages
{
    public class IndexModel : PageModel
    {
        #region Private Properties
        private readonly ILogger<IndexModel> _logger;
        private readonly IClasificacionServices _clasificacionService;
        #endregion

        #region Public Properties
        public Dictionary<string, List<ClasificacionDto>> Clasificacion { get; set; }
        public SelectList AvailableYears => GetAvailableYears();
        public int SelectedYear { get; set; } = DateTime.Now.Year;
        #endregion

        public IndexModel(ILogger<IndexModel> logger, IClasificacionServices clasificacionService)
        {
            _logger = logger;
            _clasificacionService = clasificacionService;
        }

        public async Task OnGetAsync()
        {
            Clasificacion =  await _clasificacionService.GetAllByYear(SelectedYear);
        }

        public async Task<PartialViewResult> OnGetActualizarClasificacion(int year)
        {
            Clasificacion = await _clasificacionService.GetAllByYear(year);

            return Partial("Clasification/_ClasificacionPartial", Clasificacion);
        }

        private SelectList GetAvailableYears()
        {
            List<int> years = new();

            for (var i = 3; i >= 0; i--)
            {
                years.Add(DateTime.Now.Year - i);
            }

            return new SelectList(years);
        }
    }
}