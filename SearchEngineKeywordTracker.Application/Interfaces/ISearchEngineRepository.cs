using SearchEngineKeywordTracker.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Application.Interfaces
{
    public interface ISearchEngineRepository
    {
        Task<List<SearchEngines>> GetAllSearchEnginesAsync();
        Task<SearchEngines> GetSearchEngineByIdAsync(int Id);
    }
}
