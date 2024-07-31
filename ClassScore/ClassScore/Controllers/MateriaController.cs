using ClassScore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassScore.Controllers;
[ApiController]
[Route("[controller]")]
public class MateriaController : ControllerBase
{
    private static List<materia> materias = new List<materia>();
    [HttpPost]
    public void AdicionaMateria([FromBody]materia materia)
    {
        materias.Add(materia);
        Console.WriteLine(materia.nome);
        Console.WriteLine(materia.professor);
        Console.WriteLine(materia.media);
    }
}