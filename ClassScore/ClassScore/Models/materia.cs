using System.ComponentModel.DataAnnotations;

namespace ClassScore.Models;

public class materia
{
    [Required(ErrorMessage ="O titulo da matéria é obrigatório")]
    [StringLength(100)]
    public string nome { get; set; }

    [Required(ErrorMessage ="A média deve ser maior ou igual a 5")] 
    [Range(5,10,ErrorMessage = "A media deve ser maior que 5 e menor que 10")]
    public double media { get; set; }

    [Required(ErrorMessage = "o nome do professor é obrigatório")]
    [StringLength(100)]
    public string professor { get; set; }
    public int id { get; internal set; }

    //public double nota1 { get; set; }
    //public double nota2 { get; set; }
    //public double nota3 { get; set; }
    //public double Semestral { get; set; }
}
