using Microsoft.EntityFrameworkCore;
using App.Web.Models.Entities;
using App.Data.Configuration;
using App.Web.Configuration;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace App.Web.Repositories
{
    public class ApplicationContext : IdentityDbContext<
            Usuario, Role, Guid,
            IdentityUserClaim<Guid>, UsuarioRole, IdentityUserLogin<Guid>,
           IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public DbSet<CategoriaAcomodacao> CategoriaAcomodacoes { get; set; }
        public DbSet<AcomodacaoDetalhe> AcomodacaoDetalhe { get; set; }
        public DbSet<Acomodacao> Acomodacoes { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public ApplicationContext(DbContextOptions option):base(option)
        {
            
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().ToTable("Roles");

            // Each Role can have many entries in the UserRole join table
            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithOne(e => e.Role)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
        
            modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UsuarioClaims");

            modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UsuarioLogins");
  
            modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UsuarioTokens");

            modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");

            modelBuilder.Entity<UsuarioRole>().ToTable("UsuarioRoles");

            modelBuilder.ApplyConfiguration(new FuncionarioConfiguration());
            modelBuilder.ApplyConfiguration(new AcomodacaoConfiguration());
            modelBuilder.ApplyConfiguration(new CategoriaAcomodacaoConfiguration());
            modelBuilder.ApplyConfiguration(new AcomodacaoDetalheConfiguration());
            modelBuilder.ApplyConfiguration(new HospedeConfiguration());
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

      
    }
}