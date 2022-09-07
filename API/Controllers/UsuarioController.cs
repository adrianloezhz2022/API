using Microsoft.AspNetCore.Mvc;
using API.Model;
using API.ADO_Repository;
using API.Controllers.DTOS;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        [HttpGet(Name = "GetUsuarios")]
        public List<Usuario> GetUsuarios()
        {
            return UsuarioHandler.GetUsarios();
        }
        [HttpGet(Name = "GetUsuario/Contraseña")]
        public bool Login([FromBody] string usuario, string contraseña)
        {
            return UsuarioHandler.Login(usuario, contraseña);
        }
        [HttpDelete(Name = "DeleteUsuarios")]
        public bool EliminarUsuario([FromBody] int id)
        {
            return UsuarioHandler.EliminarUsuario(id);
        }
        [HttpPost(Name = "PostUsuario")]
        public bool CrearUsuario([FromBody] PostUsuario usuario)
        {
            return UsuarioHandler.CrearUsuario(new Usuario {
                
                Apellido = usuario.Apellido,
                Contraseña = usuario.Contraseña,
                Mail = usuario.Mail,
                Nombre = usuario.Nombre,
                NombreUsuario = usuario.NombreUsuario});
        }
        [HttpPut(Name ="PutUsuario")]
        public bool ModificarUsuario([FromBody] PutUsuario usuario)
        {
            return UsuarioHandler.ModificarUsuario(new Usuario {
                Id = usuario.Id,Apellido = usuario.Apellido,Contraseña = usuario.Contraseña,Mail = usuario.Mail,Nombre = usuario.Nombre,NombreUsuario = usuario.NombreUsuario});
        }
    }
} 