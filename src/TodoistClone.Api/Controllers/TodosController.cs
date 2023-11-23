using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using TodoistClone.Application.Services.TodoService;
using TodoistClone.Contracts.TodoContract;

namespace TodoistClone.Api.Controllers
{
    [ApiController]
    [Route("todos")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("getById")]
        public IActionResult GetById([FromHeader] string id)
        {

            if (id is null)
            {
                return BadRequest();
            }
            var todoResult = _todoService.GetById(Guid.Parse(id));

            var response = new TodoGetResponse(
                todoResult.Todo.Id,
                todoResult.Todo.Title,
                todoResult.Todo.Description,
                todoResult.Todo.Done);

            return Ok(response);
        }


        [HttpPost("add")]
        public IActionResult Add(TodoPostRequest request)
        {
            var todoResult = _todoService.Add(
                request.Title,
                request.Description,
                request.Done);

            var response = new TodoPostResponse(todoResult.Id);

            return Ok(response);
        }
    }
}