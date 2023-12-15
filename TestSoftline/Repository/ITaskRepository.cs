using TestSoftline.Models;

namespace TestSoftline.Repository
{
    public interface ITaskRepository
    {
        Task<List<Tasks>> Get();
        Task<Tasks> Add(Tasks task);
        Task<Tasks> Update(Tasks task);
        Task Delete(int id);
    }
}
