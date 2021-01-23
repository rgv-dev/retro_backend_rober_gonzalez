using MongoDB.Driver;
using Reto_backend_Roberto_gonzalez.DataBases;
using Reto_backend_Roberto_gonzalez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reto_backend_Roberto_gonzalez.Services
{
    public class ExperienciaAcademicaService
    {
        private readonly IMongoCollection<ExperienciaAcademica> experienciaAcademicas;

        public ExperienciaAcademicaService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            experienciaAcademicas = database.GetCollection<ExperienciaAcademica>(settings.ExperienciaAcademicaCollectionName);
        }

        public List<ExperienciaAcademica> Get() => experienciaAcademicas.Find(experiencia => true).ToList();
        public ExperienciaAcademica Get(string id) => experienciaAcademicas.Find<ExperienciaAcademica>(m => m.Id == id).FirstOrDefault();

        public ExperienciaAcademica Create(ExperienciaAcademica experienciaAcademica)
        {
            experienciaAcademicas.InsertOne(experienciaAcademica);
            return experienciaAcademica;
        }

        public void Update(string id, ExperienciaAcademica experienciaAcademicaIn) => experienciaAcademicas.ReplaceOne(m => m.Id == id, experienciaAcademicaIn);
        public void Remove(ExperienciaAcademica experienciaAcademicaIn) => experienciaAcademicas.DeleteOne(m => m.Id == experienciaAcademicaIn.Id);
        public void Remove(string id) => experienciaAcademicas.DeleteOne(m => m.Id == id);
    }
}
