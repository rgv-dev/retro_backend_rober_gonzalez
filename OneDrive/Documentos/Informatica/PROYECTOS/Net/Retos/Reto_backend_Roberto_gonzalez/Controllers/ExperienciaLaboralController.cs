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
    public class ExperienciaLaboralController : ControllerBase
    {
        private readonly ExperienciaLaboralService collectionServices;

        public ExperienciaLaboralController(ExperienciaLaboralService Service)
        {
            collectionServices = Service;
        }

        [HttpGet]
        public ActionResult<List<ExperienciaLaboral>> Get() => collectionServices.Get();

        [HttpGet("{Id:length(24)}", Name = "GetExperienciaLaboral")]
        public ActionResult<ExperienciaLaboral> Get(string id)
        {
            var model = collectionServices.Get(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }


        [HttpPost]
        public ActionResult<ExperienciaLaboral> Create(ExperienciaLaboral experienciaLaboral)
        {
            collectionServices.Create(experienciaLaboral);

            return CreatedAtRoute("GetExperienciaLaboral", new { id = experienciaLaboral.Id.ToString() }, experienciaLaboral);
        }

        [HttpPut("{Id:length(24)}")]
        public IActionResult Update(string id, ExperienciaLaboral experienciaLaboralIn)
        {
            var model = collectionServices.Get(id);

            if (model == null)
            {
                return NotFound();
            }

            collectionServices.Update(id, experienciaLaboralIn);

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
