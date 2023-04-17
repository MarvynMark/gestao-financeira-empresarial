using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PenielBikeControle.Models
{
    public class ProdutoCliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar o nome do produto do cliente")]
        [StringLength(100)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string? Marca { get; set; }

        [StringLength(50)]
        public string? Modelo { get; set; }

        [StringLength(150)]
        [Display(Name = "Descrição")]
        public string? Descricao { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public ProdutoCliente() { }

        public ProdutoCliente(string nome, string? marca, string? modelo, string? descricao, Cliente cliente, int clienteId)
        {
            Nome = nome;
            Marca = marca;
            Modelo = modelo;
            Descricao = descricao;
            Cliente = cliente;
            ClienteId = clienteId;
        }
    }
}
