using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [ApiController]
    [Route("equipe")] // Alterado para "equipe"
    public class EquipeController : ControllerBase // Alterado para "EquipeController"
    {
        private readonly AppDataContext _ctx;

        public EquipeController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            try
            {
                List<Equipe> equipes = _ctx.Equipes.ToList();
                return equipes.Count == 0 ? NotFound() : Ok(equipes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Equipe equipe)
        {
            try
            {
                // salvo a equipe pra gerar o id
                _ctx.Equipes.Add(equipe);
                _ctx.SaveChanges();

                // Associe usuários à equipe (se houver)
                // if (equipe.Usuarios != null)
                // {
                //     foreach (var usuario in equipe.Usuarios)
                //     {
                //         // Obtenha o usuário do banco de dados
                //         var usuarioEncontrado = _ctx.Usuarios.FirstOrDefault(u => u.UsuarioId == usuario.UsuarioId);

                //         if (usuarioEncontrado != null)
                //         {
                //             // Associe o usuário à equipe
                //             usuarioEncontrado.EquipeId = equipe.EquipeId;
                //         }
                //     }
                // }

                // Associe tarefas à equipe (se houver)
                // if (equipe.Tarefas != null && equipe.Tarefas.Any())
                // {
                //     foreach (var tarefa in equipe.Tarefas)
                //     {
                //         // Obtenha a tarefa do banco de dados
                //         var tarefaEncontrada = _ctx.Tarefas.FirstOrDefault(t => t.TarefaId == tarefa.TarefaId);

                //         if (tarefaEncontrada != null)
                //         {
                //             // Associe a tarefa à equipe
                //             tarefaEncontrada.EquipeId = equipe.EquipeId;
                //         }
                //     }
                // }

                _ctx.SaveChanges();
                return Created("", new { message = "Equipe cadastrada com sucesso!", equipe });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar([FromRoute] int id)
        {
            try
            {
                Equipe? equipeEncontrada = _ctx.Equipes.FirstOrDefault(x => x.EquipeId == id); // Alterado para "Equipe"

                return equipeEncontrada != null ? Ok(equipeEncontrada) : NotFound(); // Alterado para "Equipe"
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
                Equipe? equipeEncontrada = _ctx.Equipes.Find(id); // Alterado para "Equipe"
                if (equipeEncontrada != null)
                {
                    _ctx.Equipes.Remove(equipeEncontrada); // Alterado para "Equipes"
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
        public IActionResult Alterar([FromRoute] int id, [FromBody] Equipe equipe) // Alterado para "Equipe"
        {
            try
            {
                Equipe? equipeEncontrada = _ctx.Equipes.FirstOrDefault(x => x.EquipeId == id); // Alterado para "Equipe"

                if (equipeEncontrada != null)
                {
                    equipeEncontrada.Nome = equipe.Nome;

                    _ctx.Equipes.Update(equipeEncontrada); // Alterado para "Equipes"
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
    }
}
