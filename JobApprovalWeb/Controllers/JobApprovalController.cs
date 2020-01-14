using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JobApproval;

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

        [HttpPost("submit")]
        public IActionResult PostSubmit([FromBody] JobSheetModel jobSheetModel)
        {
            JobProcessor jobProcessor = new JobProcessor(new ReferenceData());
            Outcomes outcome = jobProcessor.Process(ProcessJobSheetModel(jobSheetModel));
            return Ok(outcome.ToString());
        }

        private JobSheet ProcessJobSheetModel(JobSheetModel jobSheetModel)
        {
            JobSheet jobSheet = new JobSheet(jobSheetModel.TotalHours, jobSheetModel.TotalPrice);
            foreach (string item in jobSheetModel.GetRequestedItems())
            {
                jobSheet.AddItem(new JobItem(item));
            }
            return jobSheet;
        }
    }
}
