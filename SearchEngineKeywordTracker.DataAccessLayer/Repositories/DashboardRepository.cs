using SearchEngineKeywordTracker.DataAccessLayer.Interfaces;
using SearchEngineKeywordTracker.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.DataAccessLayer.Repositories
{
    public class DashboardRepository : IDashboardRepository
    {
        #region read methods
        public async Task<List<DashboardFrequencies>> GetAllDashboardFrequenciesAsync()
        {
            List<DashboardFrequencies> dashboardFrequencyList = Enum.GetValues(typeof(DashboardFrequencies)).Cast<DashboardFrequencies>().ToList();
            return dashboardFrequencyList;
        }
        #endregion
    }
}
