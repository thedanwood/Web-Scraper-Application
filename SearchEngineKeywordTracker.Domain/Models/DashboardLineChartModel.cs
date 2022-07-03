using System.Collections.Generic;

namespace SearchEngineKeywordTracker.Domain.Models
{
    public class DashboardLineChartData
    {
        public string SearchEngineName { get; set; }
        public List<int> AveragePositionNumbers { get; set; }
    }
    public class DashboardLineChartModel
    {
        public List<string> SearchedDateTimes { get; set; }
        public List<DashboardLineChartData> ChartDataList { get; set; }
    }
}
