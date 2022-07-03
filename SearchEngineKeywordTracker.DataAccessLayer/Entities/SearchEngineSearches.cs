using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.DataAccessLayer.Entities
{
    public class SearchEngineSearches
    {
        [Key]
        public int SearchEngineSearchId { get; set; }
        public string Keyword { get; set; }
        public string Url { get; set; }
        public DateTime SearchDateTime { get; set; }
        [ForeignKey("SearchEngines")]
        public int SearchEngineId { get; set; }
        public virtual SearchEngines SearchEngines { get; set; }
    }
}
