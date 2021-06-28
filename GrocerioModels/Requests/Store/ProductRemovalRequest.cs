using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Requests.Store
{
    public class ProductRemovalRequest
    {
        public List<int> ProductIds { get; set; }
    }
}
