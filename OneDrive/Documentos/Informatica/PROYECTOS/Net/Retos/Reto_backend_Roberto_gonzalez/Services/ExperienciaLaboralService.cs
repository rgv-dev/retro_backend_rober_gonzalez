using MongoDB.Driver;
using Reto_backend_Roberto_gonzalez.DataBases;
using Reto_backend_Roberto_gonzalez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reto_backend_Roberto_gonzalez.Services
{
    public class ExperienciaLaboralService
    {
        private readonly IMongoCollection<ExperienciaLaboral> experienciaLaborales;

        public ExperienciaLaboralService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            experienciaLaborales = database.GetCollection<ExperienciaLaboral>(settings.ExperienciaLaboralCollectionName);
        }

        public List<ExperienciaLaboral> Get() => experienciaLaborales.Find(experienciaLaboral => true).ToList();
        public ExperienciaLaboral Get(string id) => experienciaLaborales.Find<ExperienciaLaboral>(experienciaLaboral => experienciaLaboral.Id == id).FirstOrDefault();

        public ExperienciaLaboral Create(ExperienciaLaboral experienciaLaboral)
        {
            experienciaLaborales.InsertOne(experienciaLaboral);
            return experienciaLaboral;
        }

        public void Update(string id, ExperienciaLaboral experienciaLaboralIn) => experienciaLaborales.ReplaceOne(experiencia => experiencia.Id == id, experienciaLaboralIn);
        public void Remove(ExperienciaLaboral experienciaLaboralIn) => experienciaLaborales.DeleteOne(experiencia => experiencia.Id == experienciaLaboralIn.Id);
        public void Remove(string id) => experienciaLaborales.DeleteOne(experiencia => experiencia.Id == id);
    }
}
