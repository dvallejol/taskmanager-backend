using Microsoft.EntityFrameworkCore;
using Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// 🔹 Contexto de base de datos para la aplicación.
    /// Se encarga de la conexión y el mapeo de entidades con la base de datos.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// 🔹 Constructor que recibe opciones de configuración del contexto.
        /// Permite que la configuración de la base de datos se inyecte desde `Program.cs`.
        /// </summary>
        /// <param name="options">Opciones de configuración del contexto.</param>
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// 🔹 Conjunto de datos que representa la tabla "Usuarios" en la base de datos.
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }
    }
}

