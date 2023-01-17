using Microsoft.AspNetCore.Mvc.Rendering;

namespace PenielBikeControle.Models.ViewModels
{
    public class ProdutoEstoqueViewModel
    {
        public ProdutoEstoque Produto { get; set; }
        public IEnumerable<SelectListItem> ListaTiposDeProduto { get; set; }
        public int TipoDeProdutoId { get; set; }

        public ProdutoEstoqueViewModel() { }

        public ProdutoEstoqueViewModel(ProdutoEstoque produto, IEnumerable<SelectListItem> listaTiposDeProduto, int tipoDeProdutoId)
        {
            Produto = produto;
            ListaTiposDeProduto = listaTiposDeProduto;
            TipoDeProdutoId = tipoDeProdutoId;
        }
    }
}
