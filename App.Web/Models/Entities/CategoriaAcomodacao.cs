using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Models.Entities
{
    public class CategoriaAcomodacao: EnumBase<CategoriaAcomodacaoEnum>
    {
        public ICollection<Acomodacao> Acomodacoes { get; set; }
    }
}
