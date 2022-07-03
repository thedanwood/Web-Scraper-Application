using SearchEngineKeywordTracker.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static SearchEngineKeywordTracker.Domain.Validation.CustomValidation;

namespace SearchEngineKeywordTracker.Application.Models
{
    public class SearchEngineSearchModel : SearchEngineSearchViewModel
    {
        [SearchEngineTypeListValidation]
        public List<int> SearchEngineTypes { get; set; }
        [SearchUrlValidation]
        public string SearchUrl { get; set; }
        [SearchKeywordListValidation]
        public List<string> SearchKeywords { get; set; }
    }
}
