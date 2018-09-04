using System.Collections.Generic;

namespace ControleEstoque.Domain.Entities
{
    public class MarcaProduto
    {
        public int MarcaProdutoId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
