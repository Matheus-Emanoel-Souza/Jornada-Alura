using ClassScore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ClassScore.Controllers;
[ApiController]
[Route("[controller]")]
public class MateriaController : ControllerBase
{
    private static List<materia> materias = new List<materia>();
    private static int id = 0;
    [HttpPost]
    public void AdicionaMateria([FromBody]materia materia)
    {
        materia.id = id++;
        materias.Add(materia);
        ImprimeMaterias(materias);
    }       

    private void ImprimeMaterias(List<materia> materias)
    {
        foreach (materia materia in materias)
        {
            Console.Clear();
            Console.WriteLine($"Titulo da Matéria:{materia.nome}");
            Console.WriteLine($"Média da Matéria:{materia.media}");
            Console.WriteLine($"Professor da Matéria:{materia.professor}");
        }
    }

    [HttpGet]
    public IEnumerable<materia> RecuperaFilme()
    {
        return materias;
    }
}