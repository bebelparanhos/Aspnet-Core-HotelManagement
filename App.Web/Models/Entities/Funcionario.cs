using System;
using System.Collections.Generic;

namespace App.Web.Models.Entities{
    public  class Funcionario:Pessoa
    {
        public int FuncionarioId {get; set; }
  
        public bool? Ativo {get;set;}

        public int CargoId { get; set; }

        public Cargo Cargo { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

    }
}
