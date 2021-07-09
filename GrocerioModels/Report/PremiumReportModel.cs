using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Report
{
    public class PremiumReportModel : BasicReportModel
    {
        public string MainReturnReason { get; set; }
        public double SuccessRate { get; set; }
        public string MostPopularClientAddress { get; set; }
        public string MostPopularCategory { get; set; }
        public string MostPopularProductType { get; set; }
    }
}
