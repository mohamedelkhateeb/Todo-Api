using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Todo_Api.Models;
using Todo_Api.Repositories;

namespace Todo_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpPost()]
        public async Task<IActionResult> Create(Todo todo)
        {
            var id = _taskRepository.Create(todo);
            return new JsonResult(id.ToString());
        }
        [HttpGet("Todo/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var todo = await _taskRepository.GetById(id);
            if (todo == null) return new JsonResult("Not Found");

            return new JsonResult(todo);
        }
        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var todos =await _taskRepository.GetAll();
            return new JsonResult(todos);
        }

        [HttpPut()]
        public async Task<IActionResult> Update(Todo todo)
        {
            var newTodo = await _taskRepository.Update(todo.Id, todo);
            return new JsonResult(newTodo);
        }
    }
}
