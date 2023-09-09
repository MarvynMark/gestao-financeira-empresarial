using System.ComponentModel.DataAnnotations;

namespace PenielBikeControle.Models
{
    public class Funcionario
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome do funcionário.")]
        [StringLength(100)]
        [Display(Name = "Funcionário")]
        public string Nome { get; set; }

        [Range(typeof(DateOnly), "1900-01-01", "9999-01-01", ErrorMessage = "Data de nascimento inválida.")]
        [Display(Name = "Data de nascimento")]
        public DateOnly DataDeNascimento { get; set; }

        [StringLength(14)]
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
