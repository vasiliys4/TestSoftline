using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using TestSoftline.Models;
using TestSoftline.Repository;

namespace TestSoftline.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITaskRepository taskRepository;

        public HomeController(ILogger<HomeController> logger, ITaskRepository _taskRepository)
        {
            _logger = logger;
            taskRepository = _taskRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tasks = await taskRepository.GetAllAsync();
            return View(tasks);
        }
        [HttpGet]
        public async Task<IActionResult> AddTask()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTask(Tasks task)
        {
            if (task == null)
            {
                return BadRequest("null");
            }
            await taskRepository.AddAsync(task);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTask(int id)
        {
            var task = await taskRepository.GetAsync(id);
            return View(task);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTask(Tasks task)
        {            
            if (task == null)
            {
                return BadRequest("null");
            }
            await taskRepository.UpdateAsync(task);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTask(int[] tasks)
        {
            await taskRepository.DeleteAsync(tasks);
            return RedirectToAction("Index");
        }
    }
}
