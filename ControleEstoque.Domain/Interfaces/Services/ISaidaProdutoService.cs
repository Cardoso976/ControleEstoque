using System;
using System.Collections.Generic;

namespace ControleEstoque.Domain.Interfaces.Services
{
    public interface ISaidaProdutoService
    {
        string Add(DateTime data, Dictionary<int, int> produtos);
    }
}
