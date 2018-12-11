namespace ControleEstoque.MVC.ViewModels
{
    public class RetornoViewModel
    {
        public int Id { get; set; }
        public string Sucesso { get; set; }
        public string Erro { get; set; }
        public object Entidade { get; set; }
    }
}