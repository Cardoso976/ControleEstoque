using System;
using System.Collections.Generic;

namespace ControleEstoque.Domain.Interfaces.Services
{
    public interface IEntradaProdutoService
    {
        string Add(DateTime data, Dictionary<int, int> produtos);
    }
}
