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
    [Route("api/employer")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        public EmployerController(ILoggerFactory loggerFactory)
        {
            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "log.txt"));
            var logger = loggerFactory.CreateLogger("FileLogger");
        }

        //create
        [HttpPost("{eId}/timesheet/new")]
        public async Task<IActionResult> CreateTimeSheet([FromRoute] int eId)
        {
            await Task.Delay(1);
            return Ok();
        }
        //read
        [HttpGet("{eId}/timesheet/{tsid}")]
        public async Task<IActionResult> ReadTimeSheetInfo([FromRoute] int eId,[FromRoute] int tsid)
        {
            await Task.Delay(1);
            return Ok();
        }
        //update
        [HttpPut("{eId}/timesheet/{tsid}/total/{time}")]
        public async Task<IActionResult> AddTotalTimeToTimeSheet([FromRoute] int eId, [FromRoute] int tsid, [FromRoute] int time)
        {
            await Task.Delay(1);
            return Ok();
        }
        //delete
        [HttpDelete("{eId}/timesheet/{tsid}/delete")]
        public async Task<IActionResult> DeleteTimeSheet([FromRoute] int eId, [FromRoute] int tsid)
        {
            await Task.Delay(1);
            return Ok();
        }

    }
}
