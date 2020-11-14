using App.Web.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Repositories
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext context;
      
        public DataService(ApplicationContext contexto)
        {
            this.context = contexto;
        }

        public void SeedDatabase()
        {
            if (!context.CategoriaAcomodacoes.Any())
            {
                HelperEnum.SeedEnumData<CategoriaAcomodacao, CategoriaAcomodacaoEnum>(context.CategoriaAcomodacoes);
                context.SaveChanges();
            }

            if (!context.Cargos.Any())
            {
                List<Cargo> cargos = new List<Cargo>
                {
                    new Cargo{Descricao = "Gerente", Ativo = true },
                    new Cargo{Descricao = "Recepcionista", Ativo = true },
                    new Cargo{Descricao = "Housekeeper", Ativo = true }
                };

                context.Cargos.AddRange(cargos);
                context.SaveChanges();
            }
          
        }

    }
}
