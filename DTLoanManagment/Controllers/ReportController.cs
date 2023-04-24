using DTLoanManagment.Models.Common.Response;
using DTLoanManagment.Models.Loan;
using DTLoanManagment.Repository.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DTLoanManagment.Controllers
{
    [Authorize]
    public class ReportController : Controller
    {
        private readonly IReportGateway _reportGateway;
        public ReportController(IReportGateway reportGateway)
        {
            _reportGateway = reportGateway;
        }
        [Authorize(Roles = "SuperAdmin,Manager")]
        public IActionResult TestReport()
        {
            return View();
        }
        public IActionResult ApprovedLoans()
        {
            return View();
        }
        [Route("~/api/GetApprovedLoans/")]
        [HttpGet]
        public async Task<ActionResult> GetApprovedLoans()
        {
            var response = new ListResponseModel<SetLoanEmi>(200);
            response.Model = await _reportGateway.GetApprovedLoans();
            return Ok(response);
        }
    }
}
