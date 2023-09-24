using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController] // anotação para api controller 
// estrutura basica para as controllers

[Route("tarefa")] // rota para acessar 

public class TarefaController : ControllerBase
{
    private readonly AppDataContext _ctx; // declaro uma variavel global para acessar todas as opções do contexto(como se fosse a model do mongo) em varios metodos

    public TarefaController(AppDataContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    [Route("listar")]

    public IActionResult Listar()
    {
        try
        {
            List<Tarefa> tarefas = _ctx.Tarefas.ToList();
            return tarefas.Count == 0 ? NotFound() : Ok(tarefas);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("cadastrar")]

    public IActionResult Cadastrar([FromBody] Tarefa tarefa)
    {
        try
        {
            _ctx.Tarefas.Add(tarefa);
            _ctx.SaveChanges();
            return Created("Tarefa ccadastrada com sucesso!", tarefa);
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
            Tarefa? tarefaEncontrada = _ctx.Tarefas.FirstOrDefault(x => x.TarefaId == id); // percorro os itens de tarefa do banco e verifico se o id delas é igual ao id passado por parametro na url

            return tarefaEncontrada != null ? Ok(tarefaEncontrada) : NotFound();
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
            Tarefa? tarefaEncontrada = _ctx.Tarefas.Find(id);
            if (tarefaEncontrada != null)
            {
                _ctx.Tarefas.Remove(tarefaEncontrada);
                _ctx.SaveChanges(); // sempre que houve alteração na tabela preciso chamar o saveChanges()
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
    public IActionResult Alterar([FromRoute] int id, [FromBody] Tarefa tarefa)
    {
        try
        {
            Tarefa? tarefaEncontrada = _ctx.Tarefas.FirstOrDefault(x => x.TarefaId == id);

            if (tarefaEncontrada != null)
            {
                tarefaEncontrada.Titulo = tarefa.Titulo;
                tarefaEncontrada.Descricao = tarefa.Descricao;
                // fazer a alteração do campo Concluida pra true
                _ctx.Tarefas.Update(tarefaEncontrada);
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