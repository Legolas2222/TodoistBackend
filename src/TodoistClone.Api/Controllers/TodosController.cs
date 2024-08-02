using Microsoft.AspNetCore.Mvc;
using TodoistClone.Application.Services.TodoService.Commands;
using TodoistClone.Application.Services.TodoService.Commands.DTOs.Create;
using TodoistClone.Application.Services.TodoService.Commands.DTOs.Delete;
using TodoistClone.Application.Services.TodoService.Commands.DTOs.Update;
using TodoistClone.Application.Services.TodoService.Common.DTOs;
using TodoistClone.Application.Services.TodoService.Queries;
using TodoistClone.Contracts.TodoContract.Add;
using TodoistClone.Contracts.TodoContract.GetAll;
using TodoistClone.Contracts.TodoContract.GetById;
using TodoistClone.Contracts.TodoContract.Update;

namespace TodoistClone.Api.Controllers
{
    [ApiController]
    [Route("todos")]
    public class TodosController(ITodoQueryService todoQueryService, ITodoCommandService todoCommandService) : ControllerBase
    {
        private readonly ITodoQueryService _todoQueryService = todoQueryService;
        private readonly ITodoCommandService _todoCommandService = todoCommandService;

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

        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var todos = await _todoQueryService.GetAll();
            List<TodoGetResponse> r = [];
            foreach (TodoItemDTO item in todos)
            {
                r.Add(new TodoGetResponse(
                    item.Id,
                    item.Title,
                    item.Description,
                    item.Done
                    ));
            }
            return Ok(new TodoGetAllResponse(r));

        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(TodoPostRequest request)
        {
            await _todoCommandService.Add(
               new TodoItemCreateRequest(
               request.Title,
               request.Description,
               request.Done
               ));


            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update(TodoUpdateRequest request)
        {
            await _todoCommandService.Update(
            new TodoItemUpdateRequest(
                request.Id,
                request.NewTitle,
                request.NewDescription
            ));

            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _todoCommandService.Delete(new TodoItemDeleteRequest(id));

            return Ok();
        }
    }
}