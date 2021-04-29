using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service;
using Repository;

namespace ToDo_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ILogger<ToDoController> _logger;
        private IToDoServices _toDoServices;

        public ToDoController(ILogger<ToDoController> logger, IToDoServices toDoServices)
        {
            _logger = logger;
            _toDoServices = toDoServices;
        }

        [HttpGet]
        public IActionResult GetToDos()
        {
            return Ok(_toDoServices.GetToDos());
        }

        [HttpGet("{id}", Name = "GetToDo")]
        public IActionResult GetToDo(int id)
        {
            return Ok(_toDoServices.GetToDo(id));
        }

        [HttpPost]
        public IActionResult CreateToDo(ToDo toDo)
        {
            var newToDo = _toDoServices.CreateToDo(toDo);
            return CreatedAtRoute("GetToDo", new { newToDo.Id }, newToDo);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteToDo(int id)
        {
            _toDoServices.DeleteToDo(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult EditToDo([FromBody] ToDo toDo)
        {
            _toDoServices.EditToDo(toDo);
            return Ok();
        }
    }
}
