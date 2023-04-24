using DTLoanManagment.Models.Accounting;
using DTLoanManagment.Models.Common.Response;
using DTLoanManagment.Models.DBTableModels.Journal;
using DTLoanManagment.Models.Loan;
using DTLoanManagment.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DTLoanManagment.Controllers
{
    public class AccountingController : Controller
    {
        IAccountingGateway _accountingGateway;
        public AccountingController(IAccountingGateway accountingGateway)
        {
            _accountingGateway = accountingGateway;
        }
        public IActionResult Ledger()
        {
            return View();
        }
        [Route("~/api/GetMainLedgers/")]
        [HttpGet]
        public async Task<ActionResult> GetMainLedgers()
        {
            var response = new ListResponseModel<Ledger>(200);
            response.Model = await _accountingGateway.GetMainLedgers();
            return Ok(response);
        }
        [Route("~/api/GetSubGroupLedgers/{ledgerIds}/{levelNo}")]
        [HttpGet]
        public async Task<ActionResult> GetSubGroupLedgers(string ledgerIds,int levelNo)
        {
            var response = new ListResponseModel<Ledger>(200);
            response.Model = await _accountingGateway.GetSubGroupLedgers(ledgerIds, levelNo);
            return Ok(response);
        }
        //[Route("~/api/SaveNewLedger/")]
        //[HttpPost]
        //public async Task<ActionResult> SaveNewLedger()
        //{
        //    var response = new ListResponseModel<Ledger>(200);
        //    response.Model = await _accountingGateway.SaveNewLedger();
        //    return Ok(response);
        //}
    }
}
