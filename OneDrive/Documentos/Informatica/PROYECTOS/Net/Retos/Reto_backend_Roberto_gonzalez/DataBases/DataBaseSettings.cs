using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reto_backend_Roberto_gonzalez.DataBases
{
    public class DataBaseSettings : IDatabaseSettings
    {
        public string UsuariosCollectionName { get; set; }
        public string ExperienciaAcademicaCollectionName { get; set; }
        public string ExperienciaLaboralCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
        string UsuariosCollectionName { get; set; }
        string ExperienciaAcademicaCollectionName { get; set; }
        public string ExperienciaLaboralCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
