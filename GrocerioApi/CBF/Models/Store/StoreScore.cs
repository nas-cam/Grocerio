using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.CBF.Models.Store
{
    public class StoreScore
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public double Score { get; set; }
    }
}
