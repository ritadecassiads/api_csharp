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
                // verifico se tem alguma informação no payload na colection do relacionamento
                // if(equipe.EquipeUsuarioTarefas != null){
                //     // se houver, eu crio uma instancia de da tabela de relacionamento
                //     EquipeUsuarioTarefa Relacionamento = new();

                // }                
                _ctx.Equipes.Add(equipe);

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
