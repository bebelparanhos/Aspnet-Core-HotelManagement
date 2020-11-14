using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Models.Entities
{
    public class Hospede:Pessoa
    {
        public int HospedeId { get; set; }

        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        //public ICollection<Endereco> Enderecos { get; set; }
    }
}
