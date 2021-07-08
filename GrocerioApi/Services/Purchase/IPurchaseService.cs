using GrocerioModels.Purchase;
using GrocerioModels.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.Purchase
{
    public interface IPurchaseService
    {
        List<TrackingModel> GetTrackingItems(int userId);
        BoolResponse RefundTrackingItem(int userId, int trackingItemId);
        void MoveTrackingItems();
        List<PurchaseModel> GetPurchasedItems(int userId);
        BoolResponse ReturnPurchasedItem(int userId, int purchasedItemId, int returnReasonId);
    }
}
