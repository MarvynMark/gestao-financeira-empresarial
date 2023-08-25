using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PenielBikeControle.Models
{
    public class Venda
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a data da venda")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm}", ApplyFormatInEditMode=true )]
        public DateTime Data { get; set; }
        public int ClienteId { get; set; }
        public int FuncionarioId { get; set; }

        [Display(Name = "Venda paga")]
        public bool VendaPaga { get; set; }
        
        [Display(Name = "Produto entregue")]
        public bool ProdutoEstoqueEntregue { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Desconto")]
        public decimal DescontoTotal { get; set; }
        public bool Removido { get; set; }
        public virtual IList<ItemVenda>? ItensDaVenda { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual Cliente Cliente { get; set; }
        
        //public double ValorTotal { get; set; }

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
    }
}
