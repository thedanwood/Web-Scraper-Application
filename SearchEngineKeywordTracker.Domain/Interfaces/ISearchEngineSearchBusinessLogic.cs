using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Domain.Interfaces
{
    public interface ISearchEngineSearchBusinessLogic
    {
        int SearchResultsCountLimit { get; }
        string DefaultKeywordSelectedForSearch { get; }
        string DefaultUrlSelectedForSearch { get; }
        Task<string> FormatSearchedDatetimeForDisplay(DateTime SearchedDateTime, bool IncludesTime);
    }
}
