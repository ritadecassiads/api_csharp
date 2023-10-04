using System.Globalization;
using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API;

[ApiController]

[Route("tarefa")]

public class TarefaController : ControllerBase
{
    private readonly AppDataContext _ctx;

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
            // valido se o titulo não está vazio
            if (string.IsNullOrWhiteSpace(tarefa.Titulo))
            {
                return BadRequest(new { message = "O título deve ser preenchido!" });
            }
            else
            {
                // verifico se ja existe no banco uma tarefa com o mesmo titulo
                var tarefaEncontrada = _ctx.Tarefas.FirstOrDefault(x => x.Titulo == tarefa.Titulo);

                if (tarefaEncontrada != null)
                {
                    return BadRequest(new { message = "Tarefa já cadastrada no banco!" });
                }
                else
                {
                    // verifico se o campo usuarioId é nulo
                    if (tarefa.UsuarioId != null)
                    {
                        Usuario? usuario = _ctx.Usuarios.Find(tarefa.UsuarioId);
                        if (usuario == null)
                        {
                            return NotFound();
                        }
                        // associo o usuario encontrado no banco a tarefa
                        tarefa.Usuario = usuario;
                    }

                    _ctx.Tarefas.Add(tarefa);
                    _ctx.SaveChanges();

                    return Created("", new { message = "Tarefa cadastrada com sucesso!", tarefa });
                }
            }
        }
        catch (Exception)
        {
            return BadRequest(new { message = "Não foi possível cadastrar a tarefa!" });
        }
    }

    [HttpGet]
    [Route("buscar/{id}")]

    public IActionResult Buscar([FromRoute] int id)
    {
        try
        {
            Tarefa? tarefaEncontrada = _ctx.Tarefas
                                        .Include(x => x.Usuario)
                                        .FirstOrDefault(x => x.TarefaId == id); // percorro os itens de tarefa do banco e verifico se o id delas é igual ao id passado por parametro na url

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
            // encontro a tarefa atraves do Id
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
        // metodo que alterera as informações da tarefa
        try
        {
            Tarefa? tarefaEncontrada = _ctx.Tarefas.FirstOrDefault(x => x.TarefaId == id);

            if (tarefaEncontrada != null)
            {
                // verifico quais campos possuem informação e altero apenas eles
                if (!string.IsNullOrEmpty(tarefa.Titulo))
                {
                    tarefaEncontrada.Titulo = tarefa.Titulo;
                }

                if (!string.IsNullOrEmpty(tarefa.Descricao))
                {
                    tarefaEncontrada.Descricao = tarefa.Descricao;
                }

                if (tarefa.UsuarioId != 0)
                {
                    Usuario? usuario = _ctx.Usuarios.Find(tarefa.UsuarioId);
                    if (usuario != null)
                    {
                        tarefaEncontrada.Usuario = usuario;
                    }
                }

                _ctx.Tarefas.Update(tarefaEncontrada);
                _ctx.SaveChanges();
                return Ok(new { message = "Tarefa atualizado com sucessa!", tarefaEncontrada });
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("alterarConcluida/{id}")]
    public IActionResult AlterarConcluida([FromRoute] int id)
    {
        // metodo que alterera apenas a tarefa para concluída - nao precisa de payload
        try
        {
            Tarefa? tarefaEncontrada = _ctx.Tarefas.FirstOrDefault(x => x.TarefaId == id);

            if (tarefaEncontrada != null)
            {
                tarefaEncontrada.Concluida = true;
                _ctx.Tarefas.Update(tarefaEncontrada);
                _ctx.SaveChanges();
                return Ok(tarefaEncontrada);
            }
            return NotFound();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}