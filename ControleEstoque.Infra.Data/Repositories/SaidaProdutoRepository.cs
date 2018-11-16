using System;
using System.Collections.Generic;
using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Repositories;
using ControleEstoque.Infra.Data.Contexto;

namespace ControleEstoque.Infra.Data.Repositories
{
    public class SaidaProdutoRepository : IDisposable, ISaidaProdutoRepository
    {
        protected ControleEstoqueContext Db = new ControleEstoqueContext();

        public string Add(DateTime data, Dictionary<int, int> produtos)
        {
            var ret = "";

            var numPedido = GetNextSequenceValue();

            using (var transaction = Db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var produto in produtos)
                    {
                        Db.SaidaProdutos.Add(new SaidaProduto
                        {
                            Data = data,
                            Numero = numPedido,
                            ProdutoId = produto.Key,
                            Quantidade = produto.Value
                        });
                        
                        Db.Database.ExecuteSqlCommand(@"UPDATE Produto SET QuantidadeEstoque= QuantidadeEstoque - " + produto.Value + "WHERE ProdutoId=" + produto.Key + ";");
                    }
                    transaction.Commit();
                    ret = numPedido;
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }

            }
            return ret;
        }

        public string GetNextSequenceValue()
        {
            var rawQuery = Db.Database.SqlQuery<int>("SELECT NEXT VALUE FOR SEC_SaidaProduto;");
            var task = rawQuery.SingleAsync();
            int nextVal = task.Result;

            return nextVal.ToString("D10");
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
