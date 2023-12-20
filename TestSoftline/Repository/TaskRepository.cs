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
            //foreach (var id in tasks)
            //{
            //    var existingTask = await _context.Tasks.FirstOrDefaultAsync(t => t.TasksId == id);
            //    _context.Tasks.Remove(existingTask);
            //}
            //await _context.SaveChangesAsync();

            foreach (var task in tasks)
            {
                var record = new Tasks { TasksId = task };

                _context.Attach(record);
                _context.Entry(record).State = EntityState.Deleted;
            }
            await _context.SaveChangesAsync();
        }

        public async Task<List<TaskViewModel>> GetAll()
        {
            var query = from t in _context.Tasks
                        join s in _context.Statuses on t.StatusId equals s.StatusId
                        select new TaskViewModel
                        {
                            Id = t.TasksId,
                            TaskName = t.TaskName,
                            TaskDescription = t.Description,
                            StatusName = s.StatusName
                        };
            return await query.ToListAsync();
        }

        public async Task<bool> Update(Tasks task)
        {
            //_context.Tasks.Update(task);
            //await _context.SaveChangesAsync();
            //return task;
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
        public async Task<Tasks> Get(int id) => await _context.Tasks.FirstOrDefaultAsync(t => t.TasksId == id);
    }
}
