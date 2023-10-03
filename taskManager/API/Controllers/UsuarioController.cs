using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [ApiController]
    [Route("usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public UsuarioController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            try
            {
                List<Usuario> usuarios = _ctx.Usuarios.ToList();
                return usuarios.Count == 0 ? NotFound() : Ok(usuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Usuario usuario)
        {

            try
            {
                // verifico o preenchimento do Nome, username e senha
                if (string.IsNullOrEmpty(usuario.Nome) || string.IsNullOrEmpty(usuario.Username) || string.IsNullOrEmpty(usuario.Senha))
                {
                    return BadRequest(new { message = "Falta informações de nome, username ou senha!" });
                }

                // verifico se ja existe um usuario com o mesmo nome no banco
                var usuarioEncontrado = _ctx.Usuarios.FirstOrDefault(u => u.Username == usuario.Username);

                if (usuarioEncontrado != null)
                {
                    return BadRequest(new { message = "Usuário já cadastrado no banco!" });
                }
                else
                {
                    _ctx.Usuarios.Add(usuario);
                    _ctx.SaveChanges();

                    return Created("", new { message = "Usuário cadastrado com sucesso!", usuario });
                }
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível cadastrar o usuário!" });
            }
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int id)
        {
            try
            {
                Usuario? usuarioEncontrado = _ctx.Usuarios.FirstOrDefault(x => x.UsuarioId == id);

                return usuarioEncontrado != null ? Ok(usuarioEncontrado) : NotFound(new { message = "Usuário não encontrado!" });
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            try
            {
                Usuario? usuarioEncontrado = _ctx.Usuarios.Find(id);
                if (usuarioEncontrado != null)
                {
                    _ctx.Usuarios.Remove(usuarioEncontrado);
                    _ctx.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("alterar/{id}")]
        public IActionResult Alterar([FromRoute] int id, [FromBody] Usuario usuario)
        {
            try
            {
                Usuario? usuarioEncontrado = _ctx.Usuarios.FirstOrDefault(x => x.UsuarioId == id);

                if (usuarioEncontrado != null)
                {
                    // Verifique e atualize apenas os campos que estão preenchidos no payload
                    if (!string.IsNullOrEmpty(usuario.Nome))
                        usuarioEncontrado.Nome = usuario.Nome;

                    if (!string.IsNullOrEmpty(usuario.Email))
                        usuarioEncontrado.Email = usuario.Email;

                    if (!string.IsNullOrEmpty(usuario.Username))
                        usuarioEncontrado.Username = usuario.Username;

                    if (!string.IsNullOrEmpty(usuario.Senha))
                        usuarioEncontrado.Senha = usuario.Senha;

                    if (!string.IsNullOrEmpty(usuario.Telefone))
                        usuarioEncontrado.Telefone = usuario.Telefone;
                    
                    // if (usuario.Tarefas != null)
                    // {
                    //     foreach (var tarefa in usuario.Tarefas)
                    //     {
                    //         // verifico se a tarefa já existe no banco de dados
                    //         var tarefaExistente = _ctx.Tarefas.FirstOrDefault(t => t.TarefaId == tarefa.TarefaId);
                    //         if (tarefaExistente != null)
                    //             usuarioEncontrado.Tarefas.Add(tarefaExistente);
                    //     }
                    // }

                    _ctx.Usuarios.Update(usuarioEncontrado);
                    _ctx.SaveChanges();
                    return Ok(new { message = "Usuário atualizado com sucesso!" });
                }
                return NotFound(new { message = "Usuário não encontrado!" });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


    }
}
