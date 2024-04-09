using MongoDB.Bson;
using MongoDB.Driver;
using Todo_Api.Models;

namespace Todo_Api.Repositories
{
    public class TaskRepository : ITaskRepository
    {   
        private readonly IMongoCollection<Todo> _todos;
        public TaskRepository(IMongoClient client)
        {
            var database = client.GetDatabase("TasksDB");
            var collection = database.GetCollection<Todo>(nameof(Todo));
            _todos = collection;
        }
        //create a Task
        public async Task<Todo> Create(Todo todo)
        {
            await _todos.InsertOneAsync(todo);
            return todo;
        }

        // Get All Tasks
        public async Task<IEnumerable<Todo>> GetAll()
        {
            return await _todos.Find(_ => true).ToListAsync();
        }

        // Get by id Task
        public async Task<Todo> GetById(string id)
        {
            return await _todos.Find(x => x.Id == id ).FirstOrDefaultAsync();
        }
        //Update Task

        public async Task<Todo> Update(string Id, Todo todo)
        {
            var updateResult = await _todos.ReplaceOneAsync( x=>x.Id == Id , todo);
            return todo;

        }
        //Delete a task
        public async Task<bool> Delete(string id)
        {
            var deleteResult = await _todos.DeleteOneAsync(x => x.Id == id);
            return deleteResult.DeletedCount == 1;
        }
    }
}
