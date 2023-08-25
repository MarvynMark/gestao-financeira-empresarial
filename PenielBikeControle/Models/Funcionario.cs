using System.ComponentModel.DataAnnotations;

namespace PenielBikeControle.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Favor informar o nome do funcionário")]
        [StringLength(100)]
        [Display(Name = "Funcionário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Favor informar a data de nascimento do funcionário")]
        [Display(Name = "Data de nascimento")]
        public DateOnly DataDeNascimento { get; set; }

        [StringLength(11)]
        [Display(Name = "CPF")]
        public string? Cpf { get; set; }

        [StringLength(255)]
        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }
        public bool Removido { get; set; }

        public Funcionario() { }

        public Funcionario(int id, string nome, DateOnly dataDeNascimento, string? cpf, string? endereco, bool removido)
        {
            Id = id;
            Nome = nome;
            DataDeNascimento = dataDeNascimento;
            Cpf = cpf;
            Endereco = endereco;
            Removido = removido;
        }
    }
}
