using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.DataAccessLayer.Entities
{
    public class SearchEngineSearchPositions
    {
        [Key]
        public int SearchEngineSearchPositionId { get; set; }
        [ForeignKey("SearchEngineSearches")]
        public int SearchEngineSearchId { get; set; }
        public int PositionNumber { get; set; }
        public virtual SearchEngineSearches SearchEngineSearches { get; set; }
    }
}
