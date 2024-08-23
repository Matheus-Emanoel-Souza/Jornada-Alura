using ClassScore.data;
using ClassScore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;
using System.Security.Cryptography;

namespace ClassScore.Controllers;
[ApiController]
[Route("[controller]")]
public class MateriaController : ControllerBase
{

    private materiacontext _context;

    public MateriaController(materiacontext context)
    {
        _context = context;
    }

    [HttpPost("ZERAR BANCO")]
    public IActionResult LimpaBanco([FromBody] int SenhaInserida)
    {
        string msg = "Aguarde";
        int senha = 123456789;
        if (SenhaInserida == senha)
        {
            RemoverTodasMaterias();
            msg = "Todas as matérias foram removidas com sucesso!";
        }
        else
        {
            msg = "Senha incorreta!";
        }
        return Ok(msg);
    }

    [HttpPost("Remove Materia")]
    public IActionResult RemoveMateria([FromBody] string nomemateria)
    {
        string msg = RemoverMateriaPorNome(nomemateria);
        return Ok(msg);
    }

    private void RemoverTodasMaterias()
    {
        _context.materia.RemoveRange(_context.materia);
        _context.SaveChanges();
    }

    private string RemoverMateriaPorNome(string nomemateria)
    {
        var materia = _context.materia.FirstOrDefault(m => m.nome == nomemateria);
        if (materia != null)
        {
            _context.materia.Remove(materia);
            _context.SaveChanges();
            return $"{nomemateria} foi removida com sucesso!";
        }
        else
        {
            return $"{nomemateria} não está na pauta";
        }
    }


    [HttpPost("/Adiciona matéria")]
    public IActionResult AdicionaMateria([FromBody] Materia materia)
    {
        ValidaMateria(materia);
        _context.SaveChanges();
        return Ok("Materia adicionada com sucesso!");
        //ImprimeMaterias(); => metodo trocado por inumerable.
    }

    [HttpPost("/Adiciona lista de matérias")]
    public IActionResult AdicionaMaterias([FromBody] List<Materia> novasMaterias)
    {
        //=>If para prevenir travamento de sistema futuramente, no momento vou explorar a quantidade de dados que o sistema aguenta subir.
        //if (novasMaterias.Count <= 10)
        //{
            try
            {
                if (novasMaterias == null || !novasMaterias.Any())
                {
                    return BadRequest("A lista de matérias está vazia.");
                }


                foreach (var materia in novasMaterias)
                {
                    ValidaMateria(materia);
                }


                _context.SaveChanges();

                return Ok("Matérias adicionadas com sucesso!");
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Ocorreu um erro ao adicionar as matérias: {ex.Message}");
            }
        //}
        //else
        //{
        //    return BadRequest("Repasse 10 matérias por vez");
        //}
    }

    private IActionResult ValidaMateria(Materia materia)
    {
        // Verifica se já existe uma matéria com o mesmo código no banco de dados
        var materiaExistente = _context.materia.SingleOrDefault(m => m.codigo == materia.codigo);

        // Se a matéria não existir, adiciona-a ao contexto
        if (materiaExistente == null)
        {
            _context.materia.Add(materia);
        }
        else
        {
            return Ok($"{materia.nome} não pode ser registrada ! \n" +
                $"Matéria já Registrada!!");
        }
        return Ok();
    }

    [HttpGet("retornar")]
    public IEnumerable<Materia> RecupMateria()
    {
        return _context.materia;
    }

    private void ImprimeMaterias(List<Materia> materias)
    {

        foreach (Materia materia in materias)
        {
            Console.WriteLine($"codigo:{materia.codigo}");
            Console.WriteLine($"nome:{materia.nome}");
            Console.WriteLine($"ch:{materia.ch}");
            Console.WriteLine($"periodo:{materia.periodo}");
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }

    [HttpGet("{Cdigitado}/PesquisaCodigo")]
    public ActionResult<Materia> RecuperaMateria(int Cdigitado)
    {
        var materia = _context.materia.FirstOrDefault(m => m.codigo == Cdigitado);
        if (materia == null)
        {
            return NotFound(); // Retorna 404 se não encontrar a matéria com o código especificado
        }
        return materia;
    }

    [HttpGet("/Pesquisa por Nomedadisciplina")]
    public ActionResult<Materia> RecuperaMateriaNome(string nomedigitado)
    {
        string msg = "Matéria não encontrada!";
        foreach(Materia materia in  _context.materia)
        {
            if(materia.nome == nomedigitado)
            {
                msg = "Matéria encontrada e removida com sucesso!";
                _context.materia.Remove(materia);
            }
        }
        _context.SaveChanges();
        return Ok(msg);
    }

    [HttpGet("CargaHorariaTotalCurso")]
    public ActionResult<List<Materia>> cargaHorariaTotal()
    {
        if (_context.materia.ToList().Count == 0)
        {
            return Ok("Não há pautas");
        }
        else
        {
            int cargahoraria = 0;
            foreach (var materia in _context.materia)
            {
                cargahoraria += materia.ch;
            }
            const int horasPorDia = 24;
            int dias = cargahoraria / horasPorDia;
            int horasRestantes = cargahoraria % horasPorDia;

            string resultado = $"{dias} dias, {horasRestantes} horas";

            return Ok(resultado);
        }
    }

    [HttpGet("FiltroHoras")]
    public ActionResult<List<Materia>> FiltroHoras(int horas)
    {
        if (horas == 0)
        {
            return Ok("Sem horas");
        }

        List<Materia> materiasComHorasIguais = _context.materia.Where(Materia => Materia.ch == horas).ToList();

        if (materiasComHorasIguais.Count == 0)
        {
            return NotFound("Nenhuma matéria encontrada com carga horária especificada");
        }
        return Ok(materiasComHorasIguais);
    }

    [HttpGet("ListadeMaterias")]
    public ActionResult<List<Materia>> RetornarListaDeMaterias()
    {
        if (_context.materia.ToList().Count == 0)
        {
            return Ok("Não há pautas");
        }
        return Ok(_context.materia);

    }

}