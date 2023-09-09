using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PenielBikeControle.Models
{
    public class ItemVenda
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Produto não relacionado a venda.")]
        public int VendaId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Adicione um produto a venda.")]
        public int ProdutoEstoqueId { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Informe uma quantidade.")]
        public int Quantidade { get; set; }
        public int? ProdutoClienteId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorVendido { get; set; }
        public decimal ValorTotal { get; set; }
        public virtual ProdutoEstoque ProdutoEstoque { get; set; }
        public virtual Venda Venda { get; set; }
        public virtual ProdutoCliente? ProdutoCliente { get; set; }
        public ItemVenda() { }

        public ItemVenda(int id, Venda venda, int vendaId, ProdutoEstoque produtoEstoque, int produtoEstoqueId, ProdutoCliente? produtoCliente, int? produtoClienteId, int quantidade, decimal valorVendido, decimal valorTotal)
        {
            Id = id;
            Venda = venda;
            VendaId = vendaId;
            ProdutoEstoque = produtoEstoque;
            ProdutoEstoqueId = produtoEstoqueId;
            ProdutoCliente = produtoCliente;
            ProdutoClienteId = produtoClienteId;
            Quantidade = quantidade;
            ValorVendido = valorVendido;
            ValorTotal = valorTotal;
        }
    }
}
