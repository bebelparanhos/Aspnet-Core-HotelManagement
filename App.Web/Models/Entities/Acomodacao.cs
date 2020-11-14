namespace App.Web.Models.Entities
{
    public class Acomodacao
    {
        public int AcomodacaoId {get;set;}
        public string Descricao { get; set; }
        public int Capacidade { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaAcomodacao Categoria { get; set; }
        
        public string Observacao { get; set; }

        public AcomodacaoDetalhe Detalhe { get; set; }
        public int DetalheId { get; set; }
        public int Status { get; set; }
    }
}