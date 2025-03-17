using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;


namespace Data
{
    /// <summary>
    /// 🔹 Contexto de la base de datos para Entity Framework Core.
    /// Se encarga de gestionar la conexión con la base de datos y el mapeo de entidades.
    /// </summary>
    public class TaskContext : DbContext
    {
        /// <summary>
        /// 🔹 Constructor que recibe las opciones de configuración del contexto.
        /// Permite inyectar la configuración de la base de datos desde la clase `Program.cs`.
        /// </summary>
        /// <param name="options">Opciones de configuración del contexto.</param>
        public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }

        /// <summary>
        /// 🔹 Conjunto de datos que representa la tabla "Tasks" en la base de datos.
        /// </summary>
        public DbSet<TaskItem> Tasks { get; set; }
    }
}
