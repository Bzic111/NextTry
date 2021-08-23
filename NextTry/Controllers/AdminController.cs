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
        
        /// <summary>
        /// Создание контракта по ID заказчика
        /// </summary>
        /// <param name="cId">ID заказчика в базе данных</param>
        /// <returns>200 ok</returns>
        [HttpPost("db/new/contract/customerId/{cId}")]
        public async Task<IActionResult> CreateNewContract([FromRoute] int cId)
        {
            await Task.Run(() => _worker.CreateNewContract(cId));
            if (true)
            {

            }
            return Ok();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
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
        
        //read-----------------------------------------------------------------------------------------------------------------------------------------------
        
        [HttpGet("db/contract/{cId}")]
        public async Task<IActionResult> GetContractInfo([FromRoute] int cId)
        {
            return Ok(await Task.Run(() => _worker.GetContractById(cId)));
        }
        [HttpGet("db/invoice/{iId}")]
        public async Task<IActionResult> GetInvoiceInfo([FromRoute] int iId)
        {
            return Ok(await Task.Run(() => _worker.GetInvoiceById(iId)));
        }
        [HttpGet("db/customer/{cId}")]
        public async Task<IActionResult> GetCustomerInfo([FromRoute] int cId)
        {
            return Ok(await Task.Run(() => _worker.GetCustomerById(cId)));
        }
        [HttpGet("db/employer/{eId}")]
        public async Task<IActionResult> GetEmployerInfo([FromRoute] int eId)
        {
            return Ok(await Task.Run(() => _worker.GetEmployerById(eId)));
        }
        [HttpGet("db/timesheet/{tsId}")]
        public async Task<IActionResult> GetTimeSheetInfo([FromRoute] int tsId)
        {
            return Ok(await Task.Run(() => _worker.GetTimeSheetById(tsId)));
        }
        [HttpGet("db/contract/list/customerId/{cId}")]
        public async Task<IActionResult> GetContractOfCustomer([FromRoute] int cId)
        {
            return Ok(await Task.Run(() => _worker.GetContractByCustomerId(cId)));
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
