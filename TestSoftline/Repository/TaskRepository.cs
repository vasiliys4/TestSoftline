using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestSoftline.Data;
using TestSoftline.Models;
using Task = TestSoftline.Models.Task;

namespace TestSoftline.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDBContext context;
        public TaskRepository(ApplicationDBContext context) 
        {
            this.context = context;
        }
        public async System.Threading.Tasks.Task Add(Task task)
        {
            await context.Tasks.AddAsync(task);
            await context.SaveChangesAsync();
        }

        public async System.Threading.Tasks.Task Delete(int id)
        {
            var existingTask = await context.Tasks.FirstOrDefaultAsync(t => t.TaskId == id);
            context.Tasks.Remove(existingTask);
            await context.SaveChangesAsync();
        }

        public async Task<List<Models.Task>> Get()
        {
            return await context.Tasks.Include(t => t.StatusId).ToListAsync();
        }

        public async Task<Task> Update(Task task)
        {
            var existingTask = await context.Tasks.FirstOrDefaultAsync(t => t.TaskId == task.TaskId);
            if (existingTask != null)
            {
                return (Task)Results.BadRequest(new { message = "Invalid" });
            }
            existingTask = task;
            await context.SaveChangesAsync();
            return existingTask;
        }
    }
}
