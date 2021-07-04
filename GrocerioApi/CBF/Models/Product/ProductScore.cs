using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.CBF.Models.Product
{
    public class ProductScore
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Score { get; set; }
    }
}
