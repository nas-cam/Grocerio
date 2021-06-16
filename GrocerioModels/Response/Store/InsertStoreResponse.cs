using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Response.Store
{
    public class InsertStoreResponse : BoolResponse
    {
        public GrocerioModels.Store.Store Store { get; set; }
    }
}
