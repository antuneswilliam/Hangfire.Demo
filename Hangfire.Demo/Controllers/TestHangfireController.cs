using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Hangfire.Demo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestHangfireController : ControllerBase
    {
        private readonly ILogger<TestHangfireController> _logger;
        private readonly IHangfireJobs hangfireJobs;

        public TestHangfireController(ILogger<TestHangfireController> logger, IHangfireJobs hangfireJobs)
        {
            _logger = logger;
            this.hangfireJobs = hangfireJobs;
        }

        [HttpPost("[action]")]
        public IActionResult AddFireAndForgetJob()
        {
            hangfireJobs.AddFireAndForget();
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult AddFailedJobRetry()
        {
            hangfireJobs.AddFailedJobRetry();
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult AddRecurringJob()
        {
            hangfireJobs.AddRecurringJob();
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult AddDelayedJob()
        {
            hangfireJobs.AddDelayedJob();
            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult AddContinuations()
        {
            hangfireJobs.AddContinuations();
            return Ok();
        }
    }
}
