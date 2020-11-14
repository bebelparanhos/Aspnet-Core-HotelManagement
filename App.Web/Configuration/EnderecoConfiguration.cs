using App.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Configuration
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {

            builder
               .Property<string>("Logradouro")
               .HasColumnType("Varchar(100)")
               .IsRequired();

            //numero talvez nao precise de configuracao
            builder
                .Property<string>("Bairro")
                .HasColumnType("varchar(100)");

            builder
                .Property<string>("Complemento")
                .HasColumnType("varchar(50)");

            builder
                .Property<string>("Cidade")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property<string>("Estado")
                .HasColumnType("char(2)")
                .IsRequired();

            builder
                .Property<string>("Pais")
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder
                .Property<bool?>("Ativo")
                .HasColumnType("bit")
                .HasDefaultValue(true);

            builder
                .Property<string>("Telefone")
                .HasColumnType("varchar(13)")
                .IsRequired();


        }
    }
}
