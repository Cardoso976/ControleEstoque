using System;
using System.Collections.Generic;
using ControleEstoque.Domain.Entities.Enum;

namespace ControleEstoque.Domain.Entities
{
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public string RazaoSocial { get; set; }
        public string NumDocumento { get; set; }
        public TipoPessoa Tipo { get; set; }
        public string Telefone { get; set; }
        public string  Contato { get; set; }
        public DateTime DataCadastro { get; set; }
        public int EnderecoId { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cep { get; set; }
        public Pais Pais { get; set; }
        public int PaisId { get; set; }
        public Estado Estado { get; set; }
        public int EstadoId { get; set; }
        public Cidade Cidade { get; set; }
        public int CidadeId { get; set; }
        public bool Ativo { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }
    }
}
