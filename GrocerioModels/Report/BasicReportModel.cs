using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Report
{
    public class BasicReportModel
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string ReportName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public double Revenue { get; set; }
        public int ProductsSold { get; set; }
        public int ProductsReturned { get; set; }
        public int CurrentCartEntries { get; set; }
        public int CurrentTrackingEntries{ get; set; }
        public string TopProduct { get; set; }
    }
}
