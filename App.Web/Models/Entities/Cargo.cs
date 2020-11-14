using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Models.Entities
{
    public class Cargo
    {
        public int CargoId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
