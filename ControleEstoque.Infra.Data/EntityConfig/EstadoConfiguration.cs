using System.Data.Entity.ModelConfiguration;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Infra.Data.EntityConfig
{
    public class EstadoConfiguration : EntityTypeConfiguration<Estado>
    {
        public EstadoConfiguration()
        {
            HasKey(e => e.EstadoId);

            Property(e => e.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Uf)
                .IsRequired()
                .HasMaxLength(2);

            HasRequired(e => e.Pais)
                .WithMany()
                .HasForeignKey(e => e.PaisId);
        }
    }
}
