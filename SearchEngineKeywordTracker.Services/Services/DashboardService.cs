using SearchEngineKeywordTracker.DataAccessLayer.Entities;
using SearchEngineKeywordTracker.DataAccessLayer.Interfaces;
using SearchEngineKeywordTracker.Domain.Enums;
using SearchEngineKeywordTracker.Domain.Interfaces;
using SearchEngineKeywordTracker.Domain.Models;
using SearchEngineKeywordTracker.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly ISearchEngineRepository _searchEngineRepository;
        private readonly ISearchEngineSearchBusinessLogic _searchEngineSearchBusinessLogic;
        private readonly ISearchEngineSearchRepository _searchEngineSearchRepository;
        private readonly ISearchEngineSearchService _searchEngineSearchService;
        public DashboardService(ISearchEngineRepository searchEngineRepository, ISearchEngineSearchBusinessLogic searchEngineSearchBusinessLogic, ISearchEngineSearchRepository searchEngineSearchRepository, ISearchEngineSearchService searchEngineSearchService)
        {
            _searchEngineRepository = searchEngineRepository;
            _searchEngineSearchBusinessLogic = searchEngineSearchBusinessLogic;
            _searchEngineSearchRepository = searchEngineSearchRepository;
            _searchEngineSearchService= searchEngineSearchService;
        }
        public async Task<List<DateTime>> GetDashboardLineChartDateList(int FrequencyEnumInt)
        {
            List<DateTime> datesForChart = new List<DateTime>();
            switch (FrequencyEnumInt)
            {
                case (int)DashboardFrequencies.OneWeek:
                default:
                    DateTime fromDate = DateTime.Now.AddDays(-6);
                    DateTime today = DateTime.Now;
                    for (DateTime date = fromDate; date.Date <= today.Date; date = date.AddDays(1))
                    {
                        datesForChart.Add(date);
                    }
                    break;
            }
            return datesForChart;
        }
        public async Task<DashboardLineChartModel> GetDashboardLineChartModel(string Keyword, string Url, int FrequencyEnumInt)
        {
            List<DateTime> datesForChart = await GetDashboardLineChartDateList(FrequencyEnumInt);
            DashboardLineChartModel dashboardChartDataList = new DashboardLineChartModel() { 
                SearchedDateTimes = datesForChart.Select(async r => await _searchEngineSearchBusinessLogic.FormatSearchedDatetimeForDisplay(r, false)).Select(r=>r.Result).ToList(),
                ChartDataList = new List<DashboardLineChartData>()
            };
            List<SearchEngines> searchEngines = await _searchEngineRepository.GetAllSearchEnginesAsync();
            foreach (SearchEngines searchEngine in searchEngines)
            {
                //could only run if values found to improve performance?
                DashboardLineChartData dashboardLineChartData = new DashboardLineChartData()
                {
                    SearchEngineName = searchEngine.SearchEngineName,
                    AveragePositionNumbers = new List<int>()
                };
                foreach (DateTime date in datesForChart)
                {
                    List<SearchResultsModel> searchResults = await _searchEngineSearchRepository.GetSearchResultsFromUrlKeywordAndSearchedDateTimeAsync(Url, Keyword, date);
                    List<int> averagePositions = searchResults.Select(async r => await _searchEngineSearchService.GetAveragePositionOfSearchResultAsync(r)).Select(r => r.Result).ToList();
                    int averagePosition = await _searchEngineSearchService.GetAveragePositionFromListPositionsAsync(averagePositions);
                    dashboardLineChartData.AveragePositionNumbers.Add(averagePosition);
                }
                dashboardChartDataList.ChartDataList.Add(dashboardLineChartData);   
            }
            return dashboardChartDataList;
        }
    }
}
