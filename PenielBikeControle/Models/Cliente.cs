using System.ComponentModel.DataAnnotations;

namespace PenielBikeControle.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar o nome do cliente")]
        [StringLength(100)]
        [Display(Name = "Cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Favor informar a data de nascimento do cliente")]
        [Display(Name = "Data de nascimento")]
        public DateOnly DataDeNascimento { get; set; }

        [StringLength(11)]
        [Display(Name = "CPF")]
        public string? Cpf { get; set; }

        [StringLength(255)]
        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }
        public bool Removido { get; set; }
        public virtual IList<ProdutoCliente>? ProdutosCliente { get; set; }

        public Cliente() { }
        
        public Cliente(int id, string nome, DateOnly dataDeNascimento, string? cpf, string? endereco, IList<ProdutoCliente>? produtosCliente, bool removido)
        {
            Id = id;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Cpf = cpf;
            Endereco = endereco;
            ProdutosCliente = produtosCliente;
            Removido = removido;
        }
    }
}
