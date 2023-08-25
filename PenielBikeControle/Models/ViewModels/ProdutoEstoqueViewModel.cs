using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PenielBikeControle.Models.ViewModels
{
    public class ProdutoEstoqueViewModel
    {
        public ProdutoEstoque Produto { get; set; }

        public IList<ProdutoEstoque>? ListaDeProdutos { get; set; }

        public IEnumerable<SelectListItem>? ListaTiposDeProduto { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Informe o tipo do produto.")]
        [Display(Name = "Tipo do produto")]
        public int TipoDeProdutoId { get; set; }

        public ProdutoEstoqueViewModel() { }

        public ProdutoEstoqueViewModel(ProdutoEstoque produto, IList<ProdutoEstoque>? listaDeProdutos, IEnumerable<SelectListItem>? listaTiposDeProduto, int tipoDeProdutoId)
        {
            Produto = produto;
            ListaDeProdutos = listaDeProdutos;
            ListaTiposDeProduto = listaTiposDeProduto;
            TipoDeProdutoId = tipoDeProdutoId;
        }
    }
}
