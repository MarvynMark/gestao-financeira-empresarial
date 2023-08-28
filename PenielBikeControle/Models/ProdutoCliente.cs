using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PenielBikeControle.Models
{
    public class ProdutoCliente
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do produto do cliente.")]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string? Marca { get; set; }

        [StringLength(50)]
        public string? Modelo { get; set; }

        [StringLength(150)]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Informe um cliente válido.")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }
        public bool Removido { get; set; }
        public virtual Cliente Cliente { get; set; }
        public ProdutoCliente() { }

        public ProdutoCliente(string nome, string? marca, string? modelo, string? descricao, Cliente cliente, int clienteId, bool removido)
        {
            Nome = nome;
            Marca = marca;
            Modelo = modelo;
            Descricao = descricao;
            Cliente = cliente;
            ClienteId = clienteId;
            Removido = removido;
        }
    }
}
