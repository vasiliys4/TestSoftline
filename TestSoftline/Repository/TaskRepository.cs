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
        public async Task<Tasks> AddAsync(Tasks task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task DeleteAsync(int[] tasks)
        {
            foreach (var task in tasks)
            {
                var record = new Tasks 
                { 
                    TasksId = task,
                    IsDeleted = true
                };

                _context.Attach(record);
                _context.Entry(record).Property(x => x.IsDeleted).IsModified = true;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<TaskViewModel>> GetAllAsync()
        {
            var query = from t in _context.Tasks
                        join s in _context.Statuses on t.StatusId equals s.StatusId
                        select new TaskViewModel
                        {
                            Id = t.TasksId,
                            TaskName = t.TaskName,
                            TaskDescription = t.Description,
                            StatusName = s.StatusName,
                            IsDeleted = t.IsDeleted
                        };
            return await query.ToListAsync();
        }

        public async Task<bool> UpdateAsync(Tasks task)
        {
            var item = new Tasks
            {
                TasksId = task.TasksId,
                TaskName = task.TaskName,
                Description = task.Description,
                StatusId = task.StatusId
            };

            if (!await _context.Tasks.AnyAsync(x => x.TasksId == item.TasksId))
            {
                return false;
            }

            _context.Tasks.Attach(item);
            _context.Entry(item).Property(x => x.TaskName).IsModified = true;
            _context.Entry(item).Property(x => x.Description).IsModified = true;
            _context.Entry(item).Property(x => x.StatusId).IsModified = true;

            await _context.SaveChangesAsync();

            return true;
        }
        public async Task<Tasks> GetAsync(int id) => await _context.Tasks.FirstOrDefaultAsync(t => t.TasksId == id);
    }
}
