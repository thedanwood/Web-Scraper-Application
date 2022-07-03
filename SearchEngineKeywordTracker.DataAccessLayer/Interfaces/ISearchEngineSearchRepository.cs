using SearchEngineKeywordTracker.DataAccessLayer.Entities;
using SearchEngineKeywordTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.DataAccessLayer.Interfaces
{
    public interface ISearchEngineSearchRepository
    {
        Task<SearchEngineSearches> SaveSearchEngineSearchAsync(string Url, string Keyword, int SearchEngineId, List<int> PositionNumbers);
        Task<bool> SaveSearchEngineSearchPositionAsync(int SearchEngineSearchId, List<int> PositionNumbers);
        Task<List<SearchResultsModel>> GetAllSearchResultsAsync();
        Task<SearchResultsModel> GetSearchResultFromIdAsync(int SearchEngineSearchId);
        Task<SearchResultsModel> GetSearchResultFromEntityAsync(SearchEngineSearches SearchEngineSearch);
        Task<List<SearchResultsModel>> GetSearchResultsFromIdsAsync(List<int> SearchEngineSearchIds);
        Task<List<SearchResultsModel>> GetSearchResultsFromEntitiesAsync(List<SearchEngineSearches> SearchEngineSearches);
        Task<List<SearchResultsModel>> GetSearchResultsFromUrlKeywordAndSearchedDateTimeAsync(string Url, string Keyword, DateTime SearchedDateTime);
        Task<List<string>> GetAllKeywordsUsedAsync();
        Task<List<string>> GetAllUrlsUsedAsync();
    }
}
