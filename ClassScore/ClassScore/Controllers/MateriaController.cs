﻿using ClassScore.Models;
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
            materias.Add(materia);
        }
        ImprimeMaterias(materias);
    }

    private void ImprimeMaterias(List<Materia> materias)
    {
        
        foreach (Materia materia in materias)
        {
            Console.WriteLine($"codigo:{materia.Codigo}");
            Console.WriteLine($"nome:{materia.Nome}");
            Console.WriteLine($"ch:{materia.Ch}");
            Console.WriteLine($"periodo:{materia.Periodo}");
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }

    [HttpGet("{codigo}/Pesquisa por codigo")]
    public Materia? RecuperaMateria(int codigo)
    {
        return materias.FirstOrDefault(materia => materia.Codigo == codigo);
    }

    [HttpGet("{nomedadisciplina}/Pesquisa por Nome")]
    public ActionResult<Materia> RecuperaMateriaNome(string nome)
    {
        return materias.FirstOrDefault(materia => materia.Nome == nome);
    }

    [HttpGet("{cargahoraria}/ListaDeMateriasComcargahorariaIgual")]
    public LinkedList<Materia> RecuperaMateriasMedia(double cargahoraria)
    {
    var materiasComMediaIgual = materias.Where(m => m.Ch == cargahoraria).ToList();
    LinkedList<Materia> linkedListMaterias = new LinkedList<Materia>(materiasComMediaIgual);
    return linkedListMaterias;
    }
    
}