using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/usuarios")]
public class UsuarioController : ControllerBase {

    private readonly IUsuarioService _usuarioService;

    public UsuarioController(IUsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

     [HttpGet]
        public ActionResult<List<Usuario>> GetAll()
        {
            return Ok (_usuarioService.GetAll());
        }

    [HttpGet("{id}")]
        public ActionResult<Usuario> GetById(int id)
        {
        var a = _usuarioService.GetById(id);
        if(a == null)
        {
            return NotFound("Usuario no Encotrado");
        }
        return Ok(a);
        }
    [HttpPost]
        public ActionResult<Usuario> Create(UsuarioDTO u)
        {
            return Ok(_usuarioService.Create(u));
        }
    [HttpDelete]
      public ActionResult Delete(int id)
        {
            var a = _usuarioService.GetById(id);

            if (a == null)
            { return NotFound("Usuario no encontrado!!!");}

            _usuarioService.Delete(id);
            return NoContent();
        }
    [HttpPut("{id}")]
    public ActionResult<Usuario> UpdateAutor(int id, Usuario updatedUsuario) {
        // Asegurarse de que el ID del autor en la solicitud coincida con el ID del parámetro
        if (id != updatedUsuario.Id) {
        return BadRequest("El ID del autor en la URL no coincide con el ID del autor en el cuerpo de la solicitud.");
        }
        var usuario = _usuarioService.Update(id, updatedUsuario);

        if (usuario is null) {
        return NotFound(); // Si no se encontró el autor, retorna 404 Not Found
        }
        return Ok(usuario); // Retorna el recurso actualizado
        }



}
