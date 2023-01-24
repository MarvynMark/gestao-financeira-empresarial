using Microsoft.AspNetCore.Mvc.Rendering;

namespace PenielBikeControle.Models.ViewModels
{
    public class ProdutoClienteViewModel
    {
        public ProdutoCliente ProdutoCliente { get; set; }
        public IEnumerable<SelectListItem> ListaClientes { get; set; }
        public int ClienteId { get; set; }

        public ProdutoClienteViewModel()  {  }

        public ProdutoClienteViewModel(ProdutoCliente produtoCliente, IEnumerable<SelectListItem> listaClientes, int clienteId)
        {
            ProdutoCliente = produtoCliente;
            ListaClientes = listaClientes;
            ClienteId = clienteId;
        }
    }
}
