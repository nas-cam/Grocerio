using GrocerioApi.Database.Context;
using GrocerioModels.Enums.Store;
using GrocerioModels.Report;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.Report
{
    public class ReportService : IReportService
    {
        private readonly GrocerioContext _context;

        public ReportService(GrocerioContext context)
        {
            _context = context;
        }

        #region PrivateMethods
        public string GetTopProduct(Database.Entities.Store store, ReportParameters parameters)
        {
            List<string> products = _context.PurchaseLogs
                                             .Select(x => new { x.PurchaseDate, x.Store, x.StoreCity, x.StoreAddress, x.Returned, x.Product })
                                             .Where(p => p.PurchaseDate.Date >= parameters.From.Date && p.PurchaseDate.Date <= parameters.To.Date &&
                                                    p.Store.ToLower() == store.Name.ToLower() &&
                                                    p.StoreCity.ToLower() == store.City.ToLower() &&
                                                    p.StoreAddress.ToLower() == store.Address.ToLower())
                                             .Select(p => p.Product)
                                             .ToList();

            if (products.Count == 0) return "None";

            int topProductCounter = 0;
            string topProduct = products[0];

            foreach(var product in products.Distinct().ToList())
            {
                int currentCounter = 0;
                foreach (var productEntry in products) if (product.ToLower() == productEntry.ToLower()) currentCounter++;
                if(currentCounter > topProductCounter)
                {
                    topProductCounter = currentCounter;
                    topProduct = product;
                }
            }

            return topProduct;
        }

        public string GetMostPopularCategory(List<Database.Entities.PurchaseLog> logs)
        {
            if (logs.Count == 0) return "None";
            List<string> categories = logs.Select(l => l.Category).ToList();
            if (categories.Count == 0) return "None";

            int topCategoryCounter = 0;
            string topCategory = categories[0];

            foreach (var category in categories.Distinct().ToList())
            {
                int currentCounter = 0;
                foreach (var categoryEntry in categories) if (category.ToLower() == categoryEntry.ToLower()) currentCounter++;
                if (currentCounter > topCategoryCounter)
                {
                    topCategoryCounter = currentCounter;
                    topCategory = category;
                }
            }

            return topCategory;
        }

        public string GetMostPopularProductType(List<Database.Entities.PurchaseLog> logs)
        {
            if (logs.Count == 0) return "None";
            List<string> types = logs.Select(l => l.ProductType).ToList();
            if (types.Count == 0) return "None";

            int topTypeCounter = 0;
            string topType = types[0];

            foreach (var type in types.Distinct().ToList())
            {
                int currentCounter = 0;
                foreach (var typeEntry in types) if (type.ToLower() == typeEntry.ToLower()) currentCounter++;
                if (currentCounter > topTypeCounter)
                {
                    topTypeCounter = currentCounter;
                    topType = type;
                }
            }

            return topType;
        }

        public string GetMostPopularClientAddress(List<Database.Entities.PurchaseLog> logs)
        {
            if (logs.Count == 0) return "None";
            List<string> addresses = logs.Select(l => l.ShippingAddress).ToList();
            if (addresses.Count == 0) return "None";

            int topAddressCounter = 0;
            string topAddress = addresses[0];

            foreach (var address in addresses.Distinct().ToList())
            {
                int currentCounter = 0;
                foreach (var addressEntry in addresses) if (address.ToLower() == addressEntry.ToLower()) currentCounter++;
                if (currentCounter > topAddressCounter)
                {
                    topAddressCounter = currentCounter;
                    topAddress = address;
                }
            }

            return topAddress;
        }

        public string GetMainReturnReason(List<Database.Entities.PurchaseLog> logs)
        {
            if (logs.Count == 0) return "None";
            List<string> returnReasons = logs.Select(l => l.ReturnReason).ToList();
            if (returnReasons.Count == 0) return "None";

            int topReturnReasonCounter = 0;
            string topReturnReason = returnReasons[0];

            foreach (var reason in returnReasons.Distinct().ToList())
            {
                int currentCounter = 0;
                foreach (var reasonEntry in returnReasons) if (reason.ToLower() == reasonEntry.ToLower()) currentCounter++;
                if (currentCounter > topReturnReasonCounter)
                {
                    topReturnReasonCounter = currentCounter;
                    topReturnReason = reason;
                }
            }
            return topReturnReason;
        }

        public double CalculateSuccessRate(List<Database.Entities.PurchaseLog> logs)
        {
            if (logs.Count == 0) return 0;
            var sold = logs.Where(l => !l.Returned).ToList().Count;
            if (sold == 0) return 0;

            return Math.Round(Convert.ToDouble((Convert.ToDouble(sold) / logs.Count) * 100), 2);
        }
        #endregion

        #region BasicReports
        public BasicReportModel CreateBasicReport(ReportParameters parameters)
        {
            var store = _context.Stores.SingleOrDefault(s => s.Id == parameters.StoreId);
            if (store == null) return null;


            return new BasicReportModel()
            {
                StoreId = parameters.StoreId,
                ReportName = parameters.Name,
                StoreName = store.Name,
                From = parameters.From,
                To = parameters.To,
                CurrentCartEntries = _context.ShoppingCart
                                    .Include(c => c.StoreProduct)
                                    .ThenInclude(sp => sp.Store)
                                    .Select(x => new { x.StoreProduct, x.AddedIn })
                                    .Where(c => c.StoreProduct.StoreId == parameters.StoreId && c.AddedIn.Date >= parameters.From.Date && c.AddedIn.Date <= parameters.To.Date)
                                    .ToList()
                                    .Count,
                CurrentTrackingEntries = _context.Trackings
                                    .Select(x => new { x.Purchased, x.Store, x.StoreCity, x.StoreAddress })
                                    .Where(t => t.Purchased.Date >= parameters.From.Date && t.Purchased.Date <= parameters.To.Date &&
                                           t.Store.ToLower() == store.Name.ToLower() &&
                                           t.StoreCity.ToLower() == store.City.ToLower() &&
                                           t.StoreAddress.ToLower() == store.Address.ToLower())
                                    .ToList()
                                    .Count,
                ProductsReturned = _context.PurchaseLogs
                                    .Select(x => new { x.LogMade, x.Store, x.StoreCity, x.StoreAddress, x.Returned })
                                    .Where(l => l.LogMade.Date >= parameters.From.Date && l.LogMade.Date <= parameters.To.Date &&
                                           l.Store.ToLower() == store.Name.ToLower() &&
                                           l.StoreCity.ToLower() == store.City.ToLower() &&
                                           l.StoreAddress.ToLower() == store.Address.ToLower() &&
                                           l.Returned)
                                    .ToList()
                                    .Count, 
                ProductsSold = _context.PurchaseLogs
                                    .Select(x => new { x.LogMade, x.Store, x.StoreCity, x.StoreAddress, x.Returned })
                                    .Where(l => l.LogMade.Date >= parameters.From.Date && l.LogMade.Date <= parameters.To.Date &&
                                           l.Store.ToLower() == store.Name.ToLower() &&
                                           l.StoreCity.ToLower() == store.City.ToLower() &&
                                           l.StoreAddress.ToLower() == store.Address.ToLower() &&
                                           !l.Returned)
                                    .ToList()
                                    .Count, 
                Revenue = _context.Purchases
                                    .Select(x => new { x.PurchaseDate, x.Store, x.StoreCity, x.StoreAddress, x.Total })
                                    .Where(p => p.PurchaseDate.Date >= parameters.From.Date && p.PurchaseDate.Date <= parameters.To.Date &&
                                           p.Store.ToLower() == store.Name.ToLower() &&
                                           p.StoreCity.ToLower() == store.City.ToLower() &&
                                           p.StoreAddress.ToLower() == store.Address.ToLower())
                                    .ToList()
                                    .Sum(p => p.Total), 
                TopProduct = GetTopProduct(store, parameters)
            };
        }

        public BasicReportModel SaveBasicReport(BasicReportModel report)
        {
            var store = _context.Stores.SingleOrDefault(s => s.Id == report.StoreId);
            if (store == null) return null;

            var sameParameters = _context.BasicReports.SingleOrDefault(r => r.ReportName == report.ReportName && r.From.Date == report.From.Date && r.To.Date == report.To.Date);
            if(sameParameters != null)
            {
                Random randomGenerator = new Random();
                report.ReportName = report.ReportName + randomGenerator.Next(1, 1000).ToString();
            }

            _context.BasicReports.Add(new Database.Entities.BasicReport()
            {
                CurrentCartEntries = report.CurrentCartEntries, 
                CurrentTrackingEntries = report.CurrentTrackingEntries, 
                From = report.From, 
                ProductsReturned = report.ProductsReturned, 
                ProductsSold = report.ProductsSold, 
                ReportName = report.ReportName, 
                Revenue = report.Revenue, 
                StoreId = report.StoreId, 
                To = report.To, 
                TopProduct = report.TopProduct
            });

            _context.SaveChanges();
            return report;
        }

        public List<ReportRecord> GetAllBasicReports(int storeId)
        {
            var store = _context.Stores.SingleOrDefault(s => s.Id == storeId);
            if (store == null) return null;

            List<ReportRecord> response = new List<ReportRecord>();
                         
                foreach(var report in _context.BasicReports
                                               .Include(r=>r.Store)
                                               .Select(x=>new { StoreName = x.Store.Name, x.StoreId, x.From, x.To, x.ReportName, x.Id})
                                               .Where(r => r.StoreId == storeId)
                                               .ToList())
                    response.Add(new ReportRecord()
                    {
                        From = report.From, 
                        ReportId = report.Id, 
                        ReportName = report.ReportName, 
                        StoreId = report.StoreId, 
                        StoreName = report.StoreName, 
                        To = report.To
                    });
                
                return response;
            }

        public BasicReportModel GetBasicReportById(int reportId)
        {
            var report = _context.BasicReports
                                 .Include(r => r.Store)
                                 .Select(x => new { ReportData = x, StoreName = x.Store.Name })
                                 .SingleOrDefault(r => r.ReportData.Id == reportId);

            if (report == null) return null;

            return new BasicReportModel()
            {
                CurrentCartEntries = report.ReportData.CurrentCartEntries, 
                CurrentTrackingEntries = report.ReportData.CurrentTrackingEntries, 
                From = report.ReportData.From, 
                ProductsReturned = report.ReportData.ProductsReturned, 
                ProductsSold = report.ReportData.ProductsSold, 
                ReportName = report.ReportData.ReportName, 
                Revenue = report.ReportData.Revenue, 
                StoreId = report.ReportData.StoreId, 
                StoreName = report.StoreName, 
                To = report.ReportData.To, 
                TopProduct = report.ReportData.TopProduct
            };
        }

        public bool RemoveBasicReport(int reportId)
        {
            var report = _context.BasicReports.SingleOrDefault(r => r.Id == reportId);
            if (report == null) return false;

            _context.BasicReports.Remove(report);
            _context.SaveChanges();
            return true;
        }
        #endregion

        #region PreimumReports
        public PremiumReportModel CreatePremiumReport(ReportParameters parameters)
        {
            #region Validation
            var store = _context.Stores.SingleOrDefault(s => s.Id == parameters.StoreId);
            if (store == null) return null;
            if (store.Membership == Membership.Basic) return null;
            var basicReport = CreateBasicReport(parameters);
            if (basicReport == null) return null;
            #endregion

            var logs = _context.PurchaseLogs
                               .Where(p => p.PurchaseDate.Date >= parameters.From.Date && p.PurchaseDate.Date <= parameters.To.Date &&
                                           p.Store.ToLower() == store.Name.ToLower() &&
                                           p.StoreCity.ToLower() == store.City.ToLower() &&
                                           p.StoreAddress.ToLower() == store.Address.ToLower())
                               .ToList();

            return new PremiumReportModel()
            {
                CurrentCartEntries = basicReport.CurrentCartEntries,
                CurrentTrackingEntries = basicReport.CurrentTrackingEntries,
                From = basicReport.From,
                ProductsReturned = basicReport.ProductsReturned,
                ProductsSold = basicReport.ProductsSold,
                ReportName = basicReport.ReportName,
                Revenue = basicReport.Revenue,
                StoreId = parameters.StoreId,
                StoreName = basicReport.StoreName,
                To = basicReport.To,
                TopProduct = basicReport.TopProduct,
                MostPopularCategory = GetMostPopularCategory(logs),
                MostPopularProductType = GetMostPopularProductType(logs),
                MostPopularClientAddress = GetMostPopularClientAddress(logs),
                MainReturnReason = GetMainReturnReason(logs),
                SuccessRate = CalculateSuccessRate(logs)
            };
        }

        public PremiumReportModel SavePremiumReport(PremiumReportModel report)
        {

            #region Validation
            var store = _context.Stores.SingleOrDefault(s => s.Id == report.StoreId);
            if (store == null) return null;
            if (store.Membership == Membership.Basic) return null;
            #endregion

            var sameParameters = _context.PremiumReports.SingleOrDefault(r => r.ReportName == report.ReportName && r.From.Date == report.From.Date && r.To.Date == report.To.Date);
            if (sameParameters != null)
            {
                Random randomGenerator = new Random();
                report.ReportName = report.ReportName + randomGenerator.Next(1, 1000).ToString();
            }

            _context.PremiumReports.Add(new Database.Entities.PremiumReport()
            {
                CurrentCartEntries = report.CurrentCartEntries,
                CurrentTrackingEntries = report.CurrentTrackingEntries,
                From = report.From,
                ProductsReturned = report.ProductsReturned,
                ProductsSold = report.ProductsSold,
                ReportName = report.ReportName,
                Revenue = report.Revenue,
                StoreId = report.StoreId,
                To = report.To,
                TopProduct = report.TopProduct,
                 MainReturnReason = report.MainReturnReason, 
                MostPopularCategory = report.MostPopularCategory, 
                MostPopularClientAddress = report.MostPopularClientAddress, 
                MostPopularProductType = report.MostPopularProductType, 
                SuccessRate = report.SuccessRate                
            });
            _context.SaveChanges();

            return report;
        }

        public List<ReportRecord> GetAllPremiumReports(int storeId)
        {
            var store = _context.Stores.SingleOrDefault(s => s.Id == storeId);
            if (store == null) return null;

            List<ReportRecord> response = new List<ReportRecord>();

            foreach (var report in _context.PremiumReports
                                           .Include(r => r.Store)
                                           .Select(x => new { StoreName = x.Store.Name, x.StoreId, x.From, x.To, x.ReportName, x.Id })
                                           .Where(r => r.StoreId == storeId)
                                           .ToList())
                response.Add(new ReportRecord()
                {
                    From = report.From,
                    ReportId = report.Id,
                    ReportName = report.ReportName,
                    StoreId = report.StoreId,
                    StoreName = report.StoreName,
                    To = report.To
                });

            return response;
        }

        public PremiumReportModel GetPremiumReportById(int reportId)
        {
            var report = _context.PremiumReports
                                 .Include(r => r.Store)
                                 .Select(x => new { ReportData = x, StoreName = x.Store.Name })
                                 .SingleOrDefault(r => r.ReportData.Id == reportId);

            if (report == null) return null;

            return new PremiumReportModel()
            {
                CurrentCartEntries = report.ReportData.CurrentCartEntries,
                CurrentTrackingEntries = report.ReportData.CurrentTrackingEntries,
                From = report.ReportData.From,
                ProductsReturned = report.ReportData.ProductsReturned,
                ProductsSold = report.ReportData.ProductsSold,
                ReportName = report.ReportData.ReportName,
                Revenue = report.ReportData.Revenue,
                StoreId = report.ReportData.StoreId,
                StoreName = report.StoreName,
                To = report.ReportData.To,
                TopProduct = report.ReportData.TopProduct, 
                SuccessRate = report.ReportData.SuccessRate, 
                MostPopularProductType = report.ReportData.MostPopularProductType, 
                MostPopularClientAddress = report.ReportData.MostPopularClientAddress, 
                MostPopularCategory = report.ReportData.MostPopularCategory, 
                MainReturnReason = report.ReportData.MainReturnReason
            };
        }

        public bool RemovePremiumReport(int reportId)
        {
            var report = _context.PremiumReports.SingleOrDefault(r => r.Id == reportId);
            if (report == null) return false;

            _context.PremiumReports.Remove(report);
            _context.SaveChanges();
            return true;
        }
        #endregion
    }
}
