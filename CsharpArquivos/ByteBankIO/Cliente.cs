using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBankIO
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string? CPF { get; set; }
        public string? Profissao { get; set; }

        public Cliente(string Nome)
        {
            this.Nome = Nome;
        }
        public Cliente() 
        {
        
        }
    }
    
}
