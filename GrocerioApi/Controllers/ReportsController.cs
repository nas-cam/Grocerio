using GrocerioApi.Services.Report;
using GrocerioModels.Report;
using GrocerioModels.Response;
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
    public class ReportsController : ControllerBase
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }
        #region BasicReports
        [HttpPost("CreateBasicReport")]
        [Authorize(Roles = "Admin")]
        public ActionResult<BasicReportModel> CreateBasicReport([FromBody]ReportParameters parameters)
        {
            var report = _reportService.CreateBasicReport(parameters);
            if (report == null) return NotFound(new StringResponse() { Message = "Invalid store id" });
            return Ok(report);
        }

        [HttpPost("SaveBasicReport")]
        [Authorize(Roles = "Admin")]
        public ActionResult<BasicReportModel> SaveBasicReport([FromBody] BasicReportModel report)
        {
            var resposne = _reportService.SaveBasicReport(report);
            if (resposne == null) return NotFound(new StringResponse() { Message = "Invalid store id" });
            return Ok(resposne);
        }

        [HttpGet("GetAllBasicReports/{storeId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<ReportRecord>> GetAllBasicReports(int storeId)
        {
            var resposne = _reportService.GetAllBasicReports(storeId);
            if (resposne == null) return NotFound(new StringResponse() { Message = "Invalid store id" });
            return Ok(resposne);
        }

        [HttpGet("GetBasicReportById/{reportId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<BasicReportModel> GetBasicReportById(int reportId)
        {
            var resposne = _reportService.GetBasicReportById(reportId);
            if (resposne == null) return NotFound(new StringResponse() { Message = "Invalid report id" });
            return Ok(resposne);
        }

        [HttpGet("RemoveBasicReport/{reportId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<BasicReportModel> RemoveBasicReport(int reportId)
        {
            var resposne = _reportService.RemoveBasicReport(reportId);
            if (!resposne ) return NotFound(new StringResponse() { Message = "Invalid report id" });
            return Ok(new StringResponse() { Message = "Basic report removed successfully" });
        }
        #endregion

        #region PremiumReports
        [HttpPost("CreatePremiumReport")]
        [Authorize(Roles = "Admin")]
        public ActionResult<BasicReportModel> CreatePremiumReport([FromBody] ReportParameters parameters)
        {
            var report = _reportService.CreatePremiumReport(parameters);
            if (report == null) return BadRequest(new StringResponse() { Message = "The store does either no longer exist, or is not a premium member store." });
            return Ok(report);
        }

        [HttpPost("SavePremiumReport")]
        [Authorize(Roles = "Admin")]
        public ActionResult<PremiumReportModel> SavePremiumReport([FromBody] PremiumReportModel report)
        {
            var resposne = _reportService.SavePremiumReport(report);
            if (resposne == null) return NotFound(new StringResponse() { Message = "The store does either no longer exist, or is not a premium member store." });
            return Ok(resposne);
        }

        [HttpGet("GetAllPremiumReports/{storeId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<List<ReportRecord>> GetAllPremiumReports(int storeId)
        {
            var resposne = _reportService.GetAllPremiumReports(storeId);
            if (resposne == null) return NotFound(new StringResponse() { Message = "Invalid store id" });
            return Ok(resposne);
        }

        [HttpGet("GetPremiumReportById/{reportId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<BasicReportModel> GetPremiumReportById(int reportId)
        {
            var resposne = _reportService.GetPremiumReportById(reportId);
            if (resposne == null) return NotFound(new StringResponse() { Message = "Invalid report id" });
            return Ok(resposne);
        }

        [HttpGet("RemovePremiumReport/{reportId}")]
        [Authorize(Roles = "Admin")]
        public ActionResult<BasicReportModel> RemovePremiumReport(int reportId)
        {
            var resposne = _reportService.RemovePremiumReport(reportId);
            if (!resposne) return NotFound(new StringResponse() { Message = "Invalid report id" });
            return Ok(new StringResponse() { Message = "Premium report removed successfully" });
        }

        #endregion

    }
}
