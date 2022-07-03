using Microsoft.AspNetCore.Mvc;
using SearchEngineKeywordTracker.Application.ViewModels;
using SearchEngineKeywordTracker.DataAccessLayer.Interfaces;
using SearchEngineKeywordTracker.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Application.Views.Shared.Components.Dashboard
{
    public class DashboardViewComponent : ViewComponent
    {
        private readonly ISearchEngineSearchRepository _searchEngineSearchRepository;
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardViewComponent(ISearchEngineSearchRepository searchEngineSearchRepository, IDashboardRepository dashboardRepository)
        {
            _searchEngineSearchRepository = searchEngineSearchRepository;
            _dashboardRepository = dashboardRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            DashboardViewModel viewModel = new DashboardViewModel()
            {
                DashboardFrequencies = await _dashboardRepository.GetAllDashboardFrequenciesAsync(),
                Keywords = await _searchEngineSearchRepository.GetAllKeywordsUsedAsync(),
                Urls = await _searchEngineSearchRepository.GetAllUrlsUsedAsync()
            };
            return View("Dashboard", viewModel);
        }
    }
}
