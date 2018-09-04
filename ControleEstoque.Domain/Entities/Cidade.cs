using System.Collections.Generic;

namespace ControleEstoque.Domain.Entities
{
    public class Cidade
    {
        public int CidadeId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public int EstadoId { get; set; }
        public virtual Estado Estado { get; set; }
        public IEnumerable<Endereco> Enderecos { get; set; }
    }
}
