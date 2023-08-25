namespace PenielBikeControle.Models.ViewModels
{
    public class TipoProdutoViewModel
    {
        public IList<TipoProdutoEstoque> TiposDeProdutos { get; set; }
        public TipoProdutoEstoque TipoDeProduto { get; set; }

        public TipoProdutoViewModel(IList<TipoProdutoEstoque> tiposDeProduto, TipoProdutoEstoque tipoProduto)
        {
            TiposDeProdutos = tiposDeProduto;
            TipoDeProduto = tipoProduto;
        }
    }
}