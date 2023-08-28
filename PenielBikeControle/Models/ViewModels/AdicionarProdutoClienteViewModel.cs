using Microsoft.AspNetCore.Mvc.Rendering;

namespace PenielBikeControle.Models.ViewModels
{
    public class AdicionarProdutoClienteViewModel : ProdutoCliente
    {
        public AdicionarProdutoClienteViewModel() : base() { }
        public IEnumerable<SelectListItem> Clientes { get; set; } = new List<SelectListItem>();
    }
}