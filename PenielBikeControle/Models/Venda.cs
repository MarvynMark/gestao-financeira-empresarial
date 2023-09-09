using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PenielBikeControle.Models
{
    public class Venda
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Range(typeof(DateTime), "1900-01-01", "9999-01-01", ErrorMessage = "Data da venda inválida.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode=true )]
        public DateTime Data { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Informe um cliente.")]
        public int ClienteId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Informe um funcionário.")]
        public int FuncionarioId { get; set; }

        [Required]
        [Display(Name = "Venda paga?")]
        public bool VendaPaga { get; set; }
        
        [Required]
        [Display(Name = "Produto entregue?")]
        public bool ProdutoEstoqueEntregue { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Desconto")]
        public decimal DescontoTotal { get; set; }
        public bool Removido { get; set; }
        public virtual IList<ItemVenda>? ItensDaVenda { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual Cliente Cliente { get; set; }
        

        public Venda() { }

        public Venda(int id, DateTime data, Cliente cliente, int clienteId, Funcionario funcionario, int funcionarioId, IList<ItemVenda>? itensDaVenda, bool vendaPaga, bool produtoEstoqueEntregue, decimal descontoTotal, bool removido)
        {
            Id = id;
            Data = data;
            Cliente = cliente;
            ClienteId = clienteId;
            Funcionario = funcionario;
            FuncionarioId = funcionarioId;
            ItensDaVenda = itensDaVenda;
            VendaPaga = vendaPaga;
            ProdutoEstoqueEntregue = produtoEstoqueEntregue;
            DescontoTotal = descontoTotal;
            Removido = removido;
        }

        [Display(Name = "Desconto")]
        public string DescontoTotalStr 
        { 
            get
            {
                return DescontoTotal.ToString("C2");
            } 
        }

        [Display(Name = "Valor total")]
        public string ValorTotalStr
        { 
            get
            {
                var valorTotalProdutos = ItensDaVenda?.Sum(i => i.ValorTotal) ?? 0;
                var valorTotal = (valorTotalProdutos - DescontoTotal).ToString("C");
                return valorTotal;
            } 
        }
    }
}
