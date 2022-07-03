using SearchEngineKeywordTracker.DataAccessLayer.Entities;
using SearchEngineKeywordTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Services.Interfaces
{
    public interface ISearchEngineSearchService
    {
        Task<List<int>> GetKeywordPositionsAsync(int SearchEngineId, string Keyword, string Url);
        Task<List<Match>> GetKeywordMatchListAsync(Regex RegexPattern, string Url, string Keyword);
        Task<int> GetAveragePositionOfSearchResultAsync(SearchResultsModel searchResult);
        Task<int> GetAveragePositionFromListPositionsAsync(List<int> Positions);
    }
}
