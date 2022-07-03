using SearchEngineKeywordTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.DataAccessLayer.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<DashboardFrequencies>> GetAllDashboardFrequenciesAsync();
    }
}
