using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Interfaces.Repositories;
using ControleEstoque.Infra.Data.Contexto;
using System;
using System.Collections.Generic;

namespace ControleEstoque.Infra.Data.Repositories
{
    public class EntradaProdutoRepository : IEntradaProdutoRepository, IDisposable
    {
        protected ControleEstoqueContext Db = new ControleEstoqueContext();

        public string Add(DateTime data, Dictionary<int, int> produtos)
        {
            var ret = "";
            var prod = new Produto();

            var numPedido = GetNextSequenceValue();

            using (var dbContextTransaction = Db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var produto in produtos)
                    {
                        Db.EntradaProdutos.Add(new EntradaProduto
                        {
                            Numero = numPedido,
                            ProdutoId = produto.Key,
                            Quantidade = produto.Value,
                            Data = data
                        });

                        Db.Database.ExecuteSqlCommand(@"UPDATE Produto SET QuantidadeEstoque= QuantidadeEstoque + " + produto.Value + "WHERE ProdutoId=" + produto.Key + ";");
                    }

                    Db.SaveChanges();

                    dbContextTransaction.Commit();
                    ret = numPedido;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();
                    throw;
                }
            }
            return ret;
        }


        public string GetNextSequenceValue()
        {
            var rawQuery = Db.Database.SqlQuery<int>("SELECT NEXT VALUE FOR SEC_EntradaProduto;");
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
