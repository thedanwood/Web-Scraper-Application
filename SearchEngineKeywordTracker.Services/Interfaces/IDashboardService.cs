using SearchEngineKeywordTracker.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<List<DateTime>> GetDashboardLineChartDateList(int FrequencyEnumInt);
        Task<DashboardLineChartModel> GetDashboardLineChartModel(string Keyword, string Url, int FrequencyEnumInt);
    }
}
