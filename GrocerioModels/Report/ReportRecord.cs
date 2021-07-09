using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Report
{
    public class ReportRecord
    {
        public int ReportId { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set;  }
        public string ReportName { get; set;  }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }
}
