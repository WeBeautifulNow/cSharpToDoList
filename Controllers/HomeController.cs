using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using ToDoList.Models;
using System.Collections.Generic;
using ToDoList.Contracts;
using System;
using ToDoList.Storage.Repositories.WorkItems;

namespace ToDoList.Controllers
{
    //[ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWorkItemRepository _workItemRepository;
        public HomeController(ILogger<HomeController> logger, IWorkItemRepository workItemRepository)
        {
            _logger = logger;
            _workItemRepository = workItemRepository;
        }

        [HttpGet("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<WorkItem>>> GetAllItems()
        {
            try
            {
                var allWorkItems = await _workItemRepository.GetAllItems();
                return Ok(allWorkItems);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.ToString());
                return BadRequest($"Get tenant error");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
