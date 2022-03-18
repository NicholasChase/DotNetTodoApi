using Microsoft.AspNetCore.Mvc;
using todoDotNet6.TodoRepo;

namespace todoDotNet6.TodoController
{
    public class TodoController : ControllerBase
    {
        private readonly ITodoRepository _todoRepository;

        public TodoController(ITodoRepository todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public ActionResult<Todo> GetTodos ()
        {
            var allTodos = _todoRepository.GetTodos();
            return Ok(allTodos);
        }

    }
}