using System;
using App.Web.Configuration;
using App.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace App.Data.Configuration
{
    public class UsuarioConfiguration:IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder
                .ToTable("Usuario");

            builder
                .Property(u => u.Id)
                .HasColumnName("UsuarioId");

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

            // Each User can have many UserClaims
            builder.HasMany(e => e.UserClaims)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

            // Each User can have many UserLogins
            builder.HasMany(e => e.UserLogins)
                .WithOne()
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            // Each User can have many UserTokens
            builder.HasMany(e => e.UserTokens)
                .WithOne()
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany(e => e.UserRoles)
                .WithOne(e => e.User)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
           
        }
    }
}