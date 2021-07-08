using GrocerioModels.Enums.General;
using System;
using System.Collections.Generic;
using System.Text;

namespace GrocerioModels.ReturnReason
{
    public class ReturnReasonModel
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public Priority Seriousness { get; set; }
        public string StringSeriousness { get; set; }
    }
}
