using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Reto_backend_Roberto_gonzalez.Models
{
    public class ExperienciaAcademica
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string usuario_id { get; set; }
        public string fechaini { get; set; }
        public string fechafin { get; set; }
        public string centro { get; set; }
        public string titulo { get; set; }
        public int horas { get; set; }
    }
}
