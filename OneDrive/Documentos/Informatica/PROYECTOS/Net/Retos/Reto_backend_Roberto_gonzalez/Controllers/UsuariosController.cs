using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reto_backend_Roberto_gonzalez.Models;
using Reto_backend_Roberto_gonzalez.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reto_backend_Roberto_gonzalez.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService collectionServices;

        public UsuariosController(UsuarioService service)
        {
            collectionServices = service;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> Get() => collectionServices.Get();

        [HttpGet("{Id:length(24)}", Name = "GetUsuario")]
        public ActionResult<Usuario> Get(string id)
        {
            var model = collectionServices.Get(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }


        [HttpPost]
        public ActionResult<Usuario> Create(Usuario usuario)
        {
            collectionServices.Create(usuario);

            return CreatedAtRoute("GetUsuario", new { id = usuario.Id.ToString() }, usuario);
        }

        [HttpPut("{Id:length(24)}")]
        public IActionResult Update(string id, Usuario usuarioIn)
        {
            var model = collectionServices.Get(id);

            if (model == null)
            {
                return NotFound();
            }

            collectionServices.Update(id, usuarioIn);

            return NoContent();
        }

        [HttpDelete("{Id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var model = collectionServices.Get(id);

            if (model == null)
            {
                return NotFound();
            }

            collectionServices.Remove(model.Id);

            return NoContent();
        }

    }
}
