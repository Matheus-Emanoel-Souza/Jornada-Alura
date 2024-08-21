using ClassScore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClassScore.Controllers;
[ApiController]
[Route("[controller]")]
public class MateriaController : ControllerBase
{

    private static List<Materia> materias = new List<Materia>();
    private static int id = 1;

    [HttpPost("Adiciona matéria")]
    public void AdicionaMateria([FromBody] Materia materia)
    {
        materias.Add(materia);
        ImprimeMaterias(materias);
    }

    [HttpPost("/lista de matérias")]
    public void AdicionaMaterias([FromBody] List<Materia> novasMaterias)
    {
        foreach (var materia in novasMaterias)
        {
            ValidaMateria(materia);
        }

        ImprimeMaterias(materias);
    }

    private void ValidaMateria(Materia materia)
    {
        foreach(Materia Materiaexp in materias)
        {
            if(Materiaexp.nome == materia.nome!)
            {
                materias.Add(Materiaexp);
            }
        }
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
        var materia = materias.FirstOrDefault(m => m.codigo == Cdigitado);
        if (materia == null)
        {
            return NotFound(); // Retorna 404 se não encontrar a matéria com o código especificado
        }
        return materia;
    }

    [HttpGet("/Pesquisa por Nomedadisciplina")]
    public ActionResult<Materia> RecuperaMateriaNome(string nomedigitado)
    {
        var materia = materias.FirstOrDefault(m => string.Equals(m.nome.Trim(), nomedigitado.Trim(), StringComparison.OrdinalIgnoreCase));

        if (materia == null)
        {
            return NotFound("Matéria não encontrada com o nome especificado");
        }

        return Ok(materia);
    }


    [HttpGet("CargaHorariaTotalCurso")]
    public ActionResult<List<Materia>> cargaHorariaTotal()
    {
        if (materias.Count == 0)
        {
            return Ok("Não há pautas");
        }
        else
        {
            int cargahoraria = 0;
            foreach (var materia in materias)
            {
                cargahoraria += materia.ch;
            }
            return Ok(cargahoraria);
        }
    }
    [HttpGet("FiltroHoras")]
    public ActionResult<List<Materia>> FiltroHoras(int horas)
    {
        if (horas == 0)
        { 
            return Ok("Sem horas"); 
        }
        
        List<Materia> materiasComHorasIguais = materias.Where(Materia => Materia.ch == horas).ToList();
        
        if(materiasComHorasIguais.Count == 0)
        {
            return NotFound("Nenhuma matéria encontrada com carga horária especificada");
        }
        return Ok(materiasComHorasIguais);
    }

    [HttpGet("ListadeMaterias")]
    public ActionResult<List<Materia>> RetornarListaDeMaterias()
    {
        if (materias.Count == 0) 
        {
            return Ok("Não há pautas");
        }
        return Ok(materias);
    }
}