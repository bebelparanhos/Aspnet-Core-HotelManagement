using App.Web.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.ViewModels
{
    public class AcomodacaoDetalhadaViewModel
    {
        public Acomodacao Acomodacao { get; set; }
        public AcomodacaoDetalhe Detalhe { get; set; }
    }
}
