using App.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Web.Configuration
{
    public class PessoaConfiguration<T> : IEntityTypeConfiguration<T> where T :Pessoa
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            //builder.ToTable("Pessoas");
            //builder.HasNoKey();

            builder
               .Property<string>("Nome")
               .HasColumnType("Varchar(100)")
               .IsRequired();

            builder
                .Property<string>("Email")
                .HasColumnType("Varchar(50)")
                .IsRequired();

            builder
                .Property<DateTime>("DataDeNascimento")
                .HasColumnType("datetime")
                //.HasDefaultValueSql("GetDate()")
                .IsRequired();

            builder
                .Property<Sexo>("Sexo")
                .HasColumnType("tinyint");

            builder
               .Property<string>("CPF")
               .HasColumnType("Varchar(11)")
               .IsRequired();

            //telefone talvez nao precise de config
            //builder
            //    .Property<string>("Login")
            //    .HasColumnType("varchar(50)")
            //    .IsRequired();

            //builder
            //    .Property<string>("Senha")
            //    .HasColumnType("Varchar(128)")
            //    .IsRequired();


            builder
             .Property<DateTime>("CreationDate")
             .HasDefaultValueSql("Getdate()")
             .HasColumnType("Datetime")
             .IsRequired();

            builder
             .Property<DateTime>("last_update")
             .HasDefaultValueSql("Getdate()")
             .HasColumnType("Datetime")
             .IsRequired();
        }
    }
}
