using SearchEngineKeywordTracker.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.DataAccessLayer.Interfaces
{
    public interface ISearchEngineRepository
    {
        Task<List<SearchEngines>> GetAllSearchEnginesAsync();
        Task<SearchEngines> GetSearchEngineByIdAsync(int Id);
        Task<bool> DoesSearchEngineTypeExistAsync(int Id);
        Task<Regex> GetSearchEngineRegexByIdAsync(int Id);
    }
}
