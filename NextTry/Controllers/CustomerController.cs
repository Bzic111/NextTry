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
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerController(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");
        }

        //create---------------------------------------------------------------------------------------------------------------------------------------------
        [HttpPost("{cstrId}/contract/new")]
        public async Task<IActionResult> CreateContract([FromRoute] int cstrId)
        {
            await Task.Delay(1);
            return Ok();
        }

        //read-----------------------------------------------------------------------------------------------------------------------------------------------
        [HttpGet("{cstrId}/contract/{cntrId}")]
        public async Task<IActionResult> ReadContractInfo([FromRoute] int cstrId,[FromRoute] int cntrId)
        {
            await Task.Delay(1);
            return Ok();
        }
        [HttpGet("{cstrId}/contract/{cntrId}/invoice/{invid}")]
        public async Task<IActionResult> ReadInvoiceInfo([FromRoute] int cstrId, [FromRoute] int cntrId, [FromRoute] int invId)
        {
            await Task.Delay(1);
            return Ok();
        }
        
        //update---------------------------------------------------------------------------------------------------------------------------------------------
        [HttpPut("{cstrId}/contract/{cntrId}/close")]
        public async Task<IActionResult> CloseContract([FromRoute] int cstrId, [FromRoute] int cntrId)
        {
            await Task.Delay(1);
            return Ok();
        }
        [HttpPut("{cstrId}/contract/{cntrId}/invoice/{invid}/close")]
        public async Task<IActionResult> CloseInvoice([FromRoute] int cstrId, [FromRoute] int cntrId, [FromRoute] int invId)
        {
            await Task.Delay(1);
            return Ok();
        }
        
        //delete---------------------------------------------------------------------------------------------------------------------------------------------
        [HttpDelete("{cstrId}/contract/{cntrId}/delete")]
        public async Task<IActionResult> DeleteContract([FromRoute] int cstrId, [FromRoute] int cntrId)
        {
            await Task.Delay(1);
            return Ok();
        }

    }
}
