using Microsoft.AspNetCore.Mvc;
using TodoistClone.Application.Services.TodoService.Commands;
using TodoistClone.Application.Services.TodoService.Commands.DTOs;
using TodoistClone.Application.Services.TodoService.Commands.DTOs.Delete;
using TodoistClone.Application.Services.TodoService.Queries;
using TodoistClone.Contracts.TodoContract;

namespace TodoistClone.Api.Controllers
{
    [ApiController]
    [Route("todos")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoQueryService _todoQueryService;
        private readonly ITodoCommandService _todoCommandService;

        public TodosController( ITodoQueryService todoQueryService, ITodoCommandService todoCommandService)
        {
            _todoQueryService = todoQueryService;
            _todoCommandService = todoCommandService;
        }

        [HttpGet("getById")]
        public async Task<IActionResult> GetById([FromHeader] string id)
        {

            if (id is null)
            {
                return BadRequest();
            }
            var todoResult = await _todoQueryService.GetById(Guid.Parse(id));

            var response = new TodoGetResponse(
                todoResult.Id,
                todoResult.Title,
                todoResult.Description,
                todoResult.Done);

            return Ok(response);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(TodoPostRequest request)
        {
            var todoResult = await _todoCommandService.Create(
                new TodoItemCreateRequest(
                request.Title,
                request.Description,
                request.Done
                ));

            var response = new TodoPostResponse(todoResult.Id);

            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(string id) {
            if (id is null) {
                return BadRequest();
            }
            var todoResult = await _todoCommandService.Delete(new TodoItemDeleteRequest(Guid.Parse(id)));
        
            var response = new TodoDeleteRespone(todoResult.Done);

            return Ok(response);
        }
    }
}