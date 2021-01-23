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
    public class ExperienciaAcademicaController : ControllerBase
    {
        private readonly ExperienciaAcademicaService collectionServices;

        public ExperienciaAcademicaController(ExperienciaAcademicaService service)
        {
            collectionServices = service;
        }

        [HttpGet]
        public ActionResult<List<ExperienciaAcademica>> Get() => collectionServices.Get();

        [HttpGet("{Id:length(24)}", Name = "GetExperienciaAcademica")]
        public ActionResult<ExperienciaAcademica> Get(string id)
        {
            var model = collectionServices.Get(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }


        [HttpPost]
        public ActionResult<ExperienciaAcademica> Create(ExperienciaAcademica experienciaAcademica)
        {
            collectionServices.Create(experienciaAcademica);

            return CreatedAtRoute("GetUsuario", new { id = experienciaAcademica.Id.ToString() }, experienciaAcademica);
        }

        [HttpPut("{Id:length(24)}")]
        public IActionResult Update(string id, ExperienciaAcademica experienciaAcademicaIn)
        {
            var model = collectionServices.Get(id);

            if (model == null)
            {
                return NotFound();
            }

            collectionServices.Update(id, experienciaAcademicaIn);

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

