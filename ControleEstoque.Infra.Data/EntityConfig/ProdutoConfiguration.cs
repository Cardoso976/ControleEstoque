using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleEstoque.Domain.Entities;

namespace ControleEstoque.Infra.Data.EntityConfig
{
    public class ProdutoConfiguration : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            HasKey(p => p.ProdutoId);

            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(150);

            Property(p => p.Codigo)
                .IsRequired()
                .HasMaxLength(12);

            Property(p => p.PrecoCusto)
                .IsRequired()
                .HasPrecision(12, 2);

            Property(p => p.PrecoVenda)
                .IsRequired()
                .HasPrecision(12, 2);

            Property(p => p.QuantidadeEstoque)
                .IsOptional();

            HasRequired(p => p.UnidadeMedida)
                .WithMany()
                .HasForeignKey(p => p.UnidadeMedidaId);

            HasRequired(p => p.GrupoProduto)
                .WithMany()
                .HasForeignKey(p => p.GrupoProdutoId);

            HasRequired(p => p.GrupoProduto)
                .WithMany()
                .HasForeignKey(p => p.GrupoProdutoId);

            HasRequired(p => p.Marca)
                .WithMany()
                .HasForeignKey(p => p.MarcaId);

            HasRequired(p => p.Fornecedor)
                .WithMany()
                .HasForeignKey(p => p.FornecedorId);

            HasRequired(p => p.LocalArmazenamento)
                .WithMany()
                .HasForeignKey(p => p.LocalArmazenamentoId);
        }
    }
}
