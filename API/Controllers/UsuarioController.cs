﻿using Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Entidades;

namespace API.Controllers
{
    [Route("api/[controller]")]// api/usuario, HttpGet, HttPost
    [ApiController]
    public class UsuarioController : ControllerBase
    {
       private readonly ApplicationDbContext _db;

        //se inyecta el servicio para la base de datos
        public UsuarioController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet] // api/usuario
        public async Task<ActionResult <IEnumerable<Usuario>>> GetUsuarios()
        {
           var usuarios = await _db.Usuarios.ToListAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")] // api/usuario/1

        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _db.Usuarios.FindAsync(id);

            return Ok(usuario);
        }
    }
}
