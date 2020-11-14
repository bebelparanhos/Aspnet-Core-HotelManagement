using System.Collections.Generic;
using App.Web.Models.Entities;

namespace App.Web.Models.Interfaces
{
    public interface IAcomodacao
    {
        
        void SalvaAcomodacao(Acomodacao acomodacao);
        IList<Acomodacao> ListaAcomodacao();
        void AlteraAcomodacao(Acomodacao acomodacao, AcomodacaoDetalhe detalhe);
        void RemoveAcomodacao(int id);
        AcomodacaoDetalhe GetDetalhe(int id);
        Acomodacao GetAcomodacao(int id);
    }
}