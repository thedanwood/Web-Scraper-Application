using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Services.Interfaces
{
    public interface ISearchEngineService
    {
        Task<string> FormatKeywordFromSearchEngineIdAsync(int Id, string Keyword);
        Task<string> FormatUrlWithKeywordParamaterFromSearchEngineIdAsync(string Keyword, int Id);
        Task<string> FormatSearchUrlWithPageResultsCountAsync(string Url, int Id);
        Task<string> FormatFullSearchUrlAsync(int Id, string Keyword);
    }
}
