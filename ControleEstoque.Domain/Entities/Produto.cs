using System;

namespace ControleEstoque.Domain.Entities
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string Descricao { get; set; }
        public string Codigo { get; set; }
        public decimal PrecoCusto { get; set; }
        public decimal PrecoVenda { get; set; }
        public int QuantidadeEstoque { get; set; }
        public int UnidadeMedidaId { get; set; }
        public virtual UnidadeMedida UnidadeMedida { get; set; }
        public int GrupoProdutoId { get; set; }
        public virtual GrupoProduto GrupoProduto { get; set; }
        public int MarcaId { get; set; }
        public virtual MarcaProduto Marca { get; set; }
        public int FornecedorId { get; set; }
        public virtual Fornecedor Fornecedor { get; set; }
        public int LocalArmazenamentoId { get; set; }
        public virtual LocalArmazenamento LocalArmazenamento { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public string Imagem { get; set; }
    }
}
