using System.ComponentModel.DataAnnotations;

namespace PenielBikeControle.Models.ViewModels
{
    public class AdicionarFuncionarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        [Display(Name = "Data de nascimento")]
        public string DataDeNascimentoStr { get; set; }

        [Display(Name = "CPF")]
        public string? Cpf { get; set; }

        [Display(Name = "Endereço")]
        public string? Endereco { get; set; }

        public AdicionarFuncionarioViewModel()
        {
        }

        public AdicionarFuncionarioViewModel(string nome, string dataDeNascimentoStr, string? cpf, string? endereco)
        {
            Nome = nome;
            DataDeNascimentoStr = dataDeNascimentoStr;
            Cpf = cpf;
            Endereco = endereco;
        }
    }
}
