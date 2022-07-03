using SearchEngineKeywordTracker.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Domain.BusinessLogic
{
    public class SearchEngineSearchBusinessLogic : ISearchEngineSearchBusinessLogic
    {
        public int SearchResultsCountLimit { get; } = 100;
        public string DefaultKeywordSelectedForSearch { get; } = "land registry search";
        public string DefaultUrlSelectedForSearch { get; } = "www.infotrack.co.uk";
        public async Task<string> FormatSearchedDatetimeForDisplay(DateTime SearchedDateTime, bool IncludesTime)
        {
            string dateTimeFormatting = "dd/MM/yy";
            dateTimeFormatting = IncludesTime ? dateTimeFormatting + " HH:mm" : dateTimeFormatting;
            string formattedDateTime = SearchedDateTime.ToString(dateTimeFormatting);
            return formattedDateTime;
        }
    }
}
