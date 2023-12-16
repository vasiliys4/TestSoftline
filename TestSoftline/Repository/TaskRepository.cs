using Microsoft.EntityFrameworkCore;
using TestSoftline.Data;
using TestSoftline.Models;
using Tasks = TestSoftline.Models.Tasks;

namespace TestSoftline.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDBContext _context;
        public TaskRepository(ApplicationDBContext context) 
        {
            _context = context;
        }
        public async Task<Tasks> Add(Tasks task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task Delete(int id)
        {
            var existingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.TasksId == id);
            _context.Tasks.Remove(existingTask);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Tasks>> Get()
        {
            return await _context.Tasks.Include(t => t.Statuss).ToListAsync();
        }

        public async Task<Tasks> Update(Tasks task)
        {
            var existingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.TasksId == task.TasksId);
            if (existingTask != null)
            {
                return (Tasks)Results.BadRequest(new { message = "Invalid" });
            }
            existingTask = task;
            await _context.SaveChangesAsync();
            return existingTask;
        }
        public async Task<Tasks> Get(int id)
        {
            return await _context.Tasks.Include(t => t.Statuss).FirstOrDefaultAsync(t => t.TasksId == id);
        }
    }
}
