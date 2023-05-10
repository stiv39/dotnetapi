using Domain.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[Controller]")]
    public class TodosController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoDto>>> GetAllTodos()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoDto>> GetTodoById(int id)
        {
            return Ok();
        }

        [HttpPost]
        public ActionResult CreateTodo(CreateTodoDto dto)
        {
            return Ok();
        }

        [HttpPut]
        public ActionResult UpdateTodo(TodoDto dto)
        {
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteTodo(TodoDto dto)
        {
            return Ok();
        }
    }
}
