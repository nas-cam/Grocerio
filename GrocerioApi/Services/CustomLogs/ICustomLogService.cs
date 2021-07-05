using GrocerioModels.Enums.General;
using GrocerioModels.Enums.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.CustomLogs
{
    public interface ICustomLogService
    {
        List<Database.Entities.PurchaseLog> GetPurchaseLogs(PurchaseState state, int logAmount, Sort sortDirection);
    }
}
