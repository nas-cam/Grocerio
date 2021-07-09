using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Database.Entities
{
    public class BasicReport
    {
        public int Id { get; set; }

        [ForeignKey("Store")]
        public int StoreId { get; set; }
        public Store Store{ get; set; }

        public string ReportName { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public double Revenue { get; set; }
        public int ProductsSold { get; set; }
        public int ProductsReturned { get; set; }
        public int CurrentCartEntries { get; set; }
        public int CurrentTrackingEntries { get; set; }
        public string TopProduct { get; set; }
    }
}
