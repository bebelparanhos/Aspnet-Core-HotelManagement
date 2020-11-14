using App.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace App.Web.Configuration
{
    public class AcomodacaoDetalheConfiguration : IEntityTypeConfiguration<AcomodacaoDetalhe>
    {
        public void Configure(EntityTypeBuilder<AcomodacaoDetalhe> builder)
        {
            builder
                .HasKey("DetalheId");

            //builder
            //    .Property<Acomodacao>("Acomodacao")
            //    .
            builder
                .Property<float>("Tamanho")
                .HasColumnType("decimal(10,2)");

            builder
                .Property<bool>("Banheiro")
                .HasColumnType("bit");

            builder
                .Property<bool>("WiFi")
                .HasColumnType("bit");

            builder
                .Property<bool>("Armario")
                .HasColumnType("bit");

            builder
                .Property<bool>("RoupaDeCama")
                .HasColumnType("bit");

            builder
                .Property<bool>("ArCondicionado")
                .HasColumnType("bit");

            builder
                .Property<bool>("Ventilador")
                .HasColumnType("bit");

            builder
                .Property<bool>("Cofre")
                .HasColumnType("bit");

            builder
                .Property<bool>("Tomada")
                .HasColumnType("bit");

            //builder.HasOne(c => c.Acomodacao).WithOne(a => a.AcomodacaoId);
        }
    }
}
