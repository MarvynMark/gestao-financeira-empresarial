using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PenielBikeControle.Models.ViewModels
{
    public class ProdutoEstoqueViewModel
    {
        public ProdutoEstoque Produto { get; set; }

        public IEnumerable<SelectListItem> ListaTiposDeProduto { get; set; }

        [Required(ErrorMessage = "Favor informar o tipo do produto")]
        [Display(Name = "Tipo do produto")]
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
