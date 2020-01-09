using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JobApprovalWeb.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobApprovalController : ControllerBase
    {
        private readonly ILogger<JobApprovalController> _logger;

        public JobApprovalController(ILogger<JobApprovalController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public void Get()
        {
        }
    }
}
