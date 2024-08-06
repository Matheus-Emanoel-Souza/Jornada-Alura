using System.ComponentModel.DataAnnotations;

namespace ClassScore.Models
{
    public class Materia
    {
        [Required(ErrorMessage = "O código da matéria é obrigatório")]
        [Range(10000, 99999, ErrorMessage = "O código da matéria deve ter 5 dígitos")]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "O nome da disciplina é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome da disciplina deve ter no máximo 100 caracteres")]
        [MinLength(1, ErrorMessage = "O nome da disciplina deve ter pelo menos 1 caractere")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A carga horária da matéria é obrigatória")]
        [Range(30, 90, ErrorMessage = "A carga horária deve estar entre 30 e 60 horas")]
        public int Ch { get; set; }

        [Required(ErrorMessage = "O período da matéria é obrigatório")]
        [Range(1, 10, ErrorMessage = "O período deve estar entre 1 e 10")]
        public int Periodo { get; set; }
    }
}

