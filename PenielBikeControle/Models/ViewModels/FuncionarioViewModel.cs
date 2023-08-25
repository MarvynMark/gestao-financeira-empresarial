
namespace PenielBikeControle.Models.ViewModels
{
    public class FuncionarioViewModel 
    {
        public IList<Funcionario> ListaFuncionarios { get; set; }
        public AdicionarFuncionarioViewModel Funcionario { get; set; }

        public FuncionarioViewModel(IList<Funcionario> listaFuncionarios, AdicionarFuncionarioViewModel funcionario)
        {
            ListaFuncionarios = listaFuncionarios;
            Funcionario = funcionario;
        }
    }
}
