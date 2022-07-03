using Microsoft.EntityFrameworkCore;
using SearchEngineKeywordTracker.Application.Interfaces;
using SearchEngineKeywordTracker.DataAccessLayer.Contexts;
using SearchEngineKeywordTracker.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Application.Repositories
{
    public class SearchEngineRepository : ISearchEngineRepository
    {
        private readonly AppDbContext _ctx;
        public SearchEngineRepository(AppDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<SearchEngines>> GetAllSearchEnginesAsync()
        {
            List<SearchEngines> searchEngines = await _ctx.SearchEngines.ToListAsync();
            return searchEngines;
        }

        public async Task<SearchEngines> GetSearchEngineByIdAsync(int Id)
        {
            SearchEngines searchEngine = await _ctx.SearchEngines.FirstOrDefaultAsync(r => r.SearchEngineID == Id);
            return searchEngine;
        }
        //public async Task<bool> DoesSearchEngineExist(int searchEngineID)
        //{
        //    bool doesExist = await _ctx.SearchEngines.AnyAsync(r => r.SearchEngineID == searchEngineID);
        //    return doesExist;
        //}
    }
}
