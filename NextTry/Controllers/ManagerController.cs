using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NextTry.Class;

namespace NextTry.Controllers
{
    [Route("api/manager")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private ILogger _logger;
        public ManagerController(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"));
            _logger = loggerFactory.CreateLogger("FileLogger");
        }

        //create---------------------------------------------------------------------------------------------------------------------------------------------
        [HttpPost("invoice/new")]
        public async Task<IActionResult> CreateInvoice()
        {
            await Task.Delay(1);
            //_logger.Log(LogLevel.Information, $"\"Create Invoice\" executed");
            _logger.LogInformation($"\"Create Invoice\" executed");
            return Ok();
        }

        //read-----------------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet("invoice/{invId}")]
        public async Task<IActionResult> ReadInvoiceInfo([FromRoute] int invId) 
        {
            await Task.Delay(1);
            //_logger.Log(LogLevel.Information, $"\"ReadInvoiceInfo\" executed");
            return Ok(); 
        }

        //update---------------------------------------------------------------------------------------------------------------------------------------------
        [HttpPut("invoice/{invId}/timesheet/{tsid}")]
        public async Task<IActionResult> AddTimeSheetToInvoice([FromRoute] int tsid)
        {
            await Task.Delay(1);
            return Ok();
        }
        [HttpPut("contract/{cntrId}/invoice/{invId}")]
        public async Task<IActionResult> AddInvoiceToContract([FromRoute] int cntrId, [FromRoute] int invId)
        {
            await Task.Delay(1);
            return Ok();
        }

        //delete---------------------------------------------------------------------------------------------------------------------------------------------
        [HttpDelete("invoice/{invId}/delete")]
        public async Task<IActionResult> DeleteInvoice([FromRoute] int invId)
        {
            await Task.Delay(1);
            return Ok();
        }

    }
}
