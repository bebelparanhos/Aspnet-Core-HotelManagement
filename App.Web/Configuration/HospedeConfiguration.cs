using App.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Configuration
{
    public class HospedeConfiguration : PessoaConfiguration<Hospede>
    {
        public override void Configure(EntityTypeBuilder<Hospede> builder)
        {
            base.Configure(builder);

            builder.ToTable("Hospedes");

            builder.Property<string>("Nacionalidade").HasColumnType("varchar(50)");

            builder.Ignore(h => h.PessoaId);

        }
    }
}
