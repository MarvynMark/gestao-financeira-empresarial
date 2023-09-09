using System.ComponentModel.DataAnnotations;

namespace PenielBikeControle.Models.ViewModels
{
    public class VendaVisualizacaoViewModel
    {
        public VendaVisualizacaoViewModel() {}

        [Display(Name = "Funcionário")]
        public string Funcionario { get; set; } = string.Empty;
        public string Cliente { get; set; } = string.Empty;

        [Display(Name = "Produto do cliente")]
        public string ProdutoDoCliente { get; set; } = string.Empty;

        [Display(Name = "Data da venda")]
        public string DataDaVenda { get; set; } = string.Empty;

        [Display(Name = "Venda paga?")]
        public bool VendaPaga { get; set; } 

        [Display(Name = "Produto entregue?")]
        public bool ProdutoEntregue { get; set; }
        public string Desconto { get; set; } = string.Empty;

        [Display(Name = "Valor total")]
        public string ValorTotal { get; set; } = string.Empty;
        public IList<ItemVenda> ItensVendidos { get; set; } = new List<ItemVenda>();
        public bool ModoEdicao { get; set; }
    }
}