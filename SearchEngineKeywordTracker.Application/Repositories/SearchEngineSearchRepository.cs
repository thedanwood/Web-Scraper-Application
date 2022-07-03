using SearchEngineKeywordTracker.DataAccessLayer.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Application.Repositories
{
    public class SearchEngineSearchRepository
    {
        public class SearchEngineSearchRespository
        {
            private readonly AppDbContext _ctx;
            public SearchEngineSearchRespository(AppDbContext ctx)
            {
                _ctx = ctx;
            }
        }
    }
}
