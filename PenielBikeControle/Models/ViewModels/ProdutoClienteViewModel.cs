
namespace PenielBikeControle.Models.ViewModels
{
    public class ProdutoClienteViewModel
    {
        public ProdutoClienteViewModel() { }
        public AdicionarProdutoClienteViewModel ProdutoCliente { get; set; } = new AdicionarProdutoClienteViewModel();
        public IList<ProdutoCliente> ProdutosCliente { get; set; } = new List<ProdutoCliente>();
    }
}
