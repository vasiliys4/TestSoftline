using Microsoft.AspNetCore.Mvc;
using TestSoftline.Models;

namespace TestSoftline.Repository
{
    public interface ITaskRepository
    {
        Task<List<Models.Task>> Get();
        System.Threading.Tasks.Task Add(Models.Task task);
        Task<Models.Task> Update(Models.Task task);
        System.Threading.Tasks.Task Delete(int id);
    }
}
