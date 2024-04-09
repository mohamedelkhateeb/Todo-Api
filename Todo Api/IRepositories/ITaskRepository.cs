using MongoDB.Bson;
using Todo_Api.Models;

namespace Todo_Api.Repositories
{
    public interface ITaskRepository
    {
        Task<Todo> Create(Todo todo);
        Task<IEnumerable<Todo>> GetAll();
        Task<Todo> GetById(string Id);
        Task<Todo> Update(string Id, Todo todo);
        Task<bool> Delete(string Id);

    }
}
