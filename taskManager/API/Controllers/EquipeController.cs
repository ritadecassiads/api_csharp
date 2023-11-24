using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API
{
    [ApiController]
    [Route("equipe")]
    public class EquipeController : ControllerBase
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
                return equipes.Count == 0 ? NoContent() : Ok(equipes);
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
                // verifico se ja existe no banco uma tarefa com o mesmo titulo
                var equipeEncontrada = _ctx.Equipes.FirstOrDefault(x => x.Nome == equipe.Nome);

                if (equipeEncontrada != null)
                {
                    return BadRequest(new { message = "Equipe já cadastrada no banco!" });
                }

                _ctx.Equipes.Add(equipe);
                _ctx.SaveChanges();

                return Created("", new { equipe.EquipeId, equipe.Nome });
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
                Equipe? equipeEncontrada = _ctx.Equipes.FirstOrDefault(x => x.EquipeId == id);

                return equipeEncontrada != null ? Ok(equipeEncontrada) : NotFound();
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
                Equipe? equipeEncontrada = _ctx.Equipes.Find(id);
                if (equipeEncontrada != null)
                {
                    _ctx.Equipes.Remove(equipeEncontrada);
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
        public IActionResult Alterar([FromRoute] int id, [FromBody] Equipe equipe)
        {
            try
            {
                Equipe? equipeEncontrada = _ctx.Equipes.FirstOrDefault(x => x.EquipeId == id);

                if (equipeEncontrada != null)
                {
                    equipeEncontrada.Nome = equipe.Nome;

                    _ctx.Equipes.Update(equipeEncontrada);
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
