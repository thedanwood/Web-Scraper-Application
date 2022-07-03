using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Application.Controllers
{
    public class SearchHistoryController : Controller
    {
        public async Task<ViewComponentResult> GetSearchHistoryViewComponent()
        {
            return ViewComponent("SearchHistory");
        }
    }
}
