using App.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Configuration
{
    public class CategoriaAcomodacaoConfiguration : IEntityTypeConfiguration<CategoriaAcomodacao>
    {
        public void Configure(EntityTypeBuilder<CategoriaAcomodacao> builder)
        {
            builder
               .Property(e => e.Id)
               .HasConversion<int>();

            //builder
            //    .HasData(Enum.GetValues(typeof(CategoriaAcomodacaoEnum)).Cast<CategoriaAcomodacaoEnum>()
            //    .Select(e => new CategoriaAcomodacao()
            //    {
            //        Id = e,
            //        Name = e.ToString()
            //    })
            //);


        }
    }
}
