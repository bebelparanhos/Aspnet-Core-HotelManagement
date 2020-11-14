using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Models.Entities
{
    public class AcomodacaoDetalhe
    {
        public int DetalheId { get; set; }
        //public Acomodacao Acomodacao { get; set; }
        //public int AcomodacaoId { get; set; }
        public float Tamanho { get; set; }
        public bool Banheiro { get; set; }
        public bool WiFi { get; set; }
        public bool Armario { get; set; }
        public bool RoupaDeCama { get; set; }
        public bool ArCondicionado { get; set; }
        public bool Ventilador { get; set; }
        public bool Cofre { get; set; }
        public bool Tomada { get; set; }
    }
}
