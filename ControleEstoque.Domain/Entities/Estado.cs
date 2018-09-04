using System.Collections.Generic;

namespace ControleEstoque.Domain.Entities
{
    public class Estado
    {
        public int EstadoId { get; set; }
        public string Descricao { get; set; }
        public string Uf { get; set; }
        public bool Ativo { get; set; }
        public int PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        public IEnumerable<Cidade> Cidades { get; set; }
    }
}
