using TestSoftline.Models;

namespace TestSoftline.Repository
{
    public interface ITaskRepository
    {
        Task<List<TaskViewModel>> GetAllAsync();
        Task<Tasks> AddAsync(Tasks task);
        Task<bool> UpdateAsync(Tasks task);
        Task DeleteAsync(int[] tasks);
        Task<Tasks> GetAsync(int id);
    }
}
