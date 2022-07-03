using System;
using System.Collections.Generic;
using SearchEngineKeywordTracker.Application.Models;
using SearchEngineKeywordTracker.DataAccessLayer.Entities;
using SearchEngineKeywordTracker.Domain.Validation;

namespace SearchEngineKeywordTracker.Application.ViewModels
{
    public class SearchEngineSearchViewModel
    {
        public List<SearchEngines> AllowedSearchEngineTypes { get; set; }
    }
}
