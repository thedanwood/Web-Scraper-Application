using Microsoft.EntityFrameworkCore;
using SearchEngineKeywordTracker.DataAccessLayer.Contexts;
using SearchEngineKeywordTracker.DataAccessLayer.Entities;
using SearchEngineKeywordTracker.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.DataAccessLayer.Repositories
{
    public class SearchEngineRepository : ISearchEngineRepository
    {
        private readonly AppDbContext _ctx;
        public SearchEngineRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }
        #region read methods
        public async Task<List<SearchEngines>> GetAllSearchEnginesAsync()
        {
            List<SearchEngines> searchEngines = await _ctx.SearchEngines.ToListAsync();
            return searchEngines;
        }
        public async Task<SearchEngines> GetSearchEngineByIdAsync(int Id)
        {
            SearchEngines searchEngine = await _ctx.SearchEngines.FirstOrDefaultAsync(r => r.SearchEngineId == Id);
            return searchEngine;
        }
        public async Task<bool> DoesSearchEngineTypeExistAsync(int Id)
        {
            bool doesExist = await _ctx.SearchEngines.AnyAsync(r => r.SearchEngineId == Id);
            return doesExist;
        }
        public async Task<Regex> GetSearchEngineRegexByIdAsync(int Id)
        {
            SearchEngines searchEngine = await GetSearchEngineByIdAsync(Id);
            switch (searchEngine.SearchEngineName)
            {
                case "Google":
                default:
                    return new Regex("(?<=(=\"Gx5Zad).{1,150}?(url\\?q=)).*?(?=\">)");
                    break;
            }
        }
        #endregion
    }
}
