using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngineKeywordTracker.DataAccessLayer.Entities
{
    public class SearchEngines
    {
        [Key]
        public int SearchEngineId { get; set; }
        public string SearchEngineName { get; set; }
        public string SearchUrl { get; set; }
    }
}
