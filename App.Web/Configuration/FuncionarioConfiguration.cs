using System;
using App.Web.Configuration;
using App.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configuration
{
    public class FuncionarioConfiguration : PessoaConfiguration<Funcionario>
    {
        
        public override void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            base.Configure(builder);

            builder
                .ToTable("Funcionarios");
           
            builder
                .Property<bool?>("Ativo")
                .HasColumnType("bit")
                .HasDefaultValue(true);

            builder.Property<string>("Nacionalidade").HasColumnType("varchar(50)");

            builder.Ignore(h => h.PessoaId);

        }

    }
}