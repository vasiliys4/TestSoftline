using TestSoftline.Models;

namespace TestSoftline.Repository
{
    public interface ITaskRepository
    {
        Task<List<TaskViewModel>> GetAll();
        Task<Tasks> Add(Tasks task);
        Task<bool> Update(Tasks task);
        Task Delete(int[] tasks);
        Task<Tasks> Get(int id);
    }
}
