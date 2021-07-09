using GrocerioApi.Services.Analytics;
using GrocerioModels.Analytics.Category;
using GrocerioModels.Analytics.Product;
using GrocerioModels.Analytics.ProductType;
using GrocerioModels.Analytics.Store;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AnalyticsController : ControllerBase
    {
        private readonly IAnalyticsService _analyticsService;

        public AnalyticsController(IAnalyticsService analyticsService)
        {
            _analyticsService = analyticsService;
        }

        [HttpGet("GetStoreAnalytics/{amount}")]
        public ActionResult<StoreAnalytics> GetStoreAnalytics(int amount = 10)
        {
            return _analyticsService.GetStoreAnalytics(amount);
        }

        [HttpGet("GetProductAnalytics/{amount}")]
        public ActionResult<ProductAnalytics> GetProductAnalytics(int amount = 10)
        {
            return _analyticsService.GetProductAnalytics(amount);
        }

        [HttpGet("GetCategoryAnalytics/{amount}")]
        public ActionResult<CategoryAnalytics> GetCategoryAnalytics(int amount = 10)
        {
            return _analyticsService.GetCategoryAnalytics(amount);
        }

        [HttpGet("GetProductTypeAnalytics/{amount}")]
        public ActionResult<ProductTypeAnalytics> GetProductTypeAnalytics(int amount = 10)
        {
            return _analyticsService.GetProductTypeAnalytics(amount);
        }

    }
}
