using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace PenielBikeControle.Models
{
    public class ProdutoEstoque
    {
        public int Id { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Favor informar o nome do produto")]
        public string Nome { get; set; }

        [StringLength(50)]
        public string? Marca { get; set; }

        [StringLength(50)]
        public string? Modelo { get; set; }

        [StringLength(150)]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Favor informar o preço de custo do produto")]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Preço de custo")]
        public decimal PrecoCusto { get; set; }

        [Required(ErrorMessage = "Favor informar o preço de venda do produto")]
        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Preço de venda")]
        public decimal PrecoFinal { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        [Display(Name = "Preço mão de obra")]
        public decimal? PrecoMaoDeObra { get; set; }

        [Required(ErrorMessage = "Favor informar a quantidade de produtos em estoque")]
        [Display(Name = "Quantidade em estoque")]
        public int QtdeEmEstoque { get; set; }

        [Required(ErrorMessage = "Favor informar qual o tipo do produto")]
        [Display(Name = "Tipo do produto")]
        public int TipoProdutoId { get; set; }
        public virtual TipoProdutoEstoque TipoProduto { get; set; }

        public ProdutoEstoque() { }

        public ProdutoEstoque(int id, TipoProdutoEstoque tipoProduto, int tipoProdutoId, string nome, string? marca, string? modelo, string? descricao, decimal precoCusto, decimal precoFinal, decimal? precoMaoDeObra, int qtdeEmEstoque)
        {
            Id = id;
            TipoProduto = tipoProduto;
            TipoProdutoId = tipoProdutoId;
            Nome = nome;
            Marca = marca;
            Modelo = modelo;
            Descricao = descricao;
            PrecoCusto = precoCusto;
            PrecoFinal = precoFinal;
            PrecoMaoDeObra = precoMaoDeObra;
            QtdeEmEstoque = qtdeEmEstoque;
        }
    }
}
