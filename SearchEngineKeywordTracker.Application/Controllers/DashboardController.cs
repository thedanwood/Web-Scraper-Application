using Microsoft.AspNetCore.Mvc;
using SearchEngineKeywordTracker.Domain.Models;
using SearchEngineKeywordTracker.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Application.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IDashboardService _dashboardService;
        public DashboardController(IDashboardService dashboardService)
        {
            _dashboardService = dashboardService;
        }
        [HttpGet]
        public async Task<JsonResult> GetDashboardLineChartData(int FrequencyEnumInt, string Keyword, string Url)
        {
            DashboardLineChartModel lineChartData = await _dashboardService.GetDashboardLineChartModel(Keyword, Url, FrequencyEnumInt);
            return Json(new { data = lineChartData });
        }
        public async Task<ViewComponentResult> GetDashboardViewComponent()
        {
            return ViewComponent("Dashboard");
        }
        public async Task<IActionResult> Test()
        {
            WebClient client = new WebClient();
            byte[] returnData = client.DownloadData("https://www.google.co.uk/search?q=land+registry+search&num=5");
            string returnDataString = Encoding.ASCII.GetString(returnData);
            return Content(returnDataString);
        }
    }
}
