using System;
using System.Collections.Generic;

namespace ControleEstoque.Application.Interface
{
    public interface IEntradaProdutoAppService
    {
        string Add(DateTime data, Dictionary<int, int> produtos);
    }
}
