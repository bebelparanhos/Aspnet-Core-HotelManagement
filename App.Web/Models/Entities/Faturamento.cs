using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Models.Entities
{
    public class Faturamento
    {
        public int FaturamentoId { get; set; }
        public Hospedagem Hospedagem { get; set; }
        public DateTime DataFaturamento { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
