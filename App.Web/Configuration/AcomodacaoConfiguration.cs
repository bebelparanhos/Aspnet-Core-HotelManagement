using App.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Web.Configuration
{
    public class AcomodacaoConfiguration : IEntityTypeConfiguration<Acomodacao>
    {
        public void Configure(EntityTypeBuilder<Acomodacao> builder)
        {
            builder
                .ToTable("Acomodacao");
            
            builder
                .Property<string>("Descricao")
                .HasColumnType("Varchar(100)")
                .IsRequired();

            builder
                .Property<string>("Observacao")
                .HasColumnType("varchar(100)");

            builder
                .HasOne(a => a.Categoria)
                .WithMany(c => c.Acomodacoes)
                .HasForeignKey(a => a.CategoriaId);

            builder
                .Property<int>("Status")
                .HasDefaultValueSql("1");
        }
    }
}