using MongoDB.Driver;
using Reto_backend_Roberto_gonzalez.DataBases;
using Reto_backend_Roberto_gonzalez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reto_backend_Roberto_gonzalez.Services
{
    public class UsuarioService
    {
        private readonly IMongoCollection<Usuario> usuarios;

        public UsuarioService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            usuarios = database.GetCollection<Usuario>(settings.UsuariosCollectionName);
        }

        public List<Usuario> Get() => usuarios.Find(book => true).ToList();
        public Usuario Get(string id) => usuarios.Find<Usuario>(usuario => usuario.Id == id).FirstOrDefault();

        public Usuario Create(Usuario usuario)
        {
            usuarios.InsertOne(usuario);
            return usuario;
        }

        public void Update(string id, Usuario usuarioIn) => usuarios.ReplaceOne(usuario => usuario.Id == id, usuarioIn);
        public void Remove(Usuario usuarioIn) => usuarios.DeleteOne(usuario => usuario.Id == usuarioIn.Id);
        public void Remove(string id) => usuarios.DeleteOne(usuario => usuario.Id == id);

    }
}
