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
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private ILogger<AdminController> _logger;
        private ContractDbContext _DBContext;

        public AdminController(ILogger<AdminController> logger, ContractDbContext DBContext)
        {
            _DBContext = DBContext;
            _logger = logger; // Factory.CreateLogger<AdminController>();
        }

        //create---------------------------------------------------------------------------------------------------------------------------------------------
        [HttpPost("db/add/contract/{cntrId}/CustomerId/{cId}/")]
        public async Task<IActionResult> CreateColumnInTable([FromRoute] int cId)
        {
            _DBContext.Add(new Contract() { Id = 1, CustomerId = cId, Invoices = null, Status = true });
            await _DBContext.SaveChangesAsync();
            _logger.LogInformation("admin Working");
            
            return Ok();
        }

        //read-----------------------------------------------------------------------------------------------------------------------------------------------

        //update---------------------------------------------------------------------------------------------------------------------------------------------

        //delete---------------------------------------------------------------------------------------------------------------------------------------------
    }
}
