using SearchEngineKeywordTracker.DataAccessLayer.Entities;
using SearchEngineKeywordTracker.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SearchEngineKeywordTracker.Application.ViewModels
{
    public class DashboardViewModel
    {
        public List<string> Urls { get; set; }
        public List<string> Keywords { get; set; }
        public List<DashboardFrequencies> DashboardFrequencies { get; set; }
    }
}
