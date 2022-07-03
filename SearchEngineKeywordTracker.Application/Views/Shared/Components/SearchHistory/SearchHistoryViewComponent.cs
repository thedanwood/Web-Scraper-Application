using Microsoft.AspNetCore.Mvc;
using SearchEngineKeywordTracker.DataAccessLayer.Interfaces;
using SearchEngineKeywordTracker.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Application.Views.Shared.Components
{
    public class SearchHistoryViewComponent : ViewComponent
    {
        private readonly ISearchEngineSearchRepository _searchEngineSearchRepository;
        public SearchHistoryViewComponent(ISearchEngineSearchRepository searchEngineSearchRepository)
        {
            _searchEngineSearchRepository = searchEngineSearchRepository;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<SearchResultsModel> searchResultsList = await _searchEngineSearchRepository.GetAllSearchResultsAsync();
            return View("SearchHistory",searchResultsList);
        }
    }
}
