using System.Data.Entity.ModelConfiguration;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Infra.Data.EntityConfig
{
    public class LocalArmazenamentoConfiguration : EntityTypeConfiguration<LocalArmazenamento>
    {
        public LocalArmazenamentoConfiguration()
        {
            HasKey(l => l.LocalArmazenamentoId);

            Property(l => l.Descricao)
                .IsRequired()
                .HasMaxLength(150);
        }
    }
}
