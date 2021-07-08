using GrocerioModels.Requests.ReturnReason;
using GrocerioModels.Response;
using GrocerioModels.ReturnReason;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.ReturnReson
{
    public interface IReturnReasonService
    {
        ReturnReasonModel Insert(InsertReturnReasonRequest request);
        List<ReturnReasonModel> GetReturnReasons();
        ReturnReasonModel GetById(int returnReasonId);
        ReturnReasonModel UpdateReturnReason(int returnReasonId, InsertReturnReasonRequest request);
        public StringResponse RemoveReturnReason(int returnReasonId);
    }
}
