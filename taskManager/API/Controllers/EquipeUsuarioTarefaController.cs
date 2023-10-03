using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("relacionamento")]
    public class EquipeUsuarioTarefaController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public EquipeUsuarioTarefaController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            try
            {
                List<EquipeUsuarioTarefa> equipeUsuarioTarefas = _ctx.EquipeUsuarioTarefas.ToList();
                return equipeUsuarioTarefas.Count == 0 ? NotFound() : Ok(equipeUsuarioTarefas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] EquipeUsuarioTarefa equipeUsuarioTarefa)
        {
            try
            {    
                _ctx.EquipeUsuarioTarefas.Add(equipeUsuarioTarefa);
                _ctx.SaveChanges();
                return Created("", new { message = "Associação cadastrada com sucesso!", equipeUsuarioTarefa });
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
                EquipeUsuarioTarefa? equipeUsuarioTarefaEncontrada = _ctx.EquipeUsuarioTarefas
                    .Include(x => x.Equipe)
                    .Include(x => x.Usuario)
                    .Include(x => x.Tarefa)
                    .FirstOrDefault(x => x.EquipeUsuarioTarefaId == id);

                return equipeUsuarioTarefaEncontrada != null ? Ok(equipeUsuarioTarefaEncontrada) : NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            try
            {
                EquipeUsuarioTarefa? equipeUsuarioTarefaEncontrada = _ctx.EquipeUsuarioTarefas.Find(id);
                if (equipeUsuarioTarefaEncontrada != null)
                {
                    _ctx.EquipeUsuarioTarefas.Remove(equipeUsuarioTarefaEncontrada);
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
        public IActionResult Alterar([FromRoute] int id, [FromBody] EquipeUsuarioTarefa equipeUsuarioTarefa)
        {
            try
            {
                EquipeUsuarioTarefa? equipeUsuarioTarefaEncontrada = _ctx.EquipeUsuarioTarefas.Find(id);

                if (equipeUsuarioTarefaEncontrada != null)
                {
                    equipeUsuarioTarefaEncontrada.EquipeId = equipeUsuarioTarefa.EquipeId;
                    equipeUsuarioTarefaEncontrada.UsuarioId = equipeUsuarioTarefa.UsuarioId;
                    equipeUsuarioTarefaEncontrada.TarefaId = equipeUsuarioTarefa.TarefaId;

                    _ctx.EquipeUsuarioTarefas.Update(equipeUsuarioTarefaEncontrada);
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