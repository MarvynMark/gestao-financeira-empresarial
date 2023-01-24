using PenielBikeControle.Models;

namespace PenielBikeControle.Repositories.Iterfaces
{
    public interface IFuncionarioRepository
    {
        void Salvar(Funcionario funcionario);
        IList<Funcionario> GetAll();
        Funcionario GetById(int id);
    }
}
