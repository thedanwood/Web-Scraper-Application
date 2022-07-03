using SearchEngineKeywordTracker.DataAccessLayer.Entities;
using SearchEngineKeywordTracker.DataAccessLayer.Interfaces;
using SearchEngineKeywordTracker.Domain.Models;
using SearchEngineKeywordTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Services
{
    public class SearchEngineSearchService : ISearchEngineSearchService
    {
        private readonly ISearchEngineRepository _searchEngineRepository;
        private readonly ISearchEngineSearchRepository _searchEngineSearchRepository;
        private readonly ISearchEngineService _searchEngineService;
        public SearchEngineSearchService(ISearchEngineRepository searchEngineRepository, ISearchEngineSearchRepository searchEngineSearchRepository, ISearchEngineService searchEngineService)
        {
            _searchEngineRepository = searchEngineRepository;
            _searchEngineSearchRepository = searchEngineSearchRepository;
            _searchEngineService = searchEngineService;
        }
        #region processing methods
        public async Task<List<int>> GetKeywordPositionsAsync(int SearchEngineId, string Keyword, string Url)
        {
            SearchEngines searchEngine = await _searchEngineRepository.GetSearchEngineByIdAsync(SearchEngineId);
            string formattedKeyword = await _searchEngineService.FormatKeywordFromSearchEngineIdAsync(SearchEngineId, Keyword);
            Regex regex = await _searchEngineRepository.GetSearchEngineRegexByIdAsync(SearchEngineId);
            string formattedUrl = await _searchEngineService.FormatFullSearchUrlAsync(SearchEngineId, Keyword);
            List<Match> regexMatches = await GetKeywordMatchListAsync(regex, formattedUrl, Keyword);
            List<int> keywordPositionList = regexMatches.Select((item, i) => new { value = item.Value, position = i + 1 }).Where(r => r.value.Contains("infotrack.co.uk")).Select(r => r.position).ToList();
            return keywordPositionList;
        }
        public async Task<List<Match>> GetKeywordMatchListAsync(Regex RegexPattern, string FullUrl, string Keyword)
        {
            using (WebClient webClient = new WebClient())
            {
                byte[] returnData = webClient.DownloadData(FullUrl);
                string returnDataString = Encoding.ASCII.GetString(returnData);
                List<Match> regexMatches = RegexPattern.Matches(returnDataString).ToList();
                return regexMatches;
            }
        }
        public async Task<int> GetAveragePositionOfSearchResultAsync(SearchResultsModel searchResult)
        {
            int averagePosition = await GetAveragePositionFromListPositionsAsync(searchResult.PositionNumbers);
            return averagePosition;
        }
        public async Task<int> GetAveragePositionFromListPositionsAsync(List<int> Positions)
        {
            if (Positions == null || Positions.Count() == 0)
            {
                return 0;
            }
            double averagePositionDouble = Positions.Average();
            int averagePositionFormatted = Convert.ToInt32(averagePositionDouble);
            return averagePositionFormatted;
        }
        #endregion
    }
}
