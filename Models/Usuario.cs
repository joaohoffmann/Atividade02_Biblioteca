using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Biblioteca.Models
{
    public class Usuario
    {
        public int Id {get; set;}
        public string Login {get;set;}
        public string Senha {get;set;}



        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        
        }
    }

  
}