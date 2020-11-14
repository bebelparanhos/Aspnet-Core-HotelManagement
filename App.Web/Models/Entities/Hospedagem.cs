using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Models.Entities
{
    public class Hospedagem
    {
        public int HospedagemId { get; set; }
        public Reserva Reserva { get; set; }
        public Hospede Hospede { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
