using Microsoft.EntityFrameworkCore;
using SearchEngineKeywordTracker.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.DataAccessLayer.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<SearchEngineSearches> SearchEngineSearches { get; set; }
        public DbSet<SearchEngineSearchPositions> SearchEngineSearchPositions { get; set; }
        public DbSet<SearchEngines> SearchEngines { get; set; }
    }
}
