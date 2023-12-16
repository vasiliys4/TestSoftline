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
            var tasks = await taskRepository.Get();
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
            var newTask = await taskRepository.Add(task);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> UpdateTask(int id)
        { 
            await taskRepository.Get(id);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateTask(Tasks task)
        {
            await taskRepository.Update(task);
            return RedirectToAction("Index");
        }
    }
}
