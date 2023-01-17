using Microsoft.AspNetCore.Mvc.Rendering;

namespace PenielBikeControle.Models.ViewModels
{
    public class VendaViewModel
    {
        public Venda Venda { get; set; }
        public List<string> ProtudoEstoqueIds { get; set; }
        public int ClienteId { get; set; }
        public int VendedorId { get; set; }
        public IEnumerable<SelectListItem> ListaDeProdutos { get; set; }
        public IEnumerable<SelectListItem> ListaDeClientes { get; set; }
        public IEnumerable<SelectListItem> ListaDeVendedores { get; set; }

        public VendaViewModel() { }

        public VendaViewModel(Venda venda, List<string> protudoEstoqueIds, int clienteId, int vendedorId, IEnumerable<SelectListItem> listaDeProdutos, IEnumerable<SelectListItem> listaDeClientes, IEnumerable<SelectListItem> listaDeVendedores)
        {
            Venda = venda;
            ProtudoEstoqueIds = protudoEstoqueIds;
            ClienteId = clienteId;
            VendedorId = vendedorId;
            ListaDeProdutos = listaDeProdutos;
            ListaDeClientes = listaDeClientes;
            ListaDeVendedores = listaDeVendedores;
        }
    }
}
