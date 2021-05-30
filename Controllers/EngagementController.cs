using System.Collections.Generic;
using System.Threading.Tasks;
using AuditTool.Models;
using AuditTool.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AuditTool.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EngagementController : ControllerBase
    {
        private readonly IEngagementRepository repository;
        private readonly ILogger<EngagementController> _logger;

        public EngagementController(IEngagementRepository repository, ILogger<EngagementController> logger)
        {
            this.repository = repository;
            _logger = logger;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Engagement>>> GetAllAsync()
        {
            var items = await repository.GetAllAsync();
            return new OkObjectResult(items);
        }


        [HttpGet("byid")]
        public async Task<ActionResult<Engagement>> GetByIdAsync(string id, string partitionKey)
        {
            var items = await repository.GetAsync(id, partitionKey);
            return new OkObjectResult(items);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAsync(Engagement item)
        {
            await repository.AddAsync(item);
            return new OkResult();
        }
    }
}
