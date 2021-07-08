using GrocerioModels.Enums.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Database.Entities
{
    public class ReturnReason
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public Priority Seriousness { get; set; }
    }
}
