using System;
using System.Collections.Generic;

namespace ControleEstoque.Domain.Interfaces.Repositories
{
    public interface IEntradaProdutoRepository
    {
        string Add(DateTime data, Dictionary<int, int> produtos);
    }
}
