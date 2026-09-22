using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListApi.Context;
using TodoListApi.Models;

namespace TodoListApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //El controlador TodoItemsController es responsable de manejar las solicitudes HTTP relacionadas con los elementos de la lista de tareas (TodoItems). Proporciona métodos para obtener, crear, actualizar y eliminar elementos de la lista de tareas. Utiliza el contexto de la base de datos (AppDbContext) para interactuar con la base de datos y realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) en los elementos de la lista de tareas.
    public class TodoItemsController : ControllerBase
    {
        // Inyección de dependencias del contexto de la base de datos
        private readonly AppDbContext _context;

        // Constructor del controlador que recibe el contexto de la base de datos como parámetro
        public TodoItemsController(AppDbContext context)
        {
            // Inicializa el contexto de la base de datos
            _context = context;
        }

        // GET: api/TodoItems
        [HttpGet]
        // Este método maneja las solicitudes GET a la ruta "api/TodoItems" y devuelve una lista de todos los elementos de la lista de tareas almacenados en la base de datos.
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems() //esto devuelve una lista de elementos de la lista de tareas TodoItems en formato JSON.
        {
            return await _context.TodoItems.ToListAsync();
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        // Este método maneja las solicitudes GET a la ruta "api/TodoItems/5" y devuelve un elemento específico de la lista de tareas.
        public async Task<ActionResult<TodoItem>> GetTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

        // POST: api/TodoItems
        [HttpPost]
        // Este método maneja las solicitudes POST a la ruta "api/TodoItems" y permite crear un nuevo elemento en la lista de tareas.   
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();
            // Devuelve una respuesta HTTP 201 Created con la ubicación del nuevo recurso creado
            return CreatedAtAction(
                nameof(GetTodoItem),
                new { id = todoItem.Id },
                todoItem
            );
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoItem(int id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoItem).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoItem(int id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);

            if (todoItem == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
