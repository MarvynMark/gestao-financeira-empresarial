using Microsoft.AspNetCore.Mvc.Rendering;

namespace PenielBikeControle.Models.ViewModels
{
    public class VendaViewModel
    {
        public Venda Venda { get; set; }
        public List<string> ProtudoEstoqueIds { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; }
        public int ProdutoClienteId { get; set; }
        public IEnumerable<SelectListItem> ListaDeProdutos { get; set; }
        public IEnumerable<SelectListItem> ListaDeClientes { get; set; }
        public IEnumerable<SelectListItem> ListaDeFuncionarios { get; set; }
        public IEnumerable<SelectListItem> ListaProdutosCliente { get; set; }

        public VendaViewModel() { }

        public VendaViewModel(Venda venda, List<string> protudoEstoqueIds, int clienteId, int funcionarioId, IEnumerable<SelectListItem> listaDeProdutos, IEnumerable<SelectListItem> listaDeClientes, IEnumerable<SelectListItem> listaDeFuncionarios)
        {
            Venda = venda;
            ProtudoEstoqueIds = protudoEstoqueIds;
            ClienteId = clienteId;
            FuncionarioId = funcionarioId;
            ListaDeProdutos = listaDeProdutos;
            ListaDeClientes = listaDeClientes;
            ListaDeFuncionarios = listaDeFuncionarios;
        }
    }
}
