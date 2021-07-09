using GrocerioModels.Enums.Store;
using GrocerioModels.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrocerioApi.Services.Report
{
    public interface IReportService
    {
        #region BasicReports
        BasicReportModel CreateBasicReport(ReportParameters parameters);
        BasicReportModel SaveBasicReport(BasicReportModel report);
        List<ReportRecord> GetAllBasicReports(int storeId);
        BasicReportModel GetBasicReportById(int reportId);
        bool RemoveBasicReport(int reportId);
        #endregion

        #region PreimumReports
        PremiumReportModel CreatePremiumReport(ReportParameters parameters);
        PremiumReportModel SavePremiumReport(PremiumReportModel report);
        List<ReportRecord> GetAllPremiumReports(int storeId);
        PremiumReportModel GetPremiumReportById(int reportId);
        bool RemovePremiumReport(int reportId);
        #endregion
    }
}
