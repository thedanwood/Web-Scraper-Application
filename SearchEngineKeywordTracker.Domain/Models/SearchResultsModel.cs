using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.Domain.Models
{
    public class SearchResultsModel
    {
        public string Keyword { get; set; }
        public string Url { get; set; }
        public string SearchEngineName { get; set; }
        public List<int> PositionNumbers { get; set; }
        public string SearchedDateTime { get; set; }
    }
}
