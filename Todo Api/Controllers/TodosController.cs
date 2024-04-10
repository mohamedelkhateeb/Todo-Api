using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Todo_Api.Models;
using Todo_Api.Repositories;

namespace Todo_Api.Controllers
{
    [Route("api/Todos/")]
    [ApiController]
    public class TodosController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TodosController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(Todo todo)
        {
            await _taskRepository.Create(todo);
            return new JsonResult(todo);
        }
        [HttpGet("GetTodo/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var todo = await _taskRepository.GetById(id);
            if (todo == null) return new JsonResult("Not Found");

            return new JsonResult(todo);
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var todos =await _taskRepository.GetAll();
            return new JsonResult(todos);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Todo todo)
        {
            var newTodo = await _taskRepository.Update(todo.Id, todo);
            return new JsonResult(newTodo);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _taskRepository.Delete(id);
            return new JsonResult("success");
        }
        
    }
}
