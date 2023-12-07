using System.ComponentModel.DataAnnotations;

namespace PenielBikeControle.Models.ViewModels
{
    public class AdicionarClienteViewModel 
    {
        public int Id { get; set; }

        [Display(Name = "Cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Favor informar a data de nascimento do cliente")]
        [Display(Name = "Data de nascimento")]
        public string DataDeNascimentoStr { get; set; }

        [Display(Name = "CPF")]
        public string? Cpf { get; set; }

        public string? Telefone { get; set; }

        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }

        public AdicionarClienteViewModel()
        {
        }

        public AdicionarClienteViewModel(string nome, string dataDeNascimentoStr, string? endereco, string? cpf, string? telefone)
        {
                Nome = nome;
                DataDeNascimentoStr = dataDeNascimentoStr;
                Endereco = endereco;
                Cpf = cpf;
                Telefone = telefone;
        }
    }
}