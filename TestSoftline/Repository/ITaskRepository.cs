using TestSoftline.Models;

namespace TestSoftline.Repository
{
    public interface ITaskRepository
    {
        Task<List<Tasks>> GetAll();
        Task<Tasks> Add(Tasks task);
        Task<Tasks> Update(Tasks task);
        Task Delete(int[] tasks);
        Task<Tasks> Get(int id);
    }
}
