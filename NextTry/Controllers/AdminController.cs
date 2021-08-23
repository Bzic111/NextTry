using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using NextTry.Class;
using NextTry.Interface;

namespace NextTry.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private ILogger<AdminController> _logger;
        private Worker _worker;
        //private ContractDbContext _DBContext;
        //private EFRepository<Customer> _customers;
        //private EFRepository<Invoice> _invoices;
        //private EFRepository<Employer> _employers;
        //private EFRepository<Contract> _contracts;
        //private EFRepository<TimeSheet> _timeSheets;
        public AdminController(ILogger<AdminController> logger, Worker wrk)
        {
            _logger = logger; // Factory.CreateLogger<AdminController>();
            _worker = wrk;
            //_DBContext = DBContext;
            //_contracts = contr;
            //_invoices = inv;
            //_customers = cust;
        }

        //create---------------------------------------------------------------------------------------------------------------------------------------------
        
        //[HttpPost("db/add/contract/CustomerId/{cId}/status/{st}")]
        //public async Task<IActionResult> CreateColumnInTable([FromRoute] int cId, [FromRoute] int st)
        //{
        //    await Task.Run(() => _contracts.Create(new Contract() { CustomerId = cId, Status = true ? st > 1 : false }));

        //    _logger.LogInformation("admin Working");

        //    return Ok();
        //}
        //[HttpPost("db/add/invoice/cost/{cost}")]
        //public async Task<IActionResult> CreateInvoiceInTable([FromRoute] int cost)
        //{
        //    await Task.Run(() => _invoices.Create(new Invoice() { Cost = cost }));
        //    _logger.LogInformation("creating invoice");
        //    return Ok();
        //}


        [HttpPost("db/new/contract/customerId/{cId}")]
        public async Task<IActionResult> CreateNewContract([FromRoute] int cId)
        {
            await Task.Run(() => _worker.CreateNewContract(cId));
            return Ok();
        }
        [HttpPost("db/new/customer/{name}")]
        public async Task<IActionResult> CreateNewCustomer([FromRoute] string name)
        {
            await Task.Run(() => _worker.CreateNewCustomer(name));
            return Ok();
        }
        [HttpPost("db/new/employer/{name}")]
        public async Task<IActionResult> CreateNewEmployer([FromRoute] string name)
        {
            await Task.Run(() => _worker.CreateNewEmployer(name));
            return Ok();
        }
        [HttpPost("db/new/invoice/")]
        public async Task<IActionResult> CreateNewInvoice()
        {
            await Task.Run(() => _worker.CreateNewInvoice());
            return Ok();
        }
        


        //public async Task<IActionResult> CreateInvoiceInTable([FromRoute] int cost)
        //{

        //}
        
        //read-----------------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet("db/contract/{cId}")]
        public async Task<IActionResult> GetContractInfo([FromRoute] int cId)
        {
            var result = await Task.Run(() =>_worker.GetContractById(cId));
            return Ok(result);
        }
        [HttpGet("db/invoice/{iId}")]
        public async Task<IActionResult> GetInvoiceInfo([FromRoute] int iId)
        {
            var result = await Task.Run(() => _worker.GetInvoiceById(iId));
            return Ok(result);
        }
        [HttpGet("db/customer/{cId}")]
        public async Task<IActionResult> GetCustomerInfo([FromRoute] int cId)
        {
            var result = await Task.Run(() => _worker.GetCustomerById(cId));
            return Ok(result);
        }
        [HttpGet("db/employer/{eId}")]
        public async Task<IActionResult> GetEmployerInfo([FromRoute] int eId)
        {
            var result = await Task.Run(() => _worker.GetEmployerById(eId));
            return Ok(result);
        }
        [HttpGet("db/timesheet/{tsId}")]
        public async Task<IActionResult> GetTimeSheetInfo([FromRoute] int tsId)
        {
            var result = await Task.Run(() => _worker.GetTimeSheetById(tsId));
            return Ok(result);
        }

        //update---------------------------------------------------------------------------------------------------------------------------------------------
        [HttpPut("db/add/in/Contract/{cId}/invoice/{iId}")]
        public async Task<IActionResult> AddInvoiceToContract([FromRoute] int cId, [FromRoute] int iId)
        {
            await Task.Run(() => _worker.AddInvoiceToContract(cId, iId));
            return Ok();
        }
        //delete---------------------------------------------------------------------------------------------------------------------------------------------
    }
}
