using GrocerioApi.Database.Context;
using GrocerioModels.Requests.ReturnReason;
using GrocerioModels.Response;
using GrocerioModels.ReturnReason;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.ReturnReson
{
    public class ReturnReasonService : IReturnReasonService
    {
        private readonly GrocerioContext _context;
        public ReturnReasonService(GrocerioContext context)
        {
            _context = context;
        }

        public ReturnReasonModel Insert(InsertReturnReasonRequest request)
        {
            var newReason = new Database.Entities.ReturnReason()
            {
                Reason = request.Reason, 
                Seriousness = request.Seriousness
            };
            _context.Add(newReason);
            _context.SaveChanges();

            return new ReturnReasonModel()
            {
                Id = newReason.Id, 
                Reason = newReason.Reason, 
                Seriousness = newReason.Seriousness, 
                StringSeriousness = newReason.Seriousness.ToString().ToLower()
            };
        }

        public List<ReturnReasonModel> GetReturnReasons()
        {
            var dbReasons = _context.ReturnReasons.ToList();
            var reasons = new List<ReturnReasonModel>();
            foreach (var reason in dbReasons)
                reasons.Add(new ReturnReasonModel() { 
                    Id = reason.Id, 
                    Reason = reason.Reason, 
                    Seriousness = reason.Seriousness, 
                    StringSeriousness = reason.Seriousness.ToString().ToLower()
                });
            return reasons;
        }

        public ReturnReasonModel GetById(int returnReasonId)
        {
            var returnReason = _context.ReturnReasons.SingleOrDefault(r => r.Id == returnReasonId);
            if (returnReason == null) return null;

            return new ReturnReasonModel()
            {
                Id = returnReason.Id, 
                Reason = returnReason.Reason, 
                Seriousness = returnReason.Seriousness, 
                StringSeriousness = returnReason.Seriousness.ToString().ToLower()
            };
        }

        public ReturnReasonModel UpdateReturnReason(int returnReasonId, InsertReturnReasonRequest request)
        {
            var returnReason = _context.ReturnReasons.SingleOrDefault(r => r.Id == returnReasonId);
            if (returnReason == null) return null;
            returnReason.Reason = request.Reason;
            returnReason.Seriousness = request.Seriousness;

            _context.SaveChanges();
            return new ReturnReasonModel()
            {
                Id = returnReason.Id,
                Seriousness = returnReason.Seriousness,
                Reason = returnReason.Reason,
                StringSeriousness = returnReason.Seriousness.ToString().ToLower()
            };           
        }

        public StringResponse RemoveReturnReason(int returnReasonId)
        {
            var returnReason = _context.ReturnReasons.SingleOrDefault(r => r.Id == returnReasonId);
            if (returnReason == null) return null;

            _context.ReturnReasons.Remove(returnReason);
            _context.SaveChanges();
            return new StringResponse() { Message = "Return reason removed successfully" };
        }
    }
}
