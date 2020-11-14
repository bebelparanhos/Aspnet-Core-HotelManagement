using App.Web.Models.Interfaces;
using App.Web.Repositories;
using System.Collections.Generic;
using App.Web.Models.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace App.Web.Business
{
    public class AcomodacaoBusiness : BaseRepository<Acomodacao>, IAcomodacao
    { 
        public AcomodacaoBusiness(ApplicationContext contexto) : base(contexto)
        {
            
        }
        public void SalvaAcomodacao(Acomodacao acomodacao)
        {
            Acomodacao acomodacaoDB;
            
            if(acomodacao.AcomodacaoId > 0)
            {
                acomodacaoDB = GetAcomodacao(acomodacao.AcomodacaoId);
                

                acomodacaoDB.Descricao = acomodacao.Descricao;
                acomodacaoDB.Capacidade = acomodacao.Capacidade;
                acomodacaoDB.CategoriaId = acomodacao.CategoriaId;
                acomodacaoDB.Observacao = acomodacao.Observacao;
                acomodacaoDB.Detalhe.ArCondicionado = acomodacao.Detalhe.ArCondicionado;
                acomodacaoDB.Detalhe.Tamanho = acomodacao.Detalhe.Tamanho;
                acomodacaoDB.Detalhe.RoupaDeCama = acomodacao.Detalhe.RoupaDeCama;
                acomodacaoDB.Detalhe.Armario = acomodacao.Detalhe.Armario;
                acomodacaoDB.Detalhe.Banheiro = acomodacao.Detalhe.Banheiro;
                acomodacaoDB.Detalhe.Cofre = acomodacao.Detalhe.Cofre;
                acomodacaoDB.Detalhe.Tomada = acomodacao.Detalhe.Tomada;
                acomodacaoDB.Detalhe.Ventilador = acomodacao.Detalhe.Ventilador;
                acomodacaoDB.Detalhe.WiFi = acomodacao.Detalhe.WiFi;

                dbSet.Update(acomodacaoDB);
            }
          
            else
            {
                dbSet.Add(acomodacao);
            }

            contexto.SaveChanges();
        }
        public void AlteraAcomodacao(Acomodacao acomodacao, AcomodacaoDetalhe detalhe)
        {
        }

        public void RemoveAcomodacao(int id)
        {
            var acomodacao = dbSet.Find(id);
            if(acomodacao != null)
            {
                acomodacao.Status = 0;
                dbSet.Update(acomodacao);
                contexto.SaveChanges();
            }
        }

        public AcomodacaoDetalhe GetDetalhe(int id)
        {
            var detalhe = contexto.AcomodacaoDetalhe
                .Where(d => d.DetalheId == id)
                //.Include(a => a.Acomodacao)
                .FirstOrDefault();

            return detalhe;
        }

        public IList<Acomodacao> ListaAcomodacao()
        {
            return dbSet.Where(a => a.Status != 0).Include(c => c.Categoria).OrderBy(a => a.AcomodacaoId).ToList();
        }

        public Acomodacao GetAcomodacao(int id)
        {
            return dbSet.Where(a => a.AcomodacaoId == id && a.Status != 0).Include(c => c.Categoria).Include(d => d.Detalhe).FirstOrDefault();
        }
    }
}