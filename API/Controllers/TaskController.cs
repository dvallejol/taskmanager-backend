using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Entidades;
using Microsoft.EntityFrameworkCore;
using Data;

namespace API.Controllers
{
    // 🔹 Define la ruta base del controlador como "api/task"
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskContext _context;

        // 🔹 Constructor que inyecta el contexto de la base de datos
        public TaskController(TaskContext context)
        {
            _context = context;
        }

        /// <summary>
        /// 🔹 Obtiene la lista de todas las tareas almacenadas en la base de datos.
        /// </summary>
        /// <returns>Lista de tareas en formato JSON.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        /// <summary>
        /// 🔹 Crea una nueva tarea en la base de datos.
        /// </summary>
        /// <param name="task">Objeto TaskItem con los datos de la nueva tarea.</param>
        /// <returns>La tarea creada con su ID asignado.</returns>
        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
        {
            _context.Tasks.Add(task); // Agrega la nueva tarea a la base de datos
            await _context.SaveChangesAsync(); // Guarda los cambios

            // Devuelve un 201 Created con la nueva tarea y su ubicación
            return CreatedAtAction(nameof(GetTasks), new { id = task.Id }, task);
        }

        /// <summary>
        /// 🔹 Actualiza una tarea existente en la base de datos.
        /// </summary>
        /// <param name="id">ID de la tarea a actualizar.</param>
        /// <param name="updatedTask">Objeto con los nuevos datos de la tarea.</param>
        /// <returns>NoContent si la tarea se actualiza correctamente, NotFound si no existe.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskItem updatedTask)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound(); // Si la tarea no existe, retorna 404 Not Found

            // 🔹 Actualizar los valores de la tarea existente con los nuevos datos
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.DueDate = updatedTask.DueDate; // ✅ Agregado: actualizar la fecha de vencimiento
            task.Completed = updatedTask.Completed;

            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            return NoContent(); // Retorna un 204 No Content (actualización exitosa)
        }

        /// <summary>
        /// 🔹 Elimina una tarea de la base de datos.
        /// </summary>
        /// <param name="id">ID de la tarea a eliminar.</param>
        /// <returns>NoContent si la tarea se elimina correctamente, NotFound si no existe.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound(); // Si la tarea no existe, retorna 404 Not Found

            _context.Tasks.Remove(task); // Elimina la tarea
            await _context.SaveChangesAsync(); // Guarda los cambios en la base de datos
            return NoContent(); // Retorna 204 No Content (eliminación exitosa)
        }
    }
}
