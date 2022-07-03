using SearchEngineKeywordTracker.DataAccessLayer.Entities;
using SearchEngineKeywordTracker.DataAccessLayer.Interfaces;
using SearchEngineKeywordTracker.Domain.Interfaces;
using SearchEngineKeywordTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Services.Services
{
    public class SearchEngineService : ISearchEngineService
    {
        private readonly ISearchEngineRepository _searchEngineRepository;
        private readonly ISearchEngineSearchBusinessLogic _searchEngineSearchBusinessLogic;
        public SearchEngineService(ISearchEngineRepository searchEngineRepository, ISearchEngineSearchBusinessLogic searchEngineSearchBusinessLogic)
        {
            _searchEngineRepository = searchEngineRepository;
            _searchEngineSearchBusinessLogic = searchEngineSearchBusinessLogic;
        }
        public async Task<string> FormatKeywordFromSearchEngineIdAsync(int Id, string Keyword)
        {
            SearchEngines searchEngine = await _searchEngineRepository.GetSearchEngineByIdAsync(Id);
            switch (searchEngine.SearchEngineName)
            {
                case "Google":
                default:
                    Keyword = Keyword.Replace(" ", "-");
                    break;
            }
            return Keyword;
        }
        public async Task<string> FormatUrlWithKeywordParamaterFromSearchEngineIdAsync(string Keyword, int Id)
        {
            string url = "";
            string formattedKeyword = Keyword.Replace(" ", "+");
            SearchEngines searchEngine = await _searchEngineRepository.GetSearchEngineByIdAsync(Id);
            switch (searchEngine.SearchEngineName)
            {
                case "Google":
                default:
                    url = "https://www.google.co.uk/search?q=" + formattedKeyword;
                    break;
            }
            return url;
        }
        public async Task<string> FormatSearchUrlWithPageResultsCountAsync(string Url, int Id)
        {
            SearchEngines searchEngine = await _searchEngineRepository.GetSearchEngineByIdAsync(Id);
            int resultsCount = _searchEngineSearchBusinessLogic.SearchResultsCountLimit;
            switch (searchEngine.SearchEngineName)
            {
                case "Google":
                default:
                    Url = Url + "&num="+ resultsCount;
                    break;
            }
            return Url;
        }
        public async Task<string> FormatFullSearchUrlAsync(int Id, string Keyword)
        {
            string formattedKeyword = await FormatKeywordFromSearchEngineIdAsync(Id, Keyword);
            string urlWithKeyword = await FormatUrlWithKeywordParamaterFromSearchEngineIdAsync(formattedKeyword, Id);
            string urlWithResultsCount = await FormatSearchUrlWithPageResultsCountAsync(urlWithKeyword, Id);
            return urlWithResultsCount;
        }
    }
}
