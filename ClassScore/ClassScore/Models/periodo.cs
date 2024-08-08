using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ClassScore.Models
{
    public class Periodo
    {
        [Key]
        [Required]
        public int Numero { get; set; }
        public virtual ICollection<Materia> Materias { get; set; } = new List<Materia>();
    }
}