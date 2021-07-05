using GrocerioApi.Database.Context;
using GrocerioApi.Database.Entities;
using GrocerioModels.Enums.General;
using GrocerioModels.Enums.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.CustomLogs
{
    public class CustomLogService : ICustomLogService
    {
        private readonly GrocerioContext _context;

        public CustomLogService(GrocerioContext context)
        {
            _context = context;
        }

        public List<PurchaseLog> GetPurchaseLogs(PurchaseState state, int logAmount, Sort sortDirection)
        {
            var logsQuery = _context.PurchaseLogs.AsQueryable();           
            if (state == PurchaseState.Stored) logsQuery = logsQuery.Where(l => l.Stored);
            if (state == PurchaseState.PayedFor) logsQuery = logsQuery.Where(l => !l.Stored);
            
            switch (sortDirection)
            {
                case Sort.DESC:
                    return logsQuery.ToList().OrderByDescending(l => l.LogMade).Take(logAmount).ToList();
                case Sort.ASC:
                    return logsQuery.ToList().OrderBy(l => l.LogMade).Take(logAmount).ToList();
                default:
                    return new List<PurchaseLog>();
            }
        }
    }
}
