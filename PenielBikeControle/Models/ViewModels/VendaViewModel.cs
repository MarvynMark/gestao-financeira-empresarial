using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PenielBikeControle.Models.ViewModels
{
    public class VendaViewModel
    {
        public Venda Venda { get; set; } = new Venda();
        public List<string> ListaProtudoEstoqueIds { get; set; }

        [Required(ErrorMessage = "Favor informar o {0}")]
        [Display(Name = "Produto")]
        public string ProtudoEstoqueId { get; set; }

        [Required(ErrorMessage = "Favor informar o {0}")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Favor informar o {0}")]
        [Display(Name = "Funcionário")]
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "Favor informar o {0}")]
        [Display(Name = "Produto do cliente")]
        public int ProdutoClienteId { get; set; }
        //public IEnumerable<SelectListItem> ListaDeProdutos { get; set; }
        public IEnumerable<SelectListItem> ListaDeClientes { get; set; }
        public IEnumerable<SelectListItem> ListaDeFuncionarios { get; set; }
        public IEnumerable<SelectListItem> ListaProdutosCliente { get; set; }

        public IList<ProdutoEstoque> ListaDeProdutos { get; set; }
        public string DataNaTela { get; set; } = DateTime.Now.ToString("dd/MM/yyyy - dddd");
        public int Quantidade { get; set; }
        //public IEnumerable<string> ListaQuantidade { get; set; }


        public VendaViewModel() { }

        public VendaViewModel(Venda venda, List<string> listaProtudoEstoqueIds, string protudoEstoqueId, int clienteId, int funcionarioId, int produtoClienteId, IEnumerable<SelectListItem> listaDeClientes, IEnumerable<SelectListItem> listaDeFuncionarios, IEnumerable<SelectListItem> listaProdutosCliente, IList<ProdutoEstoque> listaDeProdutos, string dataNaTela, int quantidade)
        {
            Venda = venda;
            ListaProtudoEstoqueIds = listaProtudoEstoqueIds;
            ProtudoEstoqueId = protudoEstoqueId;
            ClienteId = clienteId;
            FuncionarioId = funcionarioId;
            ProdutoClienteId = produtoClienteId;
            ListaDeClientes = listaDeClientes;
            ListaDeFuncionarios = listaDeFuncionarios;
            ListaProdutosCliente = listaProdutosCliente;
            ListaDeProdutos = listaDeProdutos;
            DataNaTela = dataNaTela;
            Quantidade = quantidade;
        }
    }
}
