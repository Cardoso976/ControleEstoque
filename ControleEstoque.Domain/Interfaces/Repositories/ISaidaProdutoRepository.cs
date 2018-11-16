using System;
using System.Collections.Generic;

namespace ControleEstoque.Domain.Interfaces.Repositories
{
    public interface ISaidaProdutoRepository
    {
        string Add(DateTime data, Dictionary<int, int> produtos);
    }
}
