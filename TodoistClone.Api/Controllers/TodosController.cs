using Microsoft.AspNetCore.Mvc;
using TodoistClone.Application.Services.TodoService;
using TodoistClone.Contracts.TodoContract;

namespace TodoistClone.Api.Controllers {
    [ApiController]
    [Route("todos")]
    class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;

        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet("getById")]
        public IActionResult GetById(TodoGetByIdRequest request) {
            var todoResult = _todoService.GetById(request.Id);

            var response = new TodoGetResponse(
                todoResult.Todo.Id,
                todoResult.Todo.Title,
                todoResult.Todo.Description,
                todoResult.Todo.Done);

            return Ok(response);
        }
    }
}