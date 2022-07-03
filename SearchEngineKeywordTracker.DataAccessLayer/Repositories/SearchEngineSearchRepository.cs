using Microsoft.EntityFrameworkCore;
using SearchEngineKeywordTracker.DataAccessLayer.Contexts;
using SearchEngineKeywordTracker.DataAccessLayer.Entities;
using SearchEngineKeywordTracker.DataAccessLayer.Interfaces;
using SearchEngineKeywordTracker.Domain.BusinessLogic;
using SearchEngineKeywordTracker.Domain.Interfaces;
using SearchEngineKeywordTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.DataAccessLayer.Repositories
{
    public class SearchEngineSearchRepository : ISearchEngineSearchRepository
    {
        private readonly AppDbContext _ctx;
        private readonly ISearchEngineRepository _searchEngineRepository;
        private readonly ISearchEngineSearchBusinessLogic _searchEngineSearchBusinessLogic;
        public SearchEngineSearchRepository(AppDbContext ctx, ISearchEngineRepository searchEngineRepository, ISearchEngineSearchBusinessLogic searchEngineSearchBusinessLogic)
        {
            _ctx = ctx;
            _searchEngineRepository = searchEngineRepository;
            _searchEngineSearchBusinessLogic = searchEngineSearchBusinessLogic;
        }
        #region create methods
        public async Task<SearchEngineSearches> SaveSearchEngineSearchAsync(string Url, string Keyword, int SearchEngineId, List<int> PositionNumbers)
        {
            SearchEngineSearches searchEngineSearch = new SearchEngineSearches()
            {
                Keyword = Keyword,
                SearchDateTime = DateTime.Now,
                Url = Url,
                SearchEngineId = SearchEngineId,
            };
            await _ctx.SearchEngineSearches.AddAsync(searchEngineSearch);
            await _ctx.SaveChangesAsync();
            await SaveSearchEngineSearchPositionAsync(searchEngineSearch.SearchEngineSearchId, PositionNumbers);
            return searchEngineSearch;
        }
        public async Task<bool> SaveSearchEngineSearchPositionAsync(int SearchEngineSearchId, List<int> PositionNumbers)
        {
            foreach (int positionNumber in PositionNumbers)
            {
                SearchEngineSearchPositions searchEngineSearchPosition = new SearchEngineSearchPositions()
                {
                    PositionNumber = positionNumber,
                    SearchEngineSearchId = SearchEngineSearchId
                };
                await _ctx.AddAsync(searchEngineSearchPosition);
                await _ctx.SaveChangesAsync();
            }
            return true;
        }
        #endregion
        #region read methods
        public async Task<List<SearchResultsModel>> GetAllSearchResultsAsync()
        {
            List<SearchEngineSearches> allSearchEngineSearches = _ctx.SearchEngineSearches.ToList();
            List<SearchResultsModel> searchResults = allSearchEngineSearches.Select(async r => await GetSearchResultFromEntityAsync(r)).Select(r=>r.Result).ToList();
            return searchResults;
        }
        public async Task<SearchResultsModel> GetSearchResultFromIdAsync(int SearchEngineSearchId)
        {
            SearchEngineSearches searchEngineSearch = await _ctx.SearchEngineSearches.FirstOrDefaultAsync(r => r.SearchEngineSearchId == SearchEngineSearchId);
            return await GetSearchResultFromEntityAsync(searchEngineSearch);
        }
        public async Task<SearchResultsModel> GetSearchResultFromEntityAsync(SearchEngineSearches SearchEngineSearch)
        {
            List<SearchEngineSearchPositions> searchEngineSearchPositions = await _ctx.SearchEngineSearchPositions.Where(r => r.SearchEngineSearchId == SearchEngineSearch.SearchEngineSearchId).ToListAsync();
            SearchEngines searchEngine = await _searchEngineRepository.GetSearchEngineByIdAsync(SearchEngineSearch.SearchEngineId);
            SearchResultsModel searchResult = new SearchResultsModel()
            {
                Keyword = SearchEngineSearch.Keyword,
                SearchEngineName = searchEngine.SearchEngineName,
                Url = SearchEngineSearch.Url,
                SearchedDateTime = await _searchEngineSearchBusinessLogic.FormatSearchedDatetimeForDisplay(SearchEngineSearch.SearchDateTime, true),
                PositionNumbers = searchEngineSearchPositions.Select(r => r.PositionNumber).ToList(),
            };
            return searchResult;
        }
        public async Task<List<SearchResultsModel>> GetSearchResultsFromIdsAsync(List<int> SearchEngineSearchIds)
        {
            List<SearchResultsModel> searchEngineSearchResults = new List<SearchResultsModel>();
            foreach (int seachEngineSearchId in SearchEngineSearchIds) {
                searchEngineSearchResults.Add(await GetSearchResultFromIdAsync(seachEngineSearchId));
            }
            return searchEngineSearchResults;
        }
        public async Task<List<SearchResultsModel>> GetSearchResultsFromEntitiesAsync(List<SearchEngineSearches> SearchEngineSearches)
        {
            List<SearchResultsModel> searchEngineSearchResults = new List<SearchResultsModel>();
            foreach (SearchEngineSearches searchEngineSearch in SearchEngineSearches)
            {
                searchEngineSearchResults.Add(await GetSearchResultFromEntityAsync(searchEngineSearch));
            }
            return searchEngineSearchResults;
        }
        public async Task<List<SearchResultsModel>> GetSearchResultsFromUrlKeywordAndSearchedDateTimeAsync(string Url, string Keyword, DateTime SearchedDateTime)
        {
            List<SearchResultsModel> searchEngineSearchResults = new List<SearchResultsModel>();
            List<SearchEngineSearches> searchEngineSearches = await _ctx.SearchEngineSearches.Where(r => r.Keyword == Keyword && r.Url == Url &&
                r.SearchDateTime.Day == SearchedDateTime.Day && r.SearchDateTime.Month == SearchedDateTime.Month && r.SearchDateTime.Year == SearchedDateTime.Year).ToListAsync();
            foreach (SearchEngineSearches seachEngineSearch in searchEngineSearches)
            {
                searchEngineSearchResults.Add(await GetSearchResultFromIdAsync(seachEngineSearch.SearchEngineSearchId));
            }
            return searchEngineSearchResults;
        }
        public async Task<List<string>> GetAllKeywordsUsedAsync()
        {
            List<string> keywords = await _ctx.SearchEngineSearches.Select(r => r.Keyword).Distinct().ToListAsync();
            return keywords;
        }
        public async Task<List<string>> GetAllUrlsUsedAsync()
        {
            List<string> urls = await _ctx.SearchEngineSearches.Select(r => r.Url).Distinct().ToListAsync();
            return urls;
        }
        #endregion
        #region update methods
        #endregion
        #region delete methods
        #endregion
    }
}
