using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entidades
{
    /// <summary>
    /// 🔹 Representa una tarea dentro del sistema.
    /// Esta clase define las propiedades de cada tarea y cómo se almacena en la base de datos.
    /// </summary>
    public class TaskItem
    {
        /// <summary>
        /// 🔹 Identificador único de la tarea.
        /// Es la clave primaria en la base de datos.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 🔹 Título de la tarea.
        /// Representa un breve resumen o nombre de la tarea.
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// 🔹 Descripción de la tarea.
        /// Puede contener detalles adicionales sobre lo que se debe hacer.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// 🔹 Fecha de vencimiento de la tarea (opcional).
        /// Permite establecer una fecha límite para completar la tarea.
        /// </summary>
        public DateTime? DueDate { get; set; } // ✅ Está incluido y es opcional (nullable)

        /// <summary>
        /// 🔹 Indica si la tarea ha sido completada.
        /// `true` si está completada, `false` si sigue pendiente.
        /// </summary>
        public bool Completed { get; set; }
    }
}

