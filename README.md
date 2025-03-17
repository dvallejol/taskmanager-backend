# Task Manager - Backend

Este es el backend del proyecto **Task Manager**, desarrollado en **.NET 7** con **Entity Framework Core** y una base de datos en memoria. Este backend expone una API RESTful para la gestión de tareas y usuarios.

## 📌 Requisitos previos

Antes de ejecutar la aplicación, asegúrate de tener instalado lo siguiente en tu sistema:

- [.NET 7 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [Git](https://git-scm.com/downloads)
- (Opcional) [Postman](https://www.postman.com/downloads/) para probar la API

## 🚀 Instalación y ejecución

Sigue estos pasos para clonar y ejecutar la aplicación en tu máquina local:

### 1️⃣ Clonar el repositorio
```sh
git clone https://github.com/dvallejol/taskmanager-backend.git
```

### 2️⃣ Navegar al directorio del proyecto
```sh
cd taskmanager-backend
```

### 3️⃣ Restaurar paquetes de dependencias
```sh
dotnet restore
```

### 4️⃣ Ejecutar la aplicación
```sh
dotnet run --project API
```

Esto iniciará el servidor en `http://localhost:5146/` y la API estará disponible.

### 5️⃣ Probar la API con Swagger
Una vez que la aplicación esté corriendo, abre en tu navegador:
```
http://localhost:5146/swagger/index.html
```
Aquí podrás probar los endpoints de la API sin necesidad de herramientas externas.

## 📂 Estructura del proyecto
```
📂 taskmanager-backend
 ├── 📂 API                # Proyecto principal con la API REST
 │   ├── Controllers       # Controladores de la API
 │   ├── Program.cs        # Configuración principal de la aplicación
 │   ├── appsettings.json  # Configuración de la aplicación
 ├── 📂 Data               # Configuración de Entity Framework Core
 │   ├── TaskContext.cs    # Contexto de base de datos en memoria
 │   ├── ApplicationDbContext.cs # Contexto para usuarios
 ├── 📂 Models             # Modelos de la base de datos
 │   ├── TaskItem.cs       # Modelo de Tareas
 │   ├── Usuario.cs        # Modelo de Usuarios
 ├── README.md             # Instrucciones del proyecto
```

## 🛠 Endpoints disponibles

### 📌 **Tareas (`/api/Task`)**
- **GET** `/api/Task` → Obtener todas las tareas.
- **POST** `/api/Task` → Crear una nueva tarea.
- **PUT** `/api/Task/{id}` → Actualizar una tarea por ID.
- **DELETE** `/api/Task/{id}` → Eliminar una tarea por ID.

### 📌 **Usuarios (`/api/Usuario`)**
- **GET** `/api/Usuario` → Obtener todos los usuarios.
- **GET** `/api/Usuario/{id}` → Obtener un usuario por ID.

## 🚀 Desplegar en Railway (Opcional)
Si quieres desplegar el backend en **Railway**, sigue estos pasos:

1. Crear una cuenta en [Railway](https://railway.app/).
2. Instalar [Railway CLI](https://docs.railway.app/cli/).
3. Iniciar sesión en Railway:
   ```sh
   railway login
   ```
4. Crear un nuevo proyecto:
   ```sh
   railway init
   ```
5. Desplegar la aplicación:
   ```sh
   railway up
   ```

## 🛠 Tecnologías utilizadas
- **.NET 7** - Framework principal
- **Entity Framework Core** - ORM para la base de datos
- **Swagger** - Documentación y pruebas de API

## 📌 Notas
- La base de datos es **en memoria**, por lo que los datos se pierden al reiniciar el servidor. Para persistencia, se recomienda configurar **SQL Server** o **SQLite**.
- Si deseas cambiar el puerto, modifica `appsettings.json` o usa el argumento `--urls` en `dotnet run`.

---

📌 **¡Listo! Ya puedes comenzar a desarrollar y probar el backend de Task Manager. 🚀**

