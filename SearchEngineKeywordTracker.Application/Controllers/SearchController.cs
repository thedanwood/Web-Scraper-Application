using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SearchEngineKeywordTracker.Application.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SearchEngineKeywordTracker.Application.ViewModels;
using System.Net;
using System.Text.RegularExpressions;
using SearchEngineKeywordTracker.DataAccessLayer.Interfaces;
using System.Collections.Generic;
using SearchEngineKeywordTracker.Services;
using SearchEngineKeywordTracker.Services.Interfaces;
using SearchEngineKeywordTracker.DataAccessLayer.Entities;
using SearchEngineKeywordTracker.Domain.Models;
using SearchEngineKeywordTracker.Domain.Interfaces;

namespace SearchEngineKeywordTracker.Application.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchEngineRepository _searchEngineRepository;
        private readonly ISearchEngineSearchRepository _searchEngineSearchRepository;
        private readonly ISearchEngineSearchService _searchEngineSearchService;
        private readonly ISearchEngineSearchBusinessLogic _searchEngineSearchBusinessLogic;
        public SearchController(ISearchEngineRepository searchEngineRepository, ISearchEngineSearchRepository searchEngineSearchRepository, ISearchEngineSearchService searchEngineSearchService, ISearchEngineSearchBusinessLogic searchEngineSearchBusinessLogic)
        {
            _searchEngineRepository = searchEngineRepository;
            _searchEngineSearchRepository = searchEngineSearchRepository;
            _searchEngineSearchService = searchEngineSearchService;
            _searchEngineSearchBusinessLogic = searchEngineSearchBusinessLogic;
        }
        public async Task<IActionResult> ResultsTest()
        {
            var test = await _searchEngineRepository.GetSearchEngineByIdAsync(1);
            List<SearchResultsModel> SearchEngineSearchList = new List<SearchResultsModel>();
            SearchResultsModel r1 = await _searchEngineSearchRepository.GetSearchResultFromIdAsync(10);
            SearchResultsModel r2 = await _searchEngineSearchRepository.GetSearchResultFromIdAsync(18);
            SearchResultsModel r3 = await _searchEngineSearchRepository.GetSearchResultFromIdAsync(26);
            SearchEngineSearchList.Add(r1);
            SearchEngineSearchList.Add(r2);
            SearchEngineSearchList.Add(r3);
            return View("Results", SearchEngineSearchList);
        }
        public async Task<IActionResult> Results(List<SearchEngineSearches> SearchEngineSearchList)
        {
            List<SearchResultsModel> searchResults = await _searchEngineSearchRepository.GetSearchResultsFromEntitiesAsync(SearchEngineSearchList);
            return View(searchResults);
        }
        public async Task<IActionResult> Index()
        {
            return View(new SearchEngineSearchModel()
            {
                AllowedSearchEngineTypes = await _searchEngineRepository.GetAllSearchEnginesAsync(),
                SearchKeywords = new List<string>() { _searchEngineSearchBusinessLogic.DefaultKeywordSelectedForSearch },
                SearchUrl = _searchEngineSearchBusinessLogic.DefaultUrlSelectedForSearch
            });
        }
        [HttpPost]
        public async Task<IActionResult> Index(SearchEngineSearchModel model)
        {
            if (!ModelState.IsValid)
            {
                model.AllowedSearchEngineTypes = await _searchEngineRepository.GetAllSearchEnginesAsync();
                return View("index", model);
            }

            List<SearchResultsModel> savedSearchResultsList = new List<SearchResultsModel>();
            foreach (int searchEngineId in model.SearchEngineTypes)
            {
                foreach (string keyword in model.SearchKeywords)
                {
                    List<int> keywordPositions = await _searchEngineSearchService.GetKeywordPositionsAsync(searchEngineId, keyword, model.SearchUrl);
                    SearchEngineSearches savedSearchEngineSearch = await _searchEngineSearchRepository.SaveSearchEngineSearchAsync(model.SearchUrl, keyword, searchEngineId, keywordPositions);
                    SearchResultsModel searchResult = await _searchEngineSearchRepository.GetSearchResultFromEntityAsync(savedSearchEngineSearch);
                    savedSearchResultsList.Add(searchResult);
                }
            }
            return View("Results", savedSearchResultsList);
        }
    }
}
