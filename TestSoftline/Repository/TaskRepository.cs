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

        public async Task Delete(int[] tasks)
        {
            foreach (var id in tasks)
            {
                var existingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.TasksId == id);
                _context.Tasks.Remove(existingTask);
            }
            await _context.SaveChangesAsync();

        }

        public async Task<List<Tasks>> GetAll()
        {
            return await _context.Tasks.Include(t => t.Status).ToListAsync();
        }

        public async Task<Tasks> Update(Tasks task)
        {
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();
            return task;
        }
        public async Task<Tasks> Get(int id) => await _context.Tasks.FirstOrDefaultAsync(t => t.TasksId == id);
    }
}
