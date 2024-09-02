using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;

namespace ClassScore.Models;

public class Aluno
{
    [Key]
    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter exatamente 11 caracteres.")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
    public DateTime DataNascimento { get; set; }

    [Required(ErrorMessage = "O sexo é obrigatório.")]
    public bool SexoFeminino { get; set; }

    // Propriedade calculada para retornar a idade do aluno
    public int Idade
    {
        get
        {
            DateTime hoje = DateTime.Today;
            int idade = hoje.Year - DataNascimento.Year;
            if (DataNascimento.Date > hoje.AddYears(-idade)) idade--;
            return idade;
        }
    }

    // Construtor que inicializa as propriedades
    public Aluno(string cpf, string nome, DateTime dataNascimento, bool sexoFeminino)
    {
        CPF = cpf;
        Nome = nome;
        DataNascimento = dataNascimento;
        SexoFeminino = sexoFeminino;
    }
}
