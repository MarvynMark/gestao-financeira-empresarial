using System.ComponentModel.DataAnnotations;

namespace PenielBikeControle.Models
{
    public class Cliente
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar o nome do cliente")]
        [StringLength(100)]
        [Display(Name = "Cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Favor informar a data de nascimento do cliente")]
        [Display(Name = "Data de nascimento")]
        public DateOnly DataDeNascimento { get; set; }

        [StringLength(14)]
        [Display(Name = "CPF")]
        public string? Cpf { get; set; }

        [StringLength(11)]
        public string? Telefone { get; set; }

        [StringLength(255)]
        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }
        public bool Removido { get; set; }
        public virtual IList<ProdutoCliente>? ProdutosCliente { get; set; }

        public Cliente() { }
        
        public Cliente(int id, string nome, DateOnly dataDeNascimento, string? cpf, string? telefone, string? endereco, IList<ProdutoCliente>? produtosCliente, bool removido)
        {
            Id = id;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Cpf = cpf;
            Telefone = telefone;
            Endereco = endereco;
            ProdutosCliente = produtosCliente;
            Removido = removido;
        }

        public string TelefoneStr
        {
            get 
            {
                if (Telefone is not null)
                {
                    if (Telefone.Length == 10)
                    {
                        return string.Format("({0}) {1}-{2}",
                                Telefone[..2],
                                Telefone.Substring(2, 4),
                                Telefone[6..]);
                    }
                    else if (Telefone.Length == 11)
                    {
                         return string.Format("({0}) {1}-{2}",
                                Telefone[..2],
                                Telefone.Substring(2, 5),
                                Telefone[7..]);
                    }
                    else
                    {
                        return Telefone;
                    }
                }
                else
                {
                    return string.Empty;
                }   
            }
        }
    }
}
