using Domain.Dtos;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[Controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoRepositoryService _todoRepositoryService;

        public TodosController(ITodoRepositoryService todoRepositoryService)
        {
            _todoRepositoryService = todoRepositoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetAllTodos()
        {
            var todos = await _todoRepositoryService.GetAll();
            return Ok(todos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDto>> GetTodoById([FromQuery] int id)
        {
            var todo = await _todoRepositoryService.GetById(id);

            if(todo == null) { return NotFound(); }

            return Ok(todo);
        }

        [HttpPost]
        public ActionResult CreateTodo([FromBody] CreateTodoDto dto)
        {
            var id = _todoRepositoryService.Add(dto);

            if(id == null) { return BadRequest("Failed to create"); }

            return Ok(id);
        }

        [HttpPut]
        public ActionResult UpdateTodo([FromBody] TodoDto dto)
        {
            var result = _todoRepositoryService.Update(dto);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteTodo([FromQuery] int id)
        {
            var result = _todoRepositoryService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
