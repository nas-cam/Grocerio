using GrocerioModels.Enums.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.Requests.ReturnReason
{
    public class InsertReturnReasonRequest
    {
        public string Reason { get; set; }
        public Priority Seriousness { get; set; }
    }
}
